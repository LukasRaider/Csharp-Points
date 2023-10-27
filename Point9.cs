using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point9;
class BadRadiusException : Exception
{
    public BadRadiusException() { }
    public BadRadiusException(string message) : base(message) { }
}
interface IPerimeter
{          //nededi z tridy Shape, ale musi mit metodu Perimeter = interface
    double perimeter();
}
class Point
{
    private double x, y;
    #region GettersAndSetters
    public double getX()
    {
        return this.x;
    }

    public double getY()
    {
        return this.y;
    }

    public void setY(double y)
    {
        this.y = y;
    }
    #endregion

    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }
    public override string ToString()
    {
        return ($"{Math.Round(getX(), 2)}; {Math.Round(getY(), 2)}");
    }
}
abstract class Shape
{          //slo by i tady implementovat interface a nechat ostatni tridy dedit oboje 
    private Point center;
    public Shape() { }
    public Point Center
    {
        get { return center; }
        set { Center = value; }
    }
    #region GettersAndSetters
    public Point getCenter()
    {
        return this.center;
    }

    public void setCenter(Point center)
    {
        this.center = center;
    }
    #endregion
    public Shape(Point center)/*:this(x,y)*/
    {
        this.center = center;
    }
    public Shape(double x, double y) : this(new Point(x, y))
    {
    }
    public override string ToString()
    {
        return base.ToString();
    }
    public virtual void writeInfo()
    {
        Console.WriteLine($"Stred tvaru je v bode {getCenter()}");
    }

    //public abstract double perimeter();
    public abstract double area();
}
class Circle : Shape, IPerimeter
{
    public int r;
    public Circle() { }
    public Circle(Point center, int r) : base(center)
    {
        if (r < 0)
        {
            throw new BadRadiusException("Polomer nemuze byt zaporny!");
        }
        this.r = r;
    }
    public Circle(double x, double y, int r) : base(new Point(x, y))
    {
        this.r = r;
    }
    public Circle(int r) : this(new Point(0, 0), r)
    {
        if (r < 0)
        {
            throw new ArgumentOutOfRangeException("Polomer nemuze byt zaporny!");
        }
        this.r = r;
    }
    public override string ToString()
    {
        return $"Kruh ma polomer {r} a stred v bode {getCenter()}";
    }
    public override void writeInfo()
    {
        Console.WriteLine(string.Format($"Kruh ma polomer {{0}}, stred v bode {{1}}, obvod {{2:f}} a obsah {{3:f}}", r, getCenter().ToString(), perimeter(), area()));
    }
    public double perimeter()
    {
        return 2 * Math.PI * r;
    }
    public override double area()
    {
        return Math.PI * r * r;
    }

}
class Rectangle : Shape, IPerimeter
{
    public Point center;
    public int a, b;
    public Rectangle(Point center, int a, int b) : base(center)
    {
        this.center = center;
        if (a < 0 || b < 0)
        {
            throw new ArgumentOutOfRangeException("Strany nemohou byt zaporne!");
        }
        this.a = a;
        this.b = b;
    }
    public Rectangle(Point center, int a) : this(center, a, a)
    {
        this.center = center;
        this.a = this.b = a;
    }
    public Rectangle(int a) : this(new Point(0, 0), a, a)
    {
        this.a = this.b = a;
    }
    public override string ToString()
    {
        return $"Ctyruhelnik ma stranu A o delce {a}, stranu B o delce {b} a stred v bode {getCenter().ToString()}";
    }
    public override void writeInfo()
    {
        Console.WriteLine(string.Format($"Ctyruhelnik ma stranu A o delce {{0}}, stranu B o delce {{1}}, stred v bode {{2}}, obvod {{3:f}} a obsah {{4:f}}", a, b, getCenter().ToString(), perimeter(), area()));
        if (a != b) { Console.WriteLine("Je to obdelnik."); }
        else { Console.WriteLine("Je to ctverec"); }
    }
    public double perimeter()
    {
        return (2 * this.a) + (2 * this.b);
    }
    public override double area()
    {
        return a * b;
    }
}
class Person : IPerimeter
{
    double weight;
    double height;
    public Person(double height, double weight)
    {
        this.height = height;
        this.weight = weight;
    }
    public double perimeter()
    {
        return (height / weight) * 2.54;
    }
}
class Cylinder : Circle
{                //dedicnost
    int height;
    public Cylinder(Point center, int r, int height) : base(center, r)
    {
        this.height = height;
    }
    public double surface()
    {
        return 2 * Math.PI * r * r + height * 2 * Math.PI * r;
    }
    public double volume()
    {
        return Math.PI * r * r * height;
    }
    public override string ToString()
    {
        return $"Povrch válce  je {this.surface(),0:f} a objem je {this.volume(),0:f}";
    }
}


class TestPoint
{
    public static void Mainx()
    {

        Point p1 = new Point(3.456, 2.765);


        Cylinder v1 = new Cylinder(p1, 4, 10);
        Console.WriteLine(v1.surface().ToString());
        Console.WriteLine(v1.volume().ToString());
        Console.WriteLine(v1.ToString());

        Console.WriteLine("Konec!");
    }
}
