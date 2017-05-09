using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateSearch.Model
{
    //----------------------------------------------------------------------------------------------------------------------
    // class SizeDateGroup
    //----------------------------------------------------------------------------------------------------------------------    
    public class SizeDateGroup : SizeGroup
    {
        public DateTime FileDateTime { get; set; }
        //----------------------------------------------------------------------------------------------------------------------    
        public override bool IsFileMatch(System.IO.FileInfo pFile)
        {
            return Size.Equals(pFile.Length) && FileDateTime.ToString("yyyyMMddHHmmss").Equals(pFile.LastAccessTime.ToString("yyyyMMddHHmmss"));
        }
        //----------------------------------------------------------------------------------------------------------------------    
        public override FileGroup Clone()
        {
            var clone = new SizeDateGroup();
            clone.Size = Size;
            clone.FileDateTime = FileDateTime;
            return clone;
        }
        //----------------------------------------------------------------------------------------------------------------------    
        public override string ToString()
        {
            return string.Format("{0},{1}", Size, FileDateTime.ToString("yyMMdd HHmmss"));
        }
        //----------------------------------------------------------------------------------------------------------------------    
    }
    //----------------------------------------------------------------------------------------------------------------------    
}
