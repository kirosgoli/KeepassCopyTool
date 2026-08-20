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
        public int BackupInterval { get; set; }
        public string LastUpdateDate { get; set; }
    }
}
