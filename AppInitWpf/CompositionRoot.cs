using System.Linq;
using Interfaces;
using Services;
using ViewModels;

namespace AppInitWpf
{
    public static class CompositionRoot
    {
        /// <summary>
        /// After years of using "framework assisted" DI, lets try the "pure DI" pattern, as suggested by Mark Seemann
        /// </summary>
        /// <returns></returns>
        public static IMainWindowViewModel Create()
        {
            // Singletons
            var localRepository = new LocalRepository();
            var kungfuRandomizer = new KungfuRandomizer(localRepository.GetKungFuForms().ToArray());

            IMainWindowViewModel root = new MainWindowViewModel(new NextKungFuFormViewModel(kungfuRandomizer));

            return root;
        }
    }
}
