using System;

namespace day_8.ClassFolder;

public class Rectangle
{
    private double length;
    private double width;

    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public double Length
    {
        get { return length; }
        set
        {
            if (value > 0)
            {
                length = value;
            }
        }
    }

    public double Width
    {
        get { return width; }
        set
        {
            if (value > 0)
            {
                width = value;
            }
        }
    }

    public double GetArea()
    {
        return Length * Width;
    }

    public double GetPerimeter()
    {
        return 2 * (Length + Width);
    }

}
