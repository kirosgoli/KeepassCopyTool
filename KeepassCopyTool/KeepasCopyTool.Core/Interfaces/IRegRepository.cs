using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepassCopyTool.Core.Interfaces
{
    public interface IRegRepository
    {
        string GetLastUpdateDate();
        void SetLastUpdateDate(DateTime dateTime);
        int GetBackupInterval();
        void SetBackupInterval(int backupInterval);
        string GetDestinationFolder();
        void SetDestinationFolder(string destinationFolder);
        string GetSourceFilePath();
        void SetSourceFilePath(string sourceFilePath);
    }
}
