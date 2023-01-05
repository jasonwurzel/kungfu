using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Services;
using ViewModels;

namespace AppInitWpf
{
    public static class CompositionRoot
    {
        /// <summary>
        /// After years of using "framework assisted" DI, lets try the "pure DI" pattern, as suggested by Mark Seemann.
        /// Of course, for this problem, a DI container would be overblown anyway.
        /// </summary>
        /// <returns></returns>
        public static async Task<IMainWindowViewModel> Create()
        {
            // Singletons
            var localRepository = new LocalJsonRepository();
            var kungFuForms = await localRepository.GetKungFuFormsAsync();
            var kungfuRandomizer = new KungFuRandomizer(kungFuForms.ToArray());

            IMainWindowViewModel root = new MainWindowViewModel(new NextKungFuFormViewModel(kungfuRandomizer));

            return root;
        }
    }
}
