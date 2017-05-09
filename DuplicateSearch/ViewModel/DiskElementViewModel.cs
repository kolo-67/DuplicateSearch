using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateSearch.ViewModel
{
    //----------------------------------------------------------------------------------------------------------------------
    // class DiskElementViewModel
    //----------------------------------------------------------------------------------------------------------------------    
    public class DiskElementViewModel : FileSystemElementViewModel
    {
        private DriveInfo drive;
        //----------------------------------------------------------------------------------------------------------------------   
        public override string Name
        {
            get { return drive.Name; }
        }
        //----------------------------------------------------------------------------------------------------------------------   
        public DiskElementViewModel(DriveInfo pDrive)
        {

            this.drive = pDrive;
        }
        //----------------------------------------------------------------------------------------------------------------------   
        public override void FindChields()
        {
            if (drive.IsReady)
                foreach (DirectoryInfo dir in drive.RootDirectory.GetDirectories())
                {
                    DirectoryElementViewModel item = new DirectoryElementViewModel(dir);
                    Chields.Add(item);
                }
        }
        //----------------------------------------------------------------------------------------------------------------------   
        public override ObservableCollection<DirectoryElementViewModel> GetSelectetedFolders(ObservableCollection<DirectoryElementViewModel> pList)
        {
            foreach (var c in Chields)
            {
                c.GetSelectetedFolders(pList);
            }
            return pList;
        }
        //----------------------------------------------------------------------------------------------------------------------   
    }
    //----------------------------------------------------------------------------------------------------------------------   
}
