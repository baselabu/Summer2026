using System;
using day_10.InterfacesFolder;

namespace day_10;

public class PrintShapeMethod
{
    public static void PrintShapeInfo(IShape shape)
    {
        System.Console.WriteLine($"The Area of your shape is : {shape.Area()}, and the Perimeter is : {shape.Perimeter()}");
    }

}
