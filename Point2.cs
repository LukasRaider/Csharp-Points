using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point2;
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
        return (Math.Round(getX(), 2).ToString() + "; " + Math.Round(getY(), 2).ToString());
    }
}
class Shape
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
    public Shape(Point center) /*: this(center.getX(), center.getY())*/
    {               //konstruktor s jedním parametrem volá konstruktor s dvěma 
        this.center = center;
    }
    public Shape(double x, double y) : this(new Point(x, y))
    {    //konstruktor se dvěma parametry volá konstruktor s jedním parametrem
         //Point p = new Point(x, y);
         //this.center = p;
    }
    public override string ToString()
    {
        return base.ToString();
    }
}
class Circle : Shape
{
    //public Point center;
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
    { // konstruktor kruhu s jedním parametrem volá konstruktor s oběma parametry.
        this.r = r;
    }
    public override string ToString()
    {
        return $"Kruh ma polomer {r} a stred v bode {getCenter()}";
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
    { //
      //this.center = center;
      //this.a = this.b = a;
    }
    public Rectangle(int a) : this(new Point(0, 0), a, a)
    { //              this(new Point(0, 0),a) 
      //this.a = this.b = a;
    }
    public override string ToString()
    {
        return $"Ctyruhelnik ma stranu A o delce {a}, stranu B o delce {b} a stred v bode {getCenter()}";
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
        Console.WriteLine(r1);
        Console.WriteLine(r2.ToString());
        Console.WriteLine(r3.ToString());
        //Console.WriteLine(s2.ToString());
        Console.WriteLine(c1.ToString());
        Console.WriteLine(c2.ToString());
        Console.WriteLine(c3.ToString());
        p2.setY(6.927);
        Console.WriteLine(p2.ToString());
    }
}
