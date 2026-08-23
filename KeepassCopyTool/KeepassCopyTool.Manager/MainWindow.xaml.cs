using System.Diagnostics.Eventing.Reader;
using System.Windows;
using KeepassCopyTool.Application.DTOs;
using Microsoft.Win32;
using Forms = System.Windows.Forms;

namespace KeepassCopyTool.Manager
{
    public partial class MainWindow : Window
    {
        private readonly KeepassCopyTool.Application.Queries.IBackupSettingsQuery _backupSettingsQuery;
        private readonly KeepassCopyTool.Application.Commands.IBackupSettingsCommand _backupSettingsCommand;

        public MainWindow(KeepassCopyTool.Application.Queries.IBackupSettingsQuery backupSettingsQuery,
            KeepassCopyTool.Application.Commands.IBackupSettingsCommand backupSettingsCommand)
        {
            _backupSettingsQuery = backupSettingsQuery;
            _backupSettingsCommand = backupSettingsCommand;
            InitializeComponent();

            LoadBackupSettings();
        }

        private void LoadBackupSettings()
        {
            var settings = _backupSettingsQuery.Execute();

            SourceFilePathTextBox.Text = settings.SourceFilePath;
            DestinationFolderTextBox.Text = settings.DestinationFolder;
            BackupIntervalTextBox.Text = settings.BackupInterval.ToString();
            LastSettingsUpdateDateTextBox.Text = settings.LastSettingsUpdateDate;
            LastRunDateTextBox.Text = settings.LastRunDate;
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
            int backupInterval;
            if (!int.TryParse(BackupIntervalTextBox.Text, out backupInterval))
            {
                MessageBox.Show("Interwał kopii musi być liczbą całkowitą.");
                return;
            }

            BackupSettingsDTO currentSettings = new BackupSettingsDTO()
            {
                DestinationFolder = DestinationFolderTextBox.Text,
                SourceFilePath = SourceFilePathTextBox.Text,
                BackupInterval = backupInterval
            };

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
