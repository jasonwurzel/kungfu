using AppInitWpf;
using System.Windows;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private async void App_OnStartup(object sender, StartupEventArgs e)
        {
            // of course here would be space to initialize some notification service,
            // and call the Run method the observable way, thus being able to notify the user of any exceptions during initialization.
            var rootModel = await Bootstrapper.Run();
            MainWindow main = new MainWindow
            {
                ViewModel = rootModel,
                DataContext = rootModel
            };
            main.Show();
        }
    }
}
