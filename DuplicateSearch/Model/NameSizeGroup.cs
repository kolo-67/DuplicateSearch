using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateSearch.Model
{
    //----------------------------------------------------------------------------------------------------------------------
    // class NameSizeGroup
    //----------------------------------------------------------------------------------------------------------------------    
    public class NameSizeGroup : NameGroup
    {
        public long Size { get; set; }
        //----------------------------------------------------------------------------------------------------------------------    
        public override bool IsFileMatch(System.IO.FileInfo pFile)
        {
            return FileName.Equals(pFile.Name) && Size == pFile.Length;
        }
        //----------------------------------------------------------------------------------------------------------------------    
        public override FileGroup Clone()
        {
            var clone = new NameSizeGroup();
            clone.Size = Size;
            clone.FileName = FileName;
            return clone;
        }
        //----------------------------------------------------------------------------------------------------------------------    
        public override string ToString()
        {
            return string.Format("{0},{1}", FileName, Size);
        }
        //----------------------------------------------------------------------------------------------------------------------    
    }
    //----------------------------------------------------------------------------------------------------------------------    
}
