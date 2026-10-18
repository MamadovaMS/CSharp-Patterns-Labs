namespace Lab1_OOP
{
    public class ColoredPoint : Point
    {
        public string Color { get; set; }

        public ColoredPoint() : base()
        {
            Color = "Black";
        }

        public ColoredPoint(double x, double y, string color) : base(x, y)
        {
            Color = color;
        }

        public override string GetInfo()
        {
            return $"Цветная точка ({X}, {Y}) цвет: {Color}";
        }
    }
}