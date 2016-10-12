using System;

namespace Inheritance {
    abstract class Shape {
        double _width;
        public double Width {
            get {
                return _width;
            }
            set {
                _width = value;
            }
        }
        public abstract double CalculateArea();
    }
    class Square : Shape {
        public override double CalculateArea() {
            return Width * Width;
        }
    }
    class Rectangle : Square {
        double _length;
        public double Length {
            get {
                return _length;
            }
            set {
                _length = value;
            }
        }

        public new double CalculateArea() {
            return Width * _length;
        }
    }
    class TestShape {
        public static void TestRectangle() {
            Rectangle cls = new Rectangle();
            cls.Width = 20;
            cls.Length = 30;
            double area = cls.CalculateArea();
            Console.WriteLine("Area is " + area);
        }
        public static void TestSquare() {
            Rectangle rectangle = new Rectangle();
            rectangle.Length = 30;
            Square square = rectangle;
            square.Width = 10;
            double area = square.CalculateArea();
            Console.WriteLine("Square Area is " + square.CalculateArea() +
                " Rectangle Area is " + rectangle.CalculateArea());
        }
        public static void RunAll() {
            TestRectangle();
            TestSquare();
        }
    }
}

namespace Components {
    interface IShape {
        double CalculateArea();
    }

    interface ISquare : IShape {
        double Width { get; set; }
    }

    interface IRectangle : IShape {
        double Width { get; set; }
        double Length { get; set; }
    }
}