using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace DuplicateSearch.ViewModel
{
    //----------------------------------------------------------------------------------------------------------------------
    // class ShowFolderViewModel
    //----------------------------------------------------------------------------------------------------------------------    
    public class ShowFolderViewModel : ViewModelBase
    {
        private ComputerElementViewModel computerFiles;
        private bool isAccept;
        private ObservableCollection<DirectoryElementViewModel> selectedDirectories;
        //----------------------------------------------------------------------------------------------------------------------    
        public ComputerElementViewModel ComputerFiles
        {
            get { return computerFiles; }
            set
            {
                computerFiles = value;
                RaisePropertyChanged(() => ComputerFiles);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        public bool IsAccept
        {
            get { return isAccept; }
            set
            {
                isAccept = value;
                RaisePropertyChanged(() => IsAccept);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        public ShowFolderViewModel()
        {
            ComputerFiles = new ComputerElementViewModel();
            computerFiles.FindChields();
            computerFiles.FindChieldChields();
            selectedDirectories = new ObservableCollection<DirectoryElementViewModel>();
        }
        //----------------------------------------------------------------------------------------------------------------------   
        public ObservableCollection<DirectoryElementViewModel> GetSelectetedFolders()
        {
            return selectedDirectories;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private ICommand expandedCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand ExpandedCommand
        {
            get
            {
                if (expandedCommand == null)
                {
                    expandedCommand = new RelayCommand<object>(ExpandedAction, CanExpandedAction);
                }
                return expandedCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void ExpandedAction(object pObject)
        {
            FileSystemElementViewModel fsElement = pObject as FileSystemElementViewModel;
            if (fsElement != null)
                fsElement.FindChieldChields();
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanExpandedAction(object pObject)
        {
            return true;
        }
        //----------------------------------------------------------------------------------------------------------------------    
        //-------------------------------------------------------------------------------------------------------------------
        private ICommand okCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand OkCommand
        {
            get
            {
                if (okCommand == null)
                {
                    okCommand = new RelayCommand(OkAction, CanOkAction);
                }
                return okCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void OkAction()
        {
            ComputerFiles.GetSelectetedFolders(selectedDirectories);
            IsAccept = true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanOkAction()
        {
            return true;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private ICommand cancelCommand;
        //-------------------------------------------------------------------------------------------------------------------
        public ICommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                {
                    cancelCommand = new RelayCommand(CancelAction, CanCancelAction);
                }
                return cancelCommand;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        private void CancelAction()
        {
            IsAccept = false;
        }
        //-------------------------------------------------------------------------------------------------------------------
        private bool CanCancelAction()
        {
            return true;
        }
        //----------------------------------------------------------------------------------------------------------------------    
    }
    //----------------------------------------------------------------------------------------------------------------------    
}
