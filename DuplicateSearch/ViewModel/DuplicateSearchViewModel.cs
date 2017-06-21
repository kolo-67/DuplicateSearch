using DuplicateSearch.Model;
using DuplicateSearch.SearchEngine;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Linq;
using System.Windows.Input;
using System.IO;
using DuplicateSearch.Contracts;
using DuplicateSearch.Tools;
using System.Collections.Generic;

namespace DuplicateSearch.ViewModel
{
    public enum StateOfProcessEnum { BeforeExecute, Process, Complete }
    /// <summary>
    /// </summary>
    //----------------------------------------------------------------------------------------------------------------------    
    // class DuplicateSearchViewModel
    //----------------------------------------------------------------------------------------------------------------------    
    public class DuplicateSearchViewModel : ViewModelBase, IDuplicateSearchActionQueriable
    {

        public event Action<object> FolderDialogQuery;
        //----------------------------------------------------------------------------------------------------------------------    
        private ObservableCollection<FileGroup> filesGroups;
        public ObservableCollection<FileGroup> FilesGroups
        {
            get { return filesGroups; }
            set
            {
                filesGroups = value;
                RaisePropertyChanged(() => FilesGroups);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private FileGroup selectedFilesGroups;
        public FileGroup SelectedFilesGroups
        {
            get { return selectedFilesGroups; }
            set
            {
                selectedFilesGroups = value;
                RaisePropertyChanged(() => SelectedFilesGroups);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private FileInfo selectedFile;
        public FileInfo SelectedFile
        {
            get { return selectedFile; }
            set
            {
                selectedFile = value;
                RaisePropertyChanged(() => SelectedFile);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private string directoryStart;
        public string DirectoryStart
        {
            get { return directoryStart; }
            set
            {
                directoryStart = value;
                RaisePropertyChanged(() => DirectoryStart);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private string mask;
        public string Mask
        {
            get { return mask; }
            set
            {
                mask = value;
                RaisePropertyChanged(() => Mask);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private long sizeFrom;
        public long SizeFrom
        {
            get { return sizeFrom; }
            set
            {
                sizeFrom = value;
                RaisePropertyChanged(() => SizeFrom);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private long sizeTo;
        public long SizeTo
        {
            get { return sizeTo; }
            set
            {
                sizeTo = value;
                RaisePropertyChanged(() => SizeTo);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private bool isFilterBySize;
        public bool IsFilterBySize
        {
            get { return isFilterBySize; }
            set
            {
                isFilterBySize = value;
                RaisePropertyChanged(() => IsFilterBySize);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private bool isGroupByName;
        public bool IsGroupByName
        {
            get { return isGroupByName; }
            set
            {
                isGroupByName = value;
                RaisePropertyChanged(() => IsGroupByName);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private bool isGroupBySize;
        public bool IsGroupBySize
        {
            get { return isGroupBySize; }
            set
            {
                isGroupBySize = value;
                RaisePropertyChanged(() => IsGroupBySize);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private bool isGroupByDateTime;
        public bool IsGroupByDateTime
        {
            get { return isGroupByDateTime; }
            set
            {
                isGroupByDateTime = value;
                RaisePropertyChanged(() => IsGroupByDateTime);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private string stateOfProcessText;
        public string StateOfProcessText
        {
            get { return stateOfProcessText; }
            set
            {
                stateOfProcessText = value;
                RaisePropertyChanged(() => StateOfProcessText);
            }
        }
        //---------------------------------------------------------------------------------------------------------------------- 
        private StateOfProcessEnum stateOfProcess;
        public StateOfProcessEnum StateOfProces
        {
            get { return stateOfProcess; }
            set
            {
                stateOfProcess = value;
//                RaisePropertyChanged(() => StateOfProcess);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void OnFolderDialogQuery(ShowFolderViewModel showFolderViewModel)
        {
            Action<object> handle = FolderDialogQuery;
            if (handle != null)
                handle(showFolderViewModel);
        }
        //-------------------------------------------------------------------------------------------------------------------
        private ICommand getStartDirectoryCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand GetStartDirectoryCommand
        {
            get
            {
                if (getStartDirectoryCommand == null)
                {
                    getStartDirectoryCommand = new RelayCommand(GetStartDirectoryAction, CanGetStartDirectoryAction);
                }
                return getStartDirectoryCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void GetStartDirectoryAction()
        {
            ShowFolderViewModel showFolderViewModel = new ShowFolderViewModel();
            OnFolderDialogQuery(showFolderViewModel);
            ObservableCollection<DirectoryElementViewModel> sf = showFolderViewModel.GetSelectetedFolders();
            if (sf != null && sf.Count > 0)
                DirectoryStart = sf[0].Directory.FullName;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanGetStartDirectoryAction()
        {
            return StateOfProces != StateOfProcessEnum.Process;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public DuplicateSearchViewModel()
        {
            IsFilterBySize = false;
            IsGroupByDateTime = true;
            IsGroupByName = true;
            IsGroupBySize = true;
            Mask = "*.*";
        }
        //-------------------------------------------------------------------------------------------------------------------
        private ICommand startSearchCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand StartSearchCommand
        {
            get
            {
                if (startSearchCommand == null)
                {
                    startSearchCommand = new RelayCommand(StartSearchAction, CanStartSearchAction);
                }
                return startSearchCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private async void StartSearchAction()
        {
            FilesGroups = new ObservableCollection<FileGroup>();
            StateOfProces = StateOfProcessEnum.Process;
            StateOfProcessText = "Working...";

            DirectoryEnumeration enumeration = new DirectoryEnumeration(IsGroupByName, isGroupBySize, IsGroupByDateTime)
            {
                DirectoryStart = DirectoryStart,
                IsFilterBySize = IsFilterBySize,
                SizeFrom = SizeFrom,
                SizeTo = SizeTo,
                Mask = Mask
            };
            enumeration.NewFileGroup += enumeration_NewFileGroup;
            enumeration.NewFile += enumeration_NewFile;
            Task encTask = enumeration.StartAsync();
            
            await encTask;

            StateOfProcessText = "Completed";
            StateOfProces = StateOfProcessEnum.Complete;       
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanStartSearchAction()
        {
            return StateOfProces != StateOfProcessEnum.Process;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private ICommand deleteAllExceptSelectedCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand DeleteAllExceptSelectedCommand
        {
            get
            {
                if (deleteAllExceptSelectedCommand == null)
                {
                    deleteAllExceptSelectedCommand = new RelayCommand(DeleteAllExceptSelectedAction, CanDeleteAllExceptSelectedAction);
                }
                return deleteAllExceptSelectedCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private async void DeleteAllExceptSelectedAction()
        {
            Task taskProcess = new Task(() => DeleteAllExceptSelected());
            taskProcess.Start();

            await taskProcess; 
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void DeleteAllExceptSelected()
        {
            if (SelectedFilesGroups.Files.Count == 0)
                return;
            if (SelectedFile == null)
                SelectedFile = SelectedFilesGroups.Files[0];
            for (int i = SelectedFilesGroups.Files.Count - 1; i >= 0; i--)
            {
                if (SelectedFilesGroups.Files[i] != SelectedFile)
                {
                    try
                    {
                        File.Delete(SelectedFilesGroups.Files[i].FullName);
                    }
                    catch ( UnauthorizedAccessException e)
                    {
                        MessageBox.Show(e.Message);
                    }
//                    SelectedFilesGroups.Files[i].Delete();
                    Application.Current.Dispatcher.Invoke(
                    (Action)(() =>
                    {
                        SelectedFilesGroups.Files.RemoveAt(i);
                    })); 
                }

            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanDeleteAllExceptSelectedAction()
        {
            return StateOfProces != StateOfProcessEnum.Process;
        }
        //------------------------------------------------------------------------------------------------------------------
        private ICommand deleteSelectedCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand DeleteSelectedCommand
        {
            get
            {
                if (deleteSelectedCommand == null)
                {
                    deleteSelectedCommand = new RelayCommand(DeleteSelectedAction, CanDeleteSelectedAction);
                }
                return deleteSelectedCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void DeleteSelectedAction()
        {
            if (SelectedFile != null)
            {
                SelectedFile.Delete();
                selectedFilesGroups.Files.Remove(SelectedFile);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanDeleteSelectedAction()
        {
            return StateOfProces != StateOfProcessEnum.Process;
        }
        //------------------------------------------------------------------------------------------------------------------
        private ICommand goToTheLatestCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand GoToTheLatestCommand
        {
            get
            {
                if (goToTheLatestCommand == null)
                {
                    goToTheLatestCommand = new RelayCommand(GoToTheLatestAction, CanGoToTheLatestAction);
                }
                return goToTheLatestCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void GoToTheLatestAction()
        {
            if (SelectedFilesGroups != null && SelectedFilesGroups.Files.Count > 1)
            {
                int lasti = 0;
                for (int i = 1; i < SelectedFilesGroups.Files.Count; i++)
                {
                    if (SelectedFilesGroups.Files[i].LastWriteTime > SelectedFilesGroups.Files[lasti].LastWriteTime)
                        lasti = i;
                }
                SelectedFile = SelectedFilesGroups.Files[lasti];
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanGoToTheLatestAction()
        {
            return StateOfProces != StateOfProcessEnum.Process && SelectedFilesGroups != null;
        }
        //------------------------------------------------------------------------------------------------------------------
        private ICommand openDirectoryCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand OpenDirectoryCommand
        {
            get
            {
                if (openDirectoryCommand == null)
                {
                    openDirectoryCommand = new RelayCommand(OpenDirectoryAction, CanOpenDirectoryAction);
                }
                return openDirectoryCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void OpenDirectoryAction()
        {
            if (selectedFile != null)
            {
                System.Diagnostics.Process.Start(selectedFile.Directory.FullName);
                DataObject data = new DataObject(DataFormats.StringFormat, "cd " + selectedFile.Directory.FullName);

                Clipboard.SetDataObject(data);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanOpenDirectoryAction()
        {
            return selectedFile != null;
        }
        //------------------------------------------------------------------------------------------------------------------
        private ICommand openFileCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand OpenFileCommand
        {
            get
            {
                if (openFileCommand == null)
                {
                    openFileCommand = new RelayCommand(OpenFileAction, CanOpenFileAction);
                }
                return openFileCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void OpenFileAction()
        {
            if (selectedFile != null)
            {
                System.Diagnostics.Process.Start(selectedFile.FullName);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanOpenFileAction()
        {
            return selectedFile != null;
        }
        //------------------------------------------------------------------------------------------------------------------
        private ICommand openAllFileCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand OpenAllFileCommand
        {
            get
            {
                if (openAllFileCommand == null)
                {
                    openAllFileCommand = new RelayCommand(OpenAllFileAction, CanOpenAllFileAction);
                }
                return openAllFileCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void OpenAllFileAction()
        {
            foreach (var file in SelectedFilesGroups.Files)
            {
                System.Diagnostics.Process.Start(file.FullName);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanOpenAllFileAction()
        {
            return SelectedFilesGroups != null;
        }
        //------------------------------------------------------------------------------------------------------------------
        private ICommand openCommonDirectoryCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand OpenCommonDirectoryCommand
        {
            get
            {
                if (openCommonDirectoryCommand == null)
                {
                    openCommonDirectoryCommand = new RelayCommand(OpenCommonDirectoryAction, CanOpenCommonDirectoryAction);
                }
                return openCommonDirectoryCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void OpenCommonDirectoryAction()
        {
            if (SelectedFilesGroups != null && SelectedFilesGroups.Files.Count > 1)
            {
                IEnumerable<string> comonPart = SelectedFilesGroups.Files[0].GetDirectoriesEnumerator();
                foreach (var file in SelectedFilesGroups.Files.Skip(1))
                {
                    IEnumerable<string> iPart = file.GetDirectoriesEnumerator();
                    IEnumerable<string> newComPart = from d1 in comonPart
                                                     join d2 in iPart on d1 equals d2
                                                     select d1;
                    comonPart = newComPart;
                }
                string dir = comonPart.FirstOrDefault();

                if (!string.IsNullOrEmpty(dir))
                {
                    System.Diagnostics.Process.Start(dir);
                    DataObject data = new DataObject(DataFormats.StringFormat, "cd " + dir);

                    Clipboard.SetDataObject(data);
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanOpenCommonDirectoryAction()
        {
            return SelectedFilesGroups != null;
        }
        //------------------------------------------------------------------------------------------------------------------
        private ICommand compareFilesCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand CompareFilesCommand
        {
            get
            {
                if (compareFilesCommand == null)
                {
                    compareFilesCommand = new RelayCommand(CompareFilesAction, CanCompareFilesAction);
                }
                return compareFilesCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void CompareFilesAction()
        {
            if (SelectedFilesGroups != null && SelectedFilesGroups.Files.Count > 1)
            {
                var list = SelectedFilesGroups.Files.Select(f =>
                    {
                        byte[] data = ReadFileContent(f.FullName);
                        return new { Name = f.FullName, Data = data };
                    }).ToList();

                for (int i = 0; i < list.Count; i++)
                    for( int j = i+1; j < list.Count; j++)
                    {
                        if ( !list[i].Data.IsEqual(list[j].Data))
                        {
                            MessageBox.Show(list[i].Name + " <> " + list[j].Name, "Not all files are equal");
                            return;
                        }
                    }
                MessageBox.Show("All files are equal");
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private async Task<byte[]> ReadFileContentAsync(string fileName)
        {
            string filename = fileName;
            byte[] result;

            using (FileStream SourceStream = File.Open(filename, FileMode.Open))
            {
                result = new byte[SourceStream.Length];
                await SourceStream.ReadAsync(result, 0, (int)SourceStream.Length);
            }
            return result;

        }
        //-------------------------------------------------------------------------------------------------------------------
        private byte[] ReadFileContent(string fileName)
        {
            string filename = fileName;
            byte[] result;

            using (FileStream SourceStream = File.Open(filename, FileMode.Open))
            {
                result = new byte[SourceStream.Length];
                SourceStream.Read(result, 0, (int)SourceStream.Length);
            }
            return result;

        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanCompareFilesAction()
        {
            return SelectedFilesGroups != null;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void enumeration_NewFile(System.IO.FileInfo file)
        {
            var group = FilesGroups.FirstOrDefault(g => g.IsFileMatch(file));
            if (group == null)
            {
                throw new Exception("Logical error in enumeration_NewFile");
            }
            Application.Current.Dispatcher.Invoke(
            (Action)(() =>
            {
                group.Files.Add(file);
            }));
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void enumeration_NewFileGroup(Model.FileGroup group)
        {
            Application.Current.Dispatcher.Invoke(
            (Action)(() =>
            {
                FilesGroups.Add(group.Clone());
            }));
        }
        //------------------------------------------------------------------------------------------------------------------
        private ICommand compareByContentAllCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand CompareByContentAllCommand
        {
            get
            {
                if (compareByContentAllCommand == null)
                {
                    compareByContentAllCommand = new RelayCommand(CompareByContentAllAction, CanCompareByContentAllAction);
                }
                return compareByContentAllCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void CompareByContentAllAction()
        {
            for (int i = FilesGroups.Count - 1; i >= 0; i-- )
            {
                var list = FilesGroups[i].Files.Select(f =>
                {
                    byte[] data = ReadFileContent(f.FullName);
                    return new FileContent { File = f, Data = data };
                }).ToList();

                var groups = list.GroupBy(f => f.Data, f => f.File, (k, l) => new { key = k, List = l }, new ByteArrayComparer()).
                    OrderByDescending(o => o.List.Count()).Where(o => o.List.Count() > 1).ToList();
                FilesGroups[i].Files = new ObservableCollection<FileInfo>();
                if (groups.Count > 0)
                {
                    foreach (var f in groups[0].List)
                    {
                        FilesGroups[i].Files.Add(f);
                    }
                }
                else
                {
                    FilesGroups.RemoveAt(i);
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanCompareByContentAllAction()
        {
            return SelectedFilesGroups != null;
        }
        //------------------------------------------------------------------------------------------------------------------
        private ICommand compareByContentCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand CompareByContentCommand
        {
            get
            {
                if (compareByContentCommand == null)
                {
                    compareByContentCommand = new RelayCommand(CompareByContentAction, CanCompareByContentAction);
                }
                return compareByContentCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void CompareByContentAction()
        {
            if (SelectedFilesGroups != null && SelectedFilesGroups.Files.Count > 1)
            {
                var list = SelectedFilesGroups.Files.Select(f =>
                {
                    byte[] data = ReadFileContent(f.FullName);
                    return new FileContent { File = f, Data = data };
                }).ToList();

                var groups = list.GroupBy(f => f.Data, f => f.File, (k, l) => new { key = k, List = l }, new ByteArrayComparer()).
                    OrderByDescending(o => o.List.Count()).Where(o => o.List.Count() > 1).ToList();
                SelectedFilesGroups.Files = new ObservableCollection<FileInfo>();
                if (groups.Count > 0)
                {
                    foreach (var f in groups[0].List)
                    {
                        SelectedFilesGroups.Files.Add(f);
                    }
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanCompareByContentAction()
        {
            return SelectedFilesGroups != null;
        }
        //----------------------------------------------------------------------------------------------------------------------    
    }
    public class FileContent
    {

        public byte[] Data { get; set; }
        public FileInfo File { get; set; }
    }
    public class ByteContent 
    {

        public byte[] Bytes { get; set; }
    }
    public class ByteArrayComparer : IEqualityComparer<byte[]>
    {

        public bool Equals(byte[] x, byte[] y)
        {
            return x.IsEqual(y);
        }

        public int GetHashCode(byte[] bytes)
        {
            int result = 0;
            for (int i = 0; i < 5 && i < bytes.Length; i++)
                result += bytes[i];
            return result;
        }
    }
    //----------------------------------------------------------------------------------------------------------------------    
}