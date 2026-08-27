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


        internal static class Factory
        {
            internal static List<BackupIntervalOption> Defaults
            {
                get
                {
                    return new List<BackupIntervalOption>()
                    {
                        new BackupIntervalOption { DisplayName = "Raz dziennie", Hours = 24 },
                        new BackupIntervalOption { DisplayName = "Raz w tygodniu", Hours = 168 },
                        new BackupIntervalOption { DisplayName = "Raz w miesiącu", Hours = 720 }
                    };
                }
            }
        }
    }
}


