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

            KeepassCopyTool.Application.Extensions.ContainerBuilderExtensions.RegisterApplicationServices(builder);
            KeepassCopyTool.Infrastructure.InfrastructureContainerBuilderExtensions.RegisterInfrastructureServices(builder);

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
