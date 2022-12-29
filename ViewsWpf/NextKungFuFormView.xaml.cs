using System.Reactive.Linq;
using ReactiveUI;

namespace ViewsWpf;

public partial class NextKungFuFormView
{
    public NextKungFuFormView()
    {
        InitializeComponent();

        this.WhenAnyValue(x => x.ViewModel).Do(model => {}).BindTo(this, x => x.DataContext);
    }
}