using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepassCopyTool.Application.DTOs
{
    public class BackupSettingsDTO
    {
        public string SourceFilePath { get; set; }
        public string DestinationFolder { get; set; }
        public int BackupIntervalHours { get; set; }
        public string LastSettingsUpdateDate { get; set; }
        public string LastRunDate { get; set; }
    }
}
