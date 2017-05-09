using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateSearch.Tools
{
    public static class FileInfoExtension
    {
        public static IEnumerable<string> GetDirectoriesEnumerator(this FileInfo file)
        {
            DirectoryInfo dir = file.Directory;
            while (dir != null)
            {
                yield return dir.FullName;
                dir = dir.Parent;
            }

        }
    }
}
