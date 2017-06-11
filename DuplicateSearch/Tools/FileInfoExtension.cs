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
        public static bool IsEqual(this byte[] content, byte[] otherContent)
        {
            if (content.Length != otherContent.Length)
                return false;
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i] != otherContent[i])
                    return false;
            }
            return true;
        }
    }
}
