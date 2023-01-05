using System.Threading.Tasks;
using Interfaces;

namespace AppInitWpf
{
    public static class Bootstrapper
    {
        public static async Task<IMainWindowViewModel> Run()
        {
            ReactiveUiInit.Init();
            var root = await CompositionRoot.Create();
            return root;
        }
    }
}
