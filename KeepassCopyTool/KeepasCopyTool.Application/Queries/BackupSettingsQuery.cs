using KeepassCopyTool.Application.DTOs;
using KeepassCopyTool.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepassCopyTool.Application.Queries
{
    internal class BackupSettingsQuery : IBackupSettingsQuery
    {
        private IRegRepository regRepository;

        public BackupSettingsQuery(IRegRepository regRepository)
        {
            this.regRepository = regRepository;
        }

        public BackupSettingsDTO Execute()
        {
            BackupSettingsDTO result = new BackupSettingsDTO()
            {
                BackupInterval = this.regRepository.GetBackupInterval(),
                DestinationFolder = this.regRepository.GetDestinationFolder(),
                LastSettingsUpdateDate = this.regRepository.GetLastSettingsUpdateDate(),
                LastRunDate = this.regRepository.GetLastRunDate(),
                SourceFilePath = this.regRepository.GetSourceFilePath(),
            };
            return result;
        }
    }
}
