using System;
using System.Collections.Generic;
using System.Text;

namespace TorneoDeportes.COMMON.Entidades
{
    public class Grafica
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Grafica(double x, double y)
        {
            X = x;
            Y = y; ;
        }
        public override string ToString()
        {
            return string.Format("({0},{1})", X, Y);
        }
    }
}
