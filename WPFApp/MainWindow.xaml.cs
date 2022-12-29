using AppInitWpf;
using ViewModels;

namespace WPFApp
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            // for brevity, just call the DI init here
            ViewModel = CompositionRoot.Create();
            DataContext = ViewModel;
            TheNextKungFuFormView.ViewModel = ViewModel.NextKungFuFormViewModel as NextKungFuFormViewModel;
        }
    }
}
