using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point4;
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
    //public Point() {
    //}
    public override string ToString()
    {
        return ($"{Math.Round(getX(), 2)}; {Math.Round(getY(), 2)}");
    }
}
abstract class Shape
{
    private Point center;
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
    public abstract double perimeter();             //
    public abstract double area();                  //
}
class Circle : Shape
{
    public int r;
    public Circle(Point center, int r) : base(center)
    {
        this.r = r;
    }
    public Circle(double x, double y, int r) : base(new Point(x, y))
    {
        this.r = r;
    }
    public Circle(int r) : this(new Point(0, 0), r)
    {
        this.r = r;
    }
    public override string ToString()
    {
        return $"Kruh ma polomer {r} a stred v bode {getCenter()}";
    }
    public override void writeInfo()
    {
        base.writeInfo();
        Console.WriteLine(($"Kruh ma polomer {r}, stred v bode {getCenter()}, obvod {perimeter():f} a obsah {area():f} \n"));
    }
    public override double perimeter()
    {
        return 2 * Math.PI * r;
    }
    public override double area()
    {
        return Math.PI * r * r;
    }

}
class Rectangle : Shape
{
    public Point center;
    public int a, b;
    public Rectangle(Point center, int a, int b) : base(center)
    {
        this.center = center;
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
        return $"Ctyruhelnik ma stranu A o delce {a}, stranu B o delce {b} a stred v bode {getCenter()}";
    }
    public override void writeInfo()
    {
        base.writeInfo();
        Console.WriteLine($"Ctyruhelnik ma stranu A o delce {a}, stranu B o delce {b}, stred v bode {getCenter()}, obvod {perimeter():f} a obsah {area():f}");
        if (a != b) { Console.WriteLine("Je to obdelnik. \n"); }
        else { Console.WriteLine("Je to ctverec. \n"); }
    }
    public override double perimeter()
    {
        return (2 * this.a) + (2 * this.b);
    }
    public override double area()
    {
        return a * b;
    }
}

class TestPoint
{
    public static void Mainx()
    {
        Point p1 = new Point(3.456, 2.765);
        Circle c1 = new Circle(3);
        Circle c2 = new Circle(4.5, 2.1, 10);
        Circle c3 = new Circle(p1, 4);
        Point p2 = new Point(3.123, 4.098);
        //Shape s1 = new Shape(p2);
        //Shape s2 = new Shape(5.23, 6.432);
        Point p3 = new Point(7.321, 9.45);
        Rectangle r1 = new Rectangle(5);
        Rectangle r2 = new Rectangle(p3, 7, 2);
        Rectangle r3 = new Rectangle(p3, 10);
        //Console.WriteLine(r1.ToString());
        //Console.WriteLine(r2.ToString());
        //Console.WriteLine(r3.ToString());
        ////Console.WriteLine(s2.ToString());
        //Console.WriteLine(c1);
        //Console.WriteLine(c2);
        //Console.WriteLine(c3);
        p2.setY(6.927);
        Console.WriteLine(p2.ToString());
        //s1.writeInfo();
        c1.writeInfo();
        c2.writeInfo();
        c3.writeInfo();
        r1.writeInfo();
        r2.writeInfo();
        r3.writeInfo();
        r2.area();
        r2.perimeter();
    }
}
