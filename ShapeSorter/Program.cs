using System;
using System.Collections.Generic;
using System.Linq;
namespace ShapeSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Shapes!");
            List<IShape> shapes = new List<IShape>() {

                new Circle(4),
                new Rectangle(3.2,5.9),
                new Square(3),
                new Rectangle(2,3),
                new Circle(3),




            };
            foreach (IShape sh in shapes) {


                Console.WriteLine($"shape with area{sh.Area}");


            }
            IEnumerable<IShape> filteredshape = shapes.Where(shape => shape.Area>50);
            Console.WriteLine("Sahpes with A > 50");

            foreach (IShape sh in filteredshape)
            {
                Console.WriteLine($"shape with area{sh.Area}");

            }

            Console.WriteLine("------------------------------------------------------------------");

            IEnumerable<Circle> circles = shapes.OfType<Circle>();
            foreach (Circle circle in circles)
            {

                Console.WriteLine($"circles with raduis {circle.Radius } and area {circle.Area}"); 

            }
            Console.WriteLine("------------------------------------------------------------------");
            IEnumerable<Circle> filteredcircles = circles.Where(Circle => Circle.Area < 70);
            Console.WriteLine("Sahpes with A <70");

            foreach (IShape sh in filteredcircles)
            {
                Console.WriteLine($"shape with area{sh.Area}");

            }
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("combined shapes");
            foreach (Circle circle in shapes.OfType<Circle>().Where(c=> c.Radius >3.5)) {

                Console.WriteLine($"circles with raduis {circle.Radius } and area {circle.Area}");
            }
            Console.WriteLine("------------------------------------------------------------------");

            Console.WriteLine("Group BY type");

            var groupedshapes = shapes.GroupBy(shape => shape.GetType());
            foreach (var group in groupedshapes)
            {

                Console.WriteLine($"shapes of types {group.Key}");
                foreach (IShape shape in group)
                {
                    Console.WriteLine($"shape of area {shape.Area}");

                }


            }
            Console.WriteLine("------------------------------------------------------------------");

            var groupedbyArea = shapes.GroupBy(shape => shape.Area % 2 == 0);

            foreach (var group in groupedbyArea) {

                Console.WriteLine(group.Key ? "even " : "odd");

                foreach (IShape shape in group)
                {
                    Console.WriteLine($"shape of area {shape.Area}");

                }


            }
            Console.WriteLine("------------------------------------------------------------------");
            var max = shapes.Max(shape => shape.Area);
            Console.WriteLine($"Maximum Area is {max}");

            Console.WriteLine("------------------------------------------------------------------");
            var totalarea = shapes.Sum(shape => shape.Area);
            Console.WriteLine($"Maximum Area is {totalarea}");



            Console.ReadKey();
        }
    }
}
