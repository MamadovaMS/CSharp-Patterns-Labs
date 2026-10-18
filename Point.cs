using System;

namespace Lab1_OOP
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        // Конструктор по умолчанию
        public Point()
        {
            X = 0;
            Y = 0;
        }

        // Конструктор с параметрами
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        // Виртуальный метод для вывода
        public virtual string GetInfo()
        {
            return $"Точка ({X}, {Y})";
        }
    }
}