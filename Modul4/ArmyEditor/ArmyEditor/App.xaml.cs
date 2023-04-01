using ArmyEditor.Logic;
using ArmyEditor.Services;
using ArmyEditor.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Windows;

namespace ArmyEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }


        public App()
        {
            Ioc.Default.ConfigureServices(
                 new ServiceCollection()
                 .AddSingleton<IArmyLogic, ArmyLogic>()
                 .AddSingleton<ITrooperEditorService, TrooperEditorViaWindow>()
                 .AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
                 .BuildServiceProvider()
                 );
            Services = ConfigureServices();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IArmyLogic, ArmyLogic>();
            services.AddSingleton<ITrooperEditorService, TrooperEditorViaWindow>();
            services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);
            services.AddTransient<MainWindowViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
