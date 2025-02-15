namespace Models;

public class KungFuForm
{
    public static KungFuForm Empty => new(string.Empty);

    public string Name { get; }

    public List<DateTimeOffset> TrainedDates { get; }
    
    public int CountTrained => TrainedDates.Count;

    public KungFuForm(string name, DateTimeOffset[] trainedDates)
    {
        Name = name;
        TrainedDates = new List<DateTimeOffset>(trainedDates);
    }

    public KungFuForm(string name)
    {
        Name = name;
        TrainedDates = new List<DateTimeOffset>();
    }
}