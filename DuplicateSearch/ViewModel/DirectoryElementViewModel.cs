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
    // class DirectoryElementViewModel
    //----------------------------------------------------------------------------------------------------------------------    
    public class DirectoryElementViewModel : FileSystemElementViewModel
    {
        private DirectoryInfo directory;
        //----------------------------------------------------------------------------------------------------------------------    
        public DirectoryInfo Directory
        {
            get { return directory; }
        }
        //----------------------------------------------------------------------------------------------------------------------   
        public override string Name
        {
            get { return directory.Name; }
        }
        //----------------------------------------------------------------------------------------------------------------------    
        public DirectoryElementViewModel(System.IO.DirectoryInfo pDirectory)
        {
            this.directory = pDirectory;
        }
        //----------------------------------------------------------------------------------------------------------------------   
        public override void FindChields()
        {
            try
            {
                foreach (DirectoryInfo dir in directory.GetDirectories())
                {
                    DirectoryElementViewModel item = new DirectoryElementViewModel(dir);
                    Chields.Add(item);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.Write(e.Message);
            }
            catch (DirectoryNotFoundException ed)
            {
                Console.Write(ed.Message);
            }

        }
        //----------------------------------------------------------------------------------------------------------------------   
        public override ObservableCollection<DirectoryElementViewModel> GetSelectetedFolders(ObservableCollection<DirectoryElementViewModel> pList)
        {
            if (IsSelected)
                pList.Add(this);
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
