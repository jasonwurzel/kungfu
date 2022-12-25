namespace Models;

public class KungFuForm
{
    public static KungFuForm Empty => new KungFuForm(String.Empty);
    public string Name { get; }

    public KungFuForm(string name)
    {
        Name = name;
    }
}