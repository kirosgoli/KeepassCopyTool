using KeepassCopyTool.Application.DTOs;

namespace KeepassCopyTool.Application.Commands
{
    public interface IBackupSettingsCommand
    {
        bool Execute(BackupSettingsDTO backupSettings);
    }
}
