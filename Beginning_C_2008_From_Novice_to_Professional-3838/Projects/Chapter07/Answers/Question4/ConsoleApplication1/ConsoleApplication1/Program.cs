using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1 {
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
    interface ITriangle : IShape {
        double Base { get; set; }
        double Height { get; set; }
    }
    interface ICircle : IShape {
        double Radius { get; set; }
    }

    sealed class Square : ISquare {
        #region ISquare Members
        double _width;
        public double Width {
            get {
                return _width;
            }
            set {
                if (_width < 0.0) {
                    throw new ArgumentOutOfRangeException("cannot be negative");
                }
                _width = value;
            }
        }

        #endregion

        #region IShape Members

        public double CalculateArea() {
            return _width * _width;
        }

        #endregion
    }

    sealed class Rectangle : IRectangle {
        #region IRectangle Members
        double _width;
        public double Width {
            get {
                return _width;
            }
            set {
                if (_width < 0.0) {
                    throw new ArgumentOutOfRangeException("cannot be negative");
                }
                _width = value;
            }
        }

        double _length;
        public double Length {
            get {
                return _length;
            }
            set {
                if (_length < 0.0) {
                    throw new ArgumentOutOfRangeException("cannot be negative");
                }
                _length = value;
            }
        }

        #endregion

        #region IShape Members

        public double CalculateArea() {
            return _length * _width;
        }

        #endregion
    }

    sealed class Triangle : ITriangle {
        #region ITriangle Members
        double _base;
        public double Base {
            get {
                return _base;
            }
            set {
                if (_base < 0.0) {
                    throw new ArgumentOutOfRangeException("cannot be negative");
                }
                _base = value;
            }
        }
        double _height;
        public double Height {
            get {
                return _height;
            }
            set {
                if (_height < 0.0) {
                    throw new ArgumentOutOfRangeException("cannot be negative");
                }
                _height = value;
            }
        }

        #endregion

        #region IShape Members

        public double CalculateArea() {
            return _base * _height * 0.5;
        }

        #endregion
    }

    sealed class Circle : ICircle {
        #region ICircle Members
        double _radius;
        public double Radius {
            get {
                return _radius;
            }
            set {
                if (_radius < 0.0) {
                    throw new ArgumentOutOfRangeException("cannot be negative");
                }
                _radius = value;
            }
        }

        #endregion

        #region IShape Members

        public double CalculateArea() {
            return _radius * _radius * Math.PI;
        }

        #endregion
    }
    class Program {
        static void Main(string[] args) {
        }
    }
}
