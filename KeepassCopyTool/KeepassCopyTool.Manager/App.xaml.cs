using Autofac;
using System.Windows;

namespace KeepassCopyTool.Manager
{
    public partial class App : System.Windows.Application
    {
        private Autofac.IContainer _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var builder = new Autofac.ContainerBuilder();

            builder.RegisterType<KeepassCopyTool.Infrastructure.Registry.RegRepository>()
                   .As<KeepassCopyTool.Core.Interfaces.IRegRepository>()
                   .SingleInstance();

            builder.RegisterType<KeepassCopyTool.Application.Queries.BackupSettingsQuery>()
                   .As<KeepassCopyTool.Application.Queries.IBackupSettingsQuery>()
                   .SingleInstance();

            builder.RegisterType<KeepassCopyTool.Application.Commands.BackupSettingsCommand>()
                .As<KeepassCopyTool.Application.Commands.IBackupSettingsCommand>();

            builder.RegisterType<MainWindow>();

            _container = builder.Build();
            _container.Resolve<MainWindow>().Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _container?.Dispose();
            base.OnExit(e);
        }
    }
}
