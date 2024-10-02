using System;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows.Controls;
using Models;
using ReactiveUI;

namespace ViewsWpf;

public partial class NextKungFuFormView
{
    public NextKungFuFormView()
    {
        InitializeComponent();

        this.WhenAnyValue(x => x.ViewModel).BindTo(this, x => x.DataContext);
        this.WhenAnyValue(v => v.ViewModel.NextForm)
            .Do(form =>
            {
                if (form == null)
                    TheDaysTrainedTextBlock.Text = String.Empty;
                else
                    TheDaysTrainedTextBlock.Text = string.Format(Strings.NextKungFuFormView_NextKungFuFormView_DaysTrained, form.TrainedDates.Count);
                string lastDateString;
                if (form == null || !form.TrainedDates.Any())
                    lastDateString = String.Empty;
                else 
                {
                    var lastDate = form.TrainedDates.LastOrDefault();
                    lastDateString = lastDate == default ? String.Empty : string.Format(Strings.NextKungFuFormView_NextKungFuFormView_LastTrainedOn, lastDate.ToString("D"));
                }

                TheLastTrainedTextBlock.Text = lastDateString;
            })
            .Subscribe();

        this.WhenActivated((Action<CompositeDisposable>)(_ => ViewModel.GetNextForm.Execute().Subscribe()));
    }

    private void TheFormsListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count == 0)
            return;
        
        var item = e.AddedItems[0];
        
        if (item == null) return;
        
        TheFormsListBox.ScrollIntoView(item);
    }
}