using System;

namespace Lab1_OOP
{
    public class Line
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public Line()
        {
            Start = new Point(0, 0);
            End = new Point(1, 1);
        }

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        // Поворот относительно начальной точки
        public void Rotate(double angleDegrees)
        {
            double rad = angleDegrees * Math.PI / 180.0;
            double cos = Math.Cos(rad);
            double sin = Math.Sin(rad);

            double dx = End.X - Start.X;
            double dy = End.Y - Start.Y;

            double newDx = dx * cos - dy * sin;
            double newDy = dx * sin + dy * cos;

            End.X = Start.X + newDx;
            End.Y = Start.Y + newDy;
        }

        public virtual string GetInfo()
        {
            return $"Линия от {Start.GetInfo()} до {End.GetInfo()}";
        }
    }
}