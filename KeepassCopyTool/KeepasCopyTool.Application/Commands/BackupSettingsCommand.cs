using KeepassCopyTool.Application.DTOs;
using KeepassCopyTool.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepassCopyTool.Application.Commands
{
    internal class BackupSettingsCommand : IBackupSettingsCommand
    {
        private readonly IRegRepository _regRepository;

        public BackupSettingsCommand(IRegRepository regRepository)
        {
            _regRepository = regRepository;
        }

        public bool Execute(BackupSettingsDTO backupSettings)
        {
            if (backupSettings == null)
            {
                return false;
            }

            BackupSettingsDTO previousSettings = null;
            string previousLastSettingsUpdateDate = null;

            try
            {
                previousSettings = new BackupSettingsDTO
                {
                    SourceFilePath = _regRepository.GetSourceFilePath(),
                    DestinationFolder = _regRepository.GetDestinationFolder(),
                    BackupInterval = _regRepository.GetBackupInterval()
                };
                previousLastSettingsUpdateDate = _regRepository.GetLastSettingsUpdateDate();

                _regRepository.SetSourceFilePath(backupSettings.SourceFilePath);
                _regRepository.SetBackupInterval(backupSettings.BackupInterval);
                _regRepository.SetDestinationFolder(backupSettings.DestinationFolder);
                _regRepository.SetLastSettingsUpdateDate(DateTime.Now);

                return true;
            }
            catch (Exception)
            {
                RestorePreviousSettings(previousSettings, previousLastSettingsUpdateDate);
                return false;
            }
        }

        private void RestorePreviousSettings(BackupSettingsDTO previousSettings, string previousLastSettingsUpdateDate)
        {
            if (previousSettings == null)
            {
                return;
            }

            try
            {
                _regRepository.SetSourceFilePath(previousSettings.SourceFilePath);
                _regRepository.SetBackupInterval(previousSettings.BackupInterval);
                _regRepository.SetDestinationFolder(previousSettings.DestinationFolder);

                DateTime previousDate;
                if (DateTime.TryParse(previousLastSettingsUpdateDate, out previousDate))
                {
                    _regRepository.SetLastSettingsUpdateDate(previousDate);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
