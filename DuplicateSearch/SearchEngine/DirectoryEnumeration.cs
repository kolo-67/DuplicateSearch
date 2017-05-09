using DuplicateSearch.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateSearch.SearchEngine
{
    //----------------------------------------------------------------------------------------------------------------------
    // class DirectoryEnumeration
    //----------------------------------------------------------------------------------------------------------------------    
    public class DirectoryEnumeration
    {
        private Func<FileInfo,FileGroup> GetGroup;
        public event Action<FileGroup> NewFileGroup;
        public event Action<FileInfo> NewFile;
        private List<FileGroup> FileGroups;
        public string DirectoryStart { get; set; }
        public string Mask { get; set; }
        public bool IsFilterBySize { get; set; }
        public long SizeFrom { get; set; }
        public long SizeTo { get; set; }
        //----------------------------------------------------------------------------------------------------------------------    
        public DirectoryEnumeration(bool pIsGroupByName, bool pIsGroupBySize, bool pIsGroupByDateTime)
        {
            Initialize(pIsGroupByName, pIsGroupBySize, pIsGroupByDateTime);
        }
        //----------------------------------------------------------------------------------------------------------------------    
        public async Task StartAsync()
        {
            Task taskProcess = new Task(() => Process());
            taskProcess.Start();

            await taskProcess;
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private void Process()
        {
            FileGroups = new List<FileGroup>();
            DirectoryInfo di = new DirectoryInfo(DirectoryStart);
            DirectoryInfo[] directories = di.GetDirectories("*", SearchOption.AllDirectories);
            foreach(var d in directories)
            {
                try
                {
                    FileInfo[] files = d.GetFiles(Mask, SearchOption.TopDirectoryOnly);
                    IEnumerable<FileInfo> filesAfterFilter = files;
                    if (IsFilterBySize)
                        filesAfterFilter = files.Where(f => f.Length >= SizeFrom && f.Length <= SizeTo);
                    foreach (var f in filesAfterFilter)
                    {
                        var group = FileGroups.FirstOrDefault(g => g.IsFileMatch(f));
                        if (group == null)
                        {
                            group = GetGroup(f);
                            FileGroups.Add(group);
                        }
                        else
                        {
                            if (group.Files.Count == 1)
                            {
                                OnNewFileGroup(group);
                                OnNewFile(group.Files[0]);
                            }
                            OnNewFile(f);
                        }
                        group.Files.Add(f);
                    }
                }
                catch (DirectoryNotFoundException nfe)
                {

                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private void OnNewFileGroup(FileGroup pFileGroup)
        {
            Action<FileGroup> handler = NewFileGroup;
            if (handler != null)
                handler(pFileGroup);
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private void OnNewFile(FileInfo pFile)
        {
            Action<FileInfo> handler = NewFile;
            if (handler != null)
                handler(pFile);
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private void Initialize(bool pIsGroupByName, bool pIsGroupBySize, bool pIsGroupByDateTime)
        {
            if (pIsGroupByName)
            {
                if (pIsGroupBySize)
                {
                    if (pIsGroupByDateTime)
                        GetGroup = NameSizeDateGroupFun;
                    else
                        GetGroup = NameSizeGroupFun;
                }
                else if (pIsGroupByDateTime)
                {
                        GetGroup = NameDateGroupFun;
                }
                else
                    GetGroup = NameFun;
            }
            else if (pIsGroupBySize)
            {
                if (pIsGroupByDateTime)
                    GetGroup = SizeDateGroupFun;
                else
                    GetGroup = SizeGroupFun;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private FileGroup NameSizeDateGroupFun(FileInfo file)
        {
            NameSizeDateGroup group = new NameSizeDateGroup() { FileName = file.Name, Size = file.Length, FileDateTime = file.LastAccessTime };
            return group;
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private FileGroup NameSizeGroupFun(FileInfo file)
        {
            NameSizeGroup group = new NameSizeGroup() { FileName = file.Name, Size = file.Length };
            return group;
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private FileGroup NameDateGroupFun(FileInfo file)
        {
            NameDateGroup group = new NameDateGroup() { FileName = file.Name,  FileDateTime = file.LastAccessTime };
            return group;
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private FileGroup NameFun(FileInfo file)
        {
            NameGroup group = new NameGroup() { FileName = file.Name };
            return group;
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private FileGroup SizeDateGroupFun(FileInfo file)
        {
            SizeDateGroup group = new SizeDateGroup() {  Size = file.Length, FileDateTime = file.LastAccessTime };
            return group;
        }
        //----------------------------------------------------------------------------------------------------------------------    
        private FileGroup SizeGroupFun(FileInfo file)
        {
            SizeGroup group = new SizeGroup() { Size = file.Length };
            return group;
        }
        //----------------------------------------------------------------------------------------------------------------------    

    }
    //----------------------------------------------------------------------------------------------------------------------    
}
