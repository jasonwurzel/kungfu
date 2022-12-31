﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Splat;
using DependencyResolverMixins = ReactiveUI.DependencyResolverMixins;

namespace AppInitWpf
{
    internal class ReactiveUiInit
    {
        public static void Init()
        {
            Locator.CurrentMutable.InitializeReactiveUI(RegistrationNamespace.Wpf);
        }
    }
}
