using System;
using day_10.InterfacesFolder;

namespace day_10.Shapes;

public class Rectangle : IShape
{
    public double L,W;
    public Rectangle(double l, double w)
    {
        L = l;
        W = w;
    }
    public double Area()
    {
        return L * W;
    }
    public double Perimeter()
    {
        return 2*(L+W);
    }

}
