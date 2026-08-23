using KeepassCopyTool.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepassCopyTool.Application.Queries
{
    public interface IBackupSettingsQuery
    {
        BackupSettingsDTO Execute();
    }
}
