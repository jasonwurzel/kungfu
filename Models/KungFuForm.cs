using System.Collections.ObjectModel;

namespace Models;

public class KungFuForm
{
    public static KungFuForm Empty => new(string.Empty);

    public string Name { get; }

    public ObservableCollection<DateTimeOffset> TrainedDates { get; }
    
    public KungFuForm(string name, DateTimeOffset[] trainedDates)
    {
        Name = name;
        TrainedDates = new ObservableCollection<DateTimeOffset>(trainedDates);
    }

    public KungFuForm(string name)
    {
        Name = name;
        TrainedDates = new ObservableCollection<DateTimeOffset>();
    }
}