using KeepassCopyTool.Application.DTOs;
using KeepassCopyTool.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepassCopyTool.Application.Commands
{
    public class BackupSettingsCommand : IBackupSettingsCommand
    {
        private readonly IRegRepository _regRepository;

        public BackupSettingsCommand(IRegRepository regRepository)
        {
            _regRepository = regRepository;
        }

        public bool Execute(BackupSettingsDTO backupSettings)
        {
            bool result = false;
            try
            {
                _regRepository.SetSourceFilePath(backupSettings.SourceFilePath);
                _regRepository.SetBackupInterval(backupSettings.BackupInterval);
                _regRepository.SetDestinationFolder(backupSettings.DestinationFolder);

                result = true;
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
}
