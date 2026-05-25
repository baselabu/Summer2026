using System;
using System.Formats.Asn1;

namespace day_9.ClassesFolder;

public abstract class Shape
{
    public abstract void Area(); // other subclasses must implement this method

}

public class Circle : Shape // inherited from Shape base
{
    private double raduis; // private this variable only accesed in this class 

    public double Raduis
    {
        get
        {
            return raduis;
        }
        set
        {
            if(value >= 0)
            {
                raduis = value;
            }
            else
            {
                System.Console.WriteLine("raduis cant not be negative!");
            }
        }
    }
    public Circle(double raduis)
    {
        Raduis = raduis;
        System.Console.WriteLine($"the raduis of your Circle is: {raduis}");
    }
    public override void Area()
    {
        System.Console.WriteLine($" the Area of your Circle is: {3.14*raduis*raduis}"); 
    }
}
