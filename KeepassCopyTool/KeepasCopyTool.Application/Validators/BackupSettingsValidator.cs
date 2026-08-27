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

			if (value == null)
			{
				result.AddError("Ustawienia kopii są wymagane.");
				return result;
			}

			try
			{
                if (value.BackupIntervalHours <= 0)
                    result.AddError("Wybierz częstotliwość kopii.");

                if (string.IsNullOrWhiteSpace(value.SourceFilePath))
                {
                    result.AddError("Wybierz plik bazy KeePass.");
                }
                else
                {
                    if (!System.IO.File.Exists(value.SourceFilePath))
                        result.AddError($"Plik {value.SourceFilePath} nie istnieje lub nie ma do niego dostępu");
                    if (!value.SourceFilePath.EndsWith(".kdbx", StringComparison.OrdinalIgnoreCase))
                        result.AddError($"Plik {value.SourceFilePath} nie ma prawidłowego rozszerzenia");
                }

                if (!System.IO.Directory.Exists(value.DestinationFolder))
                    result.AddError($"Folder {value.DestinationFolder} nie istnieje lub nie ma do niego dostępu");
            }
			catch (Exception)
			{
				result.AddError("Wystąpił nieoczekiwany błąd walidacji.");
			}
            return result;
        }
    }
}
