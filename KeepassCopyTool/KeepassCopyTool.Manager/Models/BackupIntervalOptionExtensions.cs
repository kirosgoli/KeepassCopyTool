using System.Collections.Generic;

namespace KeepassCopyTool.Manager.Models
{
    internal static class BackupIntervalOptionExtensions
    {
        public static BackupIntervalOption FindOptionByHours(this IEnumerable<BackupIntervalOption> options, int hours)
        {
            foreach (BackupIntervalOption option in options)
            {
                if (!option.IsCustom && option.Hours == hours)
                {
                    return option;
                }
            }

            return null;
        }

        public static BackupIntervalOption GetCustomOption(this IEnumerable<BackupIntervalOption> options)
        {
            foreach (BackupIntervalOption option in options)
            {
                if (option.IsCustom)
                {
                    return option;
                }
            }

            return null;
        }
    }
}
