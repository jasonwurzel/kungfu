using AppInitWpf;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            // for brevity, just call the DI init here
            ViewModel = CompositionRoot.Create();
        }
    }
}
