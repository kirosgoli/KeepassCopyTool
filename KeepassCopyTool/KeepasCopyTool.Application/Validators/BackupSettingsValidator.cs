using KeepassCopyTool.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepassCopyTool.Application.Validators
{
    internal class BackupSettingsValidator : IBackupSettingsValidator
    {
        public ValidationResult Validate(BackupSettingsDTO value)
        {
            ValidationResult result = new ValidationResult();
			try
			{
                if (!(value.BackupIntervalHours > 0))
                    result.AddError("Wybierz częstotliwość kopii.");
                if (!System.IO.File.Exists(value.SourceFilePath))
                    result.AddError($"Plik {value.SourceFilePath} nie istnieje lub nie ma do niego dostępu");
                if (!System.IO.Directory.Exists(value.DestinationFolder))
                    result.AddError($"Folder {value.DestinationFolder} nie istnieje lub nie ma do niego dostępu");
            }
			catch (Exception ex)
			{
                result = new ValidationResult();
                result.AddError("Nie znany wyjątek.");
			}
            return result;
        }
    }
}
