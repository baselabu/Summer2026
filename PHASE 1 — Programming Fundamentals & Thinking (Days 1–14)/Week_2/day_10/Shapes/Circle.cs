using System;
using day_10.InterfacesFolder;

namespace day_10.Shapes;

public class Circle : IShape
{
    public double Raduis;
    public Circle(double raduis) // Constructer when creating object Cricle has to have a raduis
    {
        Raduis = raduis;
    }
    public double Area()
    {
        return 3.14 *Raduis*Raduis;
    }
    public double Perimeter()
    {
        return 2*3.14*Raduis;
    }

}
