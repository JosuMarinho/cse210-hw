public abstract class Shape
{
    public string Color { get; set; }

    protected Shape(string color)
    {
        Color = color;
    }

    public abstract double GetArea();
}
