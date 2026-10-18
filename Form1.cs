using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab1_OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Создаём точку
            Point p = new Point(3, 4);
            MessageBox.Show(p.GetInfo());

            // Цветная точка
            ColoredPoint cp = new ColoredPoint(10, 20, "Red");
            MessageBox.Show(cp.GetInfo());

            // Линия
            Line line = new Line(new Point(0, 0), new Point(2, 0));
            MessageBox.Show(line.GetInfo());   // вызвали у объекта line

            line.Rotate(90);                   // поворот у объекта line
            MessageBox.Show("После поворота на 90°: " + line.GetInfo());

            // Цветная линия
            LineWithColor lc = new LineWithColor(new Point(1, 1), new Point(4, 5), "Blue");
            MessageBox.Show(lc.GetInfo());

            // Многоугольник (треугольник)
            List<Point> points = new List<Point>
            {
                new Point(0, 0),
                new Point(2, 0),
                new Point(1, 2)
            };
            PolyLine poly = new PolyLine(points);
            MessageBox.Show(poly.GetInfo());
            poly.Scale(2.0);
            MessageBox.Show("После масштабирования x2: " + poly.GetInfo());
        }
    }
}