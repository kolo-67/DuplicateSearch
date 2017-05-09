using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateSearch.Contracts
{
    public interface IDuplicateSearchActionQueriable
    {
        event Action<object> FolderDialogQuery;
    }
}
