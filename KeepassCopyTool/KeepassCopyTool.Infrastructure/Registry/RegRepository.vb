Option Strict On
Option Explicit On
Imports KeepassCopyTool.Core.Interfaces

Namespace Registry
    Class RegRepository
        Implements IRegRepository

        Private Function GetRegValue(key As String, Optional defaultValue As String = "") As String

        End Function

        Public Sub SetLastUpdateDate(dateTime As Date) Implements IRegRepository.SetLastUpdateDate
            Throw New NotImplementedException()
        End Sub

        Public Sub SetBackupInterval(backupInterval As Integer) Implements IRegRepository.SetBackupInterval
            Throw New NotImplementedException()
        End Sub

        Public Sub SetDestinationFolder(destinationFolder As String) Implements IRegRepository.SetDestinationFolder
            Throw New NotImplementedException()
        End Sub

        Public Sub SetSourceFilePath(sourceFilePath As String) Implements IRegRepository.SetSourceFilePath
            Throw New NotImplementedException()
        End Sub

        Public Function GetLastUpdateDate() As String Implements IRegRepository.GetLastUpdateDate
            Throw New NotImplementedException()
        End Function

        Public Function GetBackupInterval() As Integer Implements IRegRepository.GetBackupInterval
            Throw New NotImplementedException()
        End Function

        Public Function GetDestinationFolder() As String Implements IRegRepository.GetDestinationFolder
            Throw New NotImplementedException()
        End Function

        Public Function GetSourceFilePath() As String Implements IRegRepository.GetSourceFilePath
            Throw New NotImplementedException()
        End Function
    End Class

End Namespace

