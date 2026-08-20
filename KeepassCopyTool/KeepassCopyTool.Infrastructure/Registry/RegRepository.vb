Option Strict On
Option Explicit On
Imports KeepassCopyTool.Core.Interfaces

Namespace Registry
    Class RegRepository
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

#Region "LastUpdateDate"
        Public Function GetLastUpdateDate() As String Implements IRegRepository.GetLastUpdateDate
            Return GetRegValue("LastUpdateDate")
        End Function

        Public Sub SetLastUpdateDate(dateTime As Date) Implements IRegRepository.SetLastUpdateDate
            SetRegValue("LastUpdateDate", dateTime.ToString("s"))
        End Sub
#End Region

#Region "BackupInterval"
        Public Function GetBackupInterval() As Integer Implements IRegRepository.GetBackupInterval
            Dim backupInterval As Integer
            Integer.TryParse(GetRegValue("BackupInterval"), backupInterval)
            Return backupInterval
        End Function

        Public Sub SetBackupInterval(backupInterval As Integer) Implements IRegRepository.SetBackupInterval
            SetRegValue("BackupInterval", backupInterval.ToString())
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

