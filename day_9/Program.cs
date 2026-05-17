using day_9.ClassesFolder;
Shape CircleTest = new Circle(1);
CircleTest.Area();

List<Shape> ShapeArea = new List<Shape>();
ShapeArea.Add(new Circle(5));
foreach(Shape shape in ShapeArea)
{
    shape.Area();
}