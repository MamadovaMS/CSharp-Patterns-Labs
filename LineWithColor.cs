namespace Lab1_OOP
{
    public class LineWithColor : Line
    {
        public string Color { get; set; }

        public LineWithColor() : base()
        {
            Color = "Black";
        }

        public LineWithColor(Point start, Point end, string color) : base(start, end)
        {
            Color = color;
        }

        public override string GetInfo()
        {
            return $"Цветная линия {Color}: {Start.GetInfo()} → {End.GetInfo()}";
        }
    }
}