using day_10;
using day_10.InterfacesFolder;
using day_10.Shapes;

List<IShape> shapes = new List<IShape>{
    new Circle(12),
    new Triangle(3,4,5,6),
    new Rectangle(10, 5)
};

foreach(IShape shape in shapes)
{
    PrintShapeMethod.PrintShapeInfo(shape);
}