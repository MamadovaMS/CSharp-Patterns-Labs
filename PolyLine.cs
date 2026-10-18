using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1_OOP
{
    public class PolyLine
    {
        public List<Point> Vertices { get; set; }

        public PolyLine()
        {
            Vertices = new List<Point>();
        }

        public PolyLine(List<Point> vertices)
        {
            Vertices = vertices;
        }

        public void Scale(double factor)
        {
            if (Vertices == null || Vertices.Count == 0)
                return;

            double centerX = Vertices.Average(p => p.X);
            double centerY = Vertices.Average(p => p.Y);

            for (int i = 0; i < Vertices.Count; i++)
            {
                double dx = Vertices[i].X - centerX;
                double dy = Vertices[i].Y - centerY;
                Vertices[i].X = centerX + dx * factor;
                Vertices[i].Y = centerY + dy * factor;
            }
        }

        public string GetInfo()
        {
            return "Многоугольник с точками: " + string.Join("; ", Vertices.Select(p => p.GetInfo()));
        }
    }
}