using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepassCopyTool.Core.Interfaces
{
    public interface IRegRepository
    {
        string GetLastSettingsUpdateDate();
        void SetLastSettingsUpdateDate(DateTime dateTime);
        string GetLastRunDate();
        void SetLastRunDate(DateTime dateTime);
        int GetBackupIntervalHours();
        void SetBackupIntervalHours(int backupIntervalHours);
        string GetDestinationFolder();
        void SetDestinationFolder(string destinationFolder);
        string GetSourceFilePath();
        void SetSourceFilePath(string sourceFilePath);
    }
}
