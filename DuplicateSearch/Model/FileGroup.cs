using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateSearch.Model
{
    //----------------------------------------------------------------------------------------------------------------------
    // class DiskElementViewModel
    //----------------------------------------------------------------------------------------------------------------------    
    public abstract class FileGroup
    {
        public ObservableCollection<FileInfo> Files { get; set; }
        public abstract bool IsFileMatch(FileInfo pFile);
        public abstract FileGroup Clone();
        public FileGroup()
        {
            Files = new ObservableCollection<FileInfo>();
        }
    }
}
