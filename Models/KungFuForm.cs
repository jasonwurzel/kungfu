namespace Models;

public class KungFuForm
{
    public static KungFuForm Empty => new(string.Empty);

    public string Name { get; }

    public DateTimeOffset[] TrainedDates { get; }

    public KungFuForm(string name, DateTimeOffset[] trainedDates)
    {
        Name = name;
        TrainedDates = trainedDates;
    }

    public KungFuForm(string name)
    {
        Name = name;
        TrainedDates = Array.Empty<DateTimeOffset>();
    }
}