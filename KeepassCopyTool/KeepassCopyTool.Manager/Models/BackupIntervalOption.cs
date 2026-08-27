using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepassCopyTool.Manager.Models
{
    internal class BackupIntervalOption
    {
        public string DisplayName { get; set; }
        public int Hours { get; set; }
        public bool IsCustom { get; set; }


        internal static class Factory
        {
            internal static List<BackupIntervalOption> Defaults
            {
                get
                {
                    return new List<BackupIntervalOption>()
                    {
                        new BackupIntervalOption { DisplayName = "Co 6 godzin", Hours = 6 },
                        new BackupIntervalOption { DisplayName = "Co 12 godzin", Hours = 12 },
                        new BackupIntervalOption { DisplayName = "Raz dziennie", Hours = 24 },
                        new BackupIntervalOption { DisplayName = "Raz w tygodniu", Hours = 168 },
                        new BackupIntervalOption { DisplayName = "Niestandardowy...", IsCustom = true }
                    };
                }
            }
        }
    }
}


