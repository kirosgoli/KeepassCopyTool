using System.Windows;
using Microsoft.Win32;
using Forms = System.Windows.Forms;

namespace KeepassCopyTool.Manager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
    }
}
