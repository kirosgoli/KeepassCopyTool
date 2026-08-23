using Autofac;
using KeepassCopyTool.Application.Commands;
using KeepassCopyTool.Application.Queries;

namespace KeepassCopyTool.Application.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static void RegisterApplicationServices(this ContainerBuilder builder)
        {
            builder.RegisterType<BackupSettingsQuery>()
                   .As<IBackupSettingsQuery>()
                   .SingleInstance();

            builder.RegisterType<BackupSettingsCommand>()
                   .As<IBackupSettingsCommand>();
        }
    }
}
