using AppInitWpf;
using ViewModels;

namespace WPFApp
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            // for brevity, just call the DI init here
            ViewModel = Bootstrapper.Run();
            DataContext = ViewModel;

            InitializeComponent();

            TheNextKungFuFormView.ViewModel = ViewModel.NextKungFuFormViewModel as NextKungFuFormViewModel;
        }
    }
}
