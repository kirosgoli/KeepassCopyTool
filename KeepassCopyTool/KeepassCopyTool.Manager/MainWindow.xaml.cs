using System.Diagnostics.Eventing.Reader;
using System.Windows;
using KeepassCopyTool.Application.DTOs;
using KeepassCopyTool.Manager.Models;
using Microsoft.Win32;
using Forms = System.Windows.Forms;

namespace KeepassCopyTool.Manager
{
    public partial class MainWindow : Window
    {
        private readonly KeepassCopyTool.Application.Queries.IBackupSettingsQuery _backupSettingsQuery;
        private readonly KeepassCopyTool.Application.Commands.IBackupSettingsCommand _backupSettingsCommand;
        private readonly KeepassCopyTool.Application.Validators.IBackupSettingsValidator _backupSettingsValidator;
        private readonly System.Collections.Generic.List<BackupIntervalOption> _backupIntervalOptions;

        public MainWindow(KeepassCopyTool.Application.Queries.IBackupSettingsQuery backupSettingsQuery,
            KeepassCopyTool.Application.Commands.IBackupSettingsCommand backupSettingsCommand,
            Application.Validators.IBackupSettingsValidator backupSettingsValidator)
        {
            _backupSettingsQuery = backupSettingsQuery;
            _backupSettingsCommand = backupSettingsCommand;
            _backupSettingsValidator = backupSettingsValidator;
            InitializeComponent();

            _backupIntervalOptions = BackupIntervalOption.Factory.Defaults;
            BackupIntervalHoursComboBox.ItemsSource = _backupIntervalOptions;

            LoadBackupSettings();
        }

        private void LoadBackupSettings()
        {
            var settings = _backupSettingsQuery.Execute();

            SourceFilePathTextBox.Text = settings.SourceFilePath;
            DestinationFolderTextBox.Text = settings.DestinationFolder;
            BackupIntervalOption option = _backupIntervalOptions.FindOptionByHours(settings.BackupIntervalHours);
            if (option != null)
            {
                BackupIntervalHoursComboBox.SelectedItem = option;
                CustomBackupIntervalHoursTextBox.Text = string.Empty;
            }
            else
            {
                BackupIntervalHoursComboBox.SelectedItem = _backupIntervalOptions.GetCustomOption();
                CustomBackupIntervalHoursTextBox.Text = settings.BackupIntervalHours > 0
                    ? settings.BackupIntervalHours.ToString()
                    : string.Empty;
            }
            LastSettingsUpdateDateTextBox.Text = settings.LastSettingsUpdateDate;
            LastRunDateTextBox.Text = settings.LastRunDate;
        }

        private void BackupIntervalHoursComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            BackupIntervalOption selectedOption = BackupIntervalHoursComboBox.SelectedItem as BackupIntervalOption;
            CustomBackupIntervalPanel.Visibility = selectedOption != null && selectedOption.IsCustom
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void BrowseSourceFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "KeePass database (*.kdbx)|*.kdbx|All files (*.*)|*.*",
                Title = "Wybierz plik bazy KeePass"
            };

            if (dialog.ShowDialog() == true)
            {
                SourceFilePathTextBox.Text = dialog.FileName;
            }
        }

        private void BrowseDestinationFolder_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new Forms.FolderBrowserDialog())
            {
                dialog.Description = "Wybierz folder docelowy kopii";
                dialog.ShowNewFolderButton = true;

                if (dialog.ShowDialog() == Forms.DialogResult.OK)
                {
                    DestinationFolderTextBox.Text = dialog.SelectedPath;
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            BackupIntervalOption selectedOption = BackupIntervalHoursComboBox.SelectedItem as BackupIntervalOption;
            int backupIntervalHours = 0;

            if (selectedOption != null)
            {
                if (selectedOption.IsCustom)
                {
                    if (!int.TryParse(CustomBackupIntervalHoursTextBox.Text, out backupIntervalHours))
                    {
                        MessageBox.Show("Podaj liczbę godzin dla niestandardowego interwału.");
                        return;
                    }
                }
                else
                {
                    backupIntervalHours = selectedOption.Hours;
                }
            }

            BackupSettingsDTO currentSettings = new BackupSettingsDTO()
            {
                DestinationFolder = DestinationFolderTextBox.Text,
                SourceFilePath = SourceFilePathTextBox.Text,
                BackupIntervalHours = backupIntervalHours
            };

            var validationResult = _backupSettingsValidator.Validate(currentSettings);
            if (validationResult != null && !validationResult.IsValid())
            {
                MessageBox.Show(validationResult.Errors[0]);
                return;
            }


            if (_backupSettingsCommand.Execute(currentSettings))
            {
                LoadBackupSettings();
                MessageBox.Show("Udany zapis");
            }
            else
                MessageBox.Show("Niespodziewany błąd");
        }
    }
}
