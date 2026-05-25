using System;
using System.Runtime.CompilerServices;
using day_10.InterfacesFolder;

namespace day_10.Shapes;

public class Triangle : IShape
{
    public double A, B, C, H;
    public Triangle(double a,double b, double c, double h)
    {
        A = a;
        B = b;
        C = c;
        H = h;
        
    }

    public double Area()
    {
        return 0.5*B*H;
        
    }
    public double Perimeter()
    {
        return A+B+C;
    }

}
