var rectangle1 = new Rectangle(5, 10);
Console.WriteLine($"Width: {rectangle1.Width}");
Console.WriteLine($"Height: {rectangle1.GetHeight()}");
Console.WriteLine($"Circumference: {rectangle1.CalculateCircumference()}");
Console.WriteLine($"Area: {rectangle1.CalculateArea()}");


class Rectangle
{
    private int _width = 3;
    public int Width
    {
        get => _width;
        private set => _width = value;
    }
    private int _height = 4;

    public Rectangle(int width, int height)
    {
        _width = width;
        _height = height;
    }

    public int GetHeight() => _height;

    public void SetHeight(int value)
    {
        if (value > 0)
        {
            _height = value;
        }
    }

    public int CalculateCircumference() => 2 * (Width + _height);

    public int CalculateArea() => Width * _height;
}
