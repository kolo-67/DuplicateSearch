using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateSearch.Model
{
    //----------------------------------------------------------------------------------------------------------------------
    // class NameDateGroup
    //----------------------------------------------------------------------------------------------------------------------    
    public class NameDateGroup : NameGroup
    {
        public DateTime FileDateTime { get; set; }
        //----------------------------------------------------------------------------------------------------------------------    
        public override bool IsFileMatch(System.IO.FileInfo pFile)
        {
            return FileName.Equals(pFile.Name) && FileDateTime.ToString("yyyyMMddHHmmss").Equals(pFile.LastAccessTime.ToString("yyyyMMddHHmmss"));
        }
        //----------------------------------------------------------------------------------------------------------------------    
        public override FileGroup Clone()
        {
            var clone = new NameDateGroup();
            clone.FileName = FileName;
            clone.FileDateTime = FileDateTime;
            return clone;
        }
        //----------------------------------------------------------------------------------------------------------------------    
        public override string ToString()
        {
            return string.Format("{0},{1}", FileName, FileDateTime.ToString("yyMMdd HHmmss"));
        }
        //----------------------------------------------------------------------------------------------------------------------    
    }
    //----------------------------------------------------------------------------------------------------------------------    
}
