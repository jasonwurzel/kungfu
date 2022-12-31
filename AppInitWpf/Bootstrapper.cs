using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace AppInitWpf
{
    public class Bootstrapper
    {
        public static IMainWindowViewModel Run()
        {
            ReactiveUiInit.Init();
            var root = CompositionRoot.Create();
            return root;
        }
    }
}
