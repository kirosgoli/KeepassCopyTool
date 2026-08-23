Imports System.Runtime.CompilerServices
Imports Autofac
Imports KeepassCopyTool.Core.Interfaces
Imports KeepassCopyTool.Infrastructure.Registry

Public Module InfrastructureContainerBuilderExtensions
    <Extension>
    Public Sub RegisterInfrastructureServices(builder As ContainerBuilder)
        builder.RegisterType(Of RegRepository)().As(Of IRegRepository)().SingleInstance()
    End Sub
End Module
