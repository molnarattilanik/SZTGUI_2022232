using ArmyEditor.Logic;
using ArmyEditor.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Windows;

namespace ArmyEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                    .AddSingleton<IArmyLogic, ArmyLogic>()
                    .AddSingleton<ITrooperEditorService, TrooperEditorViaWindow>()
                    .AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
                    .BuildServiceProvider()
                );
        }
    }
}
