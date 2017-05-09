using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateSearch.Model
{
    //----------------------------------------------------------------------------------------------------------------------
    // class NameGroup
    //----------------------------------------------------------------------------------------------------------------------    
    public class NameGroup : FileGroup
    {
        public string FileName { get; set; }
        //----------------------------------------------------------------------------------------------------------------------    
        public override bool IsFileMatch(System.IO.FileInfo pFile)
        {
            return FileName.Equals(pFile.Name);
        }
        //----------------------------------------------------------------------------------------------------------------------    
        public override FileGroup Clone()
        {
            var clone = new NameGroup();
            clone.FileName = FileName;
            return clone;
        }
        //----------------------------------------------------------------------------------------------------------------------    
        public override string ToString()
        {
            return string.Format("{0}", FileName);
        }
        //----------------------------------------------------------------------------------------------------------------------    
    }
    //----------------------------------------------------------------------------------------------------------------------    
}
