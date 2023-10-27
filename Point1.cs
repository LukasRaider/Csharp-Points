using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point1;
class Point
{
    public double y;
    public double x;
    /// <summary>
    /// Basic constructor 
    /// </summary>
    /// <param name="x">Horizontal position</param>
    /// <param name="y">Vertical position</param>
    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    //public Point() {
    //}
    /// <summary>
    /// Řetězcové vyjádření bodu
    /// </summary>
    /// <returns>vrací souřadnice zaokrouhlené na setiny</returns>
    public override string ToString()
    {
        return ($"{Math.Round(x, 2)}; {Math.Round(y, 2)}");  //souřadnice zaokrouhlené na setiny
    }
}
class Shape
{
    public Point center;
    public Shape(Point center)
    {
        this.center = center;
    }
    public Shape(double x, double y)
    { // přetížený konstruktor se dvěma parametry typu double
        Point center = new Point(x, y);
        this.center = center;
    }
}
class Circle : Shape
{
    public double r;
    public Circle(Point center, int r) : base(center)
    {        //konstruktor se středem (datový typ Point) a  poloměrem. 
        this.r = r;
    }
    public Circle(double x, double y, int r) : base(x, y)
    {       //tři parametry typu double, první dva jsou souřadnice středu
        this.r = r;
    }
    public Circle(int r) : base(new Point(0, 0))
    {         //konstruktor jen s poloměrem, střed má souřadnice [0,0]
        this.r = r;
    }

    public override string ToString()
    {
        return $"Kruh ma polomer {r} a stred v bode {center}";
    }
    public Circle(double centerX, double centerY, double pointX, double pointY) : base(centerX, centerY)
    {
        center = new Point(centerX, centerY);
        r = Math.Sqrt(Math.Pow(centerX - pointX, 2) + Math.Pow(centerY - pointY, 2));
    } //kruh se středem a libovolným bodem na kružnici, verze s 4 doubly; autor: Dan Nemec

    public Circle(Point center, Point pointOnCircle) : base(center)
    {
        this.center = center;
        r = Math.Sqrt(Math.Pow(center.x - pointOnCircle.x, 2) + Math.Pow(center.y - pointOnCircle.y, 2));
    } //kruh se středem a libovolným bodem na kružnici; verze s 2 body; autor: Dan Nemec
}
class Rectangle : Shape
{
    public int a, b;
    public Rectangle(Point center, int a, int b) : base(center)
    {          //konstruktor se středem a oběma stranami
        this.a = a;
        this.b = b;
    }
    public Rectangle(int a, int b) : base(new Point(0, 0))
    {          //varianta bez středu
        this.a = a;
        this.b = b;
    }
    public Rectangle(Point center, int a) : base(center)
    {
        this.a = this.b = a;
    }
    public Rectangle(int a) : base(new Point(0, 0))
    {
        this.a = this.b = a;
    }
    public override string ToString()
    {
        return $"Ctyruhelnik ma stranu A o delce {a}, stranu B o delce {b} a stred v bode {center}";
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
        Shape s1 = new Shape(p2);
        Shape s2 = new Shape(5.23, 6.432);
        Point p3 = new Point(7.321, 9.45);
        Rectangle r1 = new Rectangle(5);
        Rectangle r2 = new Rectangle(p3, 7, 2);
        Rectangle r3 = new Rectangle(p3, 10);
        Rectangle r4 = new Rectangle(2, 10);
        Console.WriteLine(r1);
        Console.WriteLine(r2);
        Console.WriteLine(r3);
        Console.WriteLine(r4);
        //Console.WriteLine(s2.ToString());
        Console.WriteLine(c1);
        Console.WriteLine(c2);
        Console.WriteLine(c3);
        Point p = new Point(0.3, 7.5);
        Console.WriteLine(p.ToString());
    }
}