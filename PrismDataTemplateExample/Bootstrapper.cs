using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using System.Windows;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.MefExtensions;
using PrismDataTemplateExample.Models;
using PrismDataTemplateExample.Views;

namespace PrismDataTemplateExample
{
    public class Bootstrapper : MefBootstrapper
    {
        #region Override members

        public override void Run(bool runWithDefaultConfiguration)
        {
            try
            {
                base.Run(runWithDefaultConfiguration);
            }
            catch (Exception e)
            {
                var message = string.Format("Application failed to start. Reason: {0}", e);
                Logger.Log(message, Category.Exception, Priority.High);
                Application.Current.Shutdown(1);
            }
        }

        protected override ILoggerFacade CreateLogger()
        {
            return LoggerFactory.CreateLogger();
        }

        protected override DependencyObject CreateShell()
        {
            return Container.GetExportedValue<ShellView>();
        }

        protected override void ConfigureAggregateCatalog()
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var executingAssemblyDirectory = Path.GetDirectoryName(executingAssembly.Location);

            if (string.IsNullOrEmpty(executingAssemblyDirectory))
            {
                var error = string.Format("Can't determine startup directory for {0} assembly",
                                          executingAssembly.FullName);
                throw new ApplicationException(error);
            }
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(executingAssembly));
            var modulesPathMask = executingAssembly.GetName().Name + ".Module.*.dll";
            AggregateCatalog.Catalogs.Add(new DirectoryCatalog(executingAssemblyDirectory, modulesPathMask));
        }

        protected override void RegisterBootstrapperProvidedTypes()
        {
            base.RegisterBootstrapperProvidedTypes();

            try
            {
                //Extend container with additional types
                Container.ComposeExportedValue<ICompositionService>(Container);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Cannot register bootstrapper provided types", e);
            }
        }

        protected override void InitializeShell()
        {
            var shell = ((Window)Shell);
            shell.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            shell.Show();

            var window = Window.GetWindow(Shell);
            if (window == null) throw new InvalidOperationException("Native WPF window was not created");
        }

        #endregion
    }
}