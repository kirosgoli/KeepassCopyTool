Option Strict On
Option Explicit On
Imports KeepassCopyTool.Core.Interfaces

Namespace Registry
    Friend Class RegRepository
        Implements IRegRepository

        Private Const RegistrySubKeyPath As String = "Software\KeepassCopyTool"

#Region "Helpers"
        Private Function GetRegValue(key As String, Optional defaultValue As String = "") As String
            If String.IsNullOrWhiteSpace(key) Then
                Return defaultValue
            End If

            Using registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(RegistrySubKeyPath)
                If registryKey Is Nothing Then
                    Return defaultValue
                End If

                Dim rawValue As Object = registryKey.GetValue(key, defaultValue)
                If rawValue Is Nothing Then
                    Return defaultValue
                End If

                Return Convert.ToString(rawValue)
            End Using
        End Function

        Private Sub SetRegValue(key As String, value As String)
            If String.IsNullOrWhiteSpace(key) Then
                Throw New ArgumentException("Registry value name is required.", NameOf(key))
            End If

            Using registryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(RegistrySubKeyPath)
                If registryKey Is Nothing Then
                    Throw New InvalidOperationException("Could not open or create registry key: " & RegistrySubKeyPath)
                End If

                registryKey.SetValue(key, If(value, String.Empty), Microsoft.Win32.RegistryValueKind.String)
            End Using
        End Sub
#End Region

#Region "LastSettingsUpdateDate"
        Public Function GetLastSettingsUpdateDate() As String Implements IRegRepository.GetLastSettingsUpdateDate
            Return GetRegValue("LastSettingsUpdateDate")
        End Function

        Public Sub SetLastSettingsUpdateDate(dateTime As Date) Implements IRegRepository.SetLastSettingsUpdateDate
            SetRegValue("LastSettingsUpdateDate", dateTime.ToString("s"))
        End Sub
#End Region

#Region "LastRunDate"
        Public Function GetLastRunDate() As String Implements IRegRepository.GetLastRunDate
            Return GetRegValue("LastRunDate")
        End Function

        Public Sub SetLastRunDate(dateTime As Date) Implements IRegRepository.SetLastRunDate
            SetRegValue("LastRunDate", dateTime.ToString("s"))
        End Sub
#End Region

#Region "BackupIntervalHours"
        Public Function GetBackupIntervalHours() As Integer Implements IRegRepository.GetBackupIntervalHours
            Dim backupIntervalHours As Integer
            Integer.TryParse(GetRegValue("BackupIntervalHours"), backupIntervalHours)
            Return backupIntervalHours
        End Function

        Public Sub SetBackupIntervalHours(backupIntervalHours As Integer) Implements IRegRepository.SetBackupIntervalHours
            SetRegValue("BackupIntervalHours", backupIntervalHours.ToString())
        End Sub
#End Region

#Region "DestinationFolder"
        Public Function GetDestinationFolder() As String Implements IRegRepository.GetDestinationFolder
            Return GetRegValue("DestinationFolder")
        End Function

        Public Sub SetDestinationFolder(destinationFolder As String) Implements IRegRepository.SetDestinationFolder
            SetRegValue("DestinationFolder", destinationFolder)
        End Sub
#End Region

#Region "SourceFilePath"
        Public Function GetSourceFilePath() As String Implements IRegRepository.GetSourceFilePath
            Return GetRegValue("SourceFilePath")
        End Function

        Public Sub SetSourceFilePath(sourceFilePath As String) Implements IRegRepository.SetSourceFilePath
            SetRegValue("SourceFilePath", sourceFilePath)
        End Sub
#End Region
    End Class

End Namespace

