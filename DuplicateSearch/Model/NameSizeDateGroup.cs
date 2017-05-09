using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateSearch.Model
{
    //----------------------------------------------------------------------------------------------------------------------
    // class NameSizeDateGroup
    //----------------------------------------------------------------------------------------------------------------------    
    public class NameSizeDateGroup : NameSizeGroup
    {
        public DateTime FileDateTime { get; set; }
        //----------------------------------------------------------------------------------------------------------------------    
        public override bool IsFileMatch(System.IO.FileInfo pFile)
        {
            return FileName.Equals(pFile.Name) && Size.Equals(pFile.Length) && FileDateTime.ToString("yyyyMMddHHmmss").Equals(pFile.LastAccessTime.ToString("yyyyMMddHHmmss"));
        }
        //----------------------------------------------------------------------------------------------------------------------    
        public override FileGroup Clone()
        {
            var clone = new NameSizeDateGroup();
            clone.Size = Size;
            clone.FileName = FileName;
            clone.FileDateTime = FileDateTime;
            return clone;
        }
        //----------------------------------------------------------------------------------------------------------------------    
        public override string ToString()
        {
            return string.Format("{0},{1},{2}", FileName, Size, FileDateTime.ToString("yyMMdd HHmmss"));
        }
        //----------------------------------------------------------------------------------------------------------------------    
    }
    //----------------------------------------------------------------------------------------------------------------------    
}
