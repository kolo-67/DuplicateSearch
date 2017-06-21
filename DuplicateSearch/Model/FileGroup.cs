using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateSearch.Model
{
    //----------------------------------------------------------------------------------------------------------------------
    // class DiskElementViewModel
    //----------------------------------------------------------------------------------------------------------------------    
    public abstract class FileGroup : System.ComponentModel.INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<FileInfo> files;
        public ObservableCollection<FileInfo> Files
        {
            get
            {
                return files;
            }
            set
            {
                files = value;
                OnPropertyChanged("Files");
            }
        }
        public abstract bool IsFileMatch(FileInfo pFile);
        public abstract FileGroup Clone();
        public FileGroup()
        {
            Files = new ObservableCollection<FileInfo>();
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
