using System;

namespace QuadrilateralPerimeter
{
    struct Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    struct Quadrilateral
    {
        public Point A;
        public Point B;
        public Point C;
        public Point D;

        public Quadrilateral(Point a, Point b, Point c, Point d)
        {
            this.A = a;
            this.B = b;
            this.C = c;
            this.D = d;
        }
    }

    class Program
    {
        static void Main()
        {
            Quadrilateral quadrilateral = new Quadrilateral(ReadPoint(), ReadPoint(), ReadPoint(), ReadPoint());
            Console.WriteLine(CalculatePerimeter(quadrilateral));
            Console.Read();
        }

        static double CalculatePerimeter(Quadrilateral quadrilateral)
        {
            double a1 = (quadrilateral.A.X - quadrilateral.B.X) * (quadrilateral.A.X - quadrilateral.B.X);
            double a2 = (quadrilateral.A.Y - quadrilateral.B.Y) * (quadrilateral.A.Y - quadrilateral.B.Y);
            double line1 = Math.Sqrt(a1 + a2);
            double b1 = (quadrilateral.B.X - quadrilateral.C.X) * (quadrilateral.B.X - quadrilateral.C.X);
            double b2 = (quadrilateral.B.Y - quadrilateral.C.Y) * (quadrilateral.B.Y - quadrilateral.C.Y);
            double line2 = Math.Sqrt(b1 + b2);
            double c1 = (quadrilateral.C.X - quadrilateral.D.X) * (quadrilateral.C.X - quadrilateral.D.X);
            double c2 = (quadrilateral.C.Y - quadrilateral.D.Y) * (quadrilateral.C.Y - quadrilateral.D.Y);
            double line3 = Math.Sqrt(c1 + c2);
            double d1 = (quadrilateral.D.X - quadrilateral.A.X) * (quadrilateral.D.X - quadrilateral.A.X);
            double d2 = (quadrilateral.D.Y - quadrilateral.A.Y) * (quadrilateral.D.Y - quadrilateral.A.Y);
            double line4 = Math.Sqrt(d1 + d2);
            return line1 + line2 + line3 + line4;
        }

        static Point ReadPoint()
        {
            string[] point = Console.ReadLine().Split(' ');
            return new Point(Convert.ToDouble(point[0]), Convert.ToDouble(point[1]));
        }
    }
}
