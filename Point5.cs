using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point5;
class BadRadiusException : Exception
{
    public BadRadiusException() { }                          //vlastní výjimka
    public BadRadiusException(string message) : base(message) { }
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
        return (Math.Round(getX(), 2).ToString() + "; " + Math.Round(getY(), 2).ToString());
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
        Console.WriteLine("Stred tvaru je v bode " + getCenter().ToString());
    }
    //public abstract void perimeter();
    //public abstract void area();
    public abstract double Perimeter();
    public abstract double Area();
}
class Circle : Shape
{
    public int r;
    public Circle(Point center, int r) : base(center)
    {
        if (r < 0)
        {
            throw new BadRadiusException("Polomer nemuze byt zaporny!");            //vyhození výjimky, když r nebude kladné
        }
        this.r = r;
    }
    public Circle(double x, double y, int r) : base(new Point(x, y))
    {
        this.r = r;
    }
    public Circle(int r) : this(new Point(0, 0), r)
    {
        //Point center = new Point(0, 0);
        //center.x = 0;
        //center.y = 0;
        if (r < 0)
        {
            throw new ArgumentOutOfRangeException("Polomer nemuze byt zaporny!");       //vyhození výjimky, když r nebude kladné
        }
        this.r = r;
    }
    public override string ToString()
    {
        return $"Kruh ma polomer {r} a stred v bode {getCenter().ToString()}";
    }
    public override void writeInfo()
    {
        base.writeInfo();
        Console.WriteLine(($"Kruh ma polomer {r}, stred v bode {getCenter().ToString()}, obvod {Perimeter():f} a obsah {Area():f} \n"));
    }
    public override double Perimeter()
    {
        return 2 * Math.PI * r;
        //Console.WriteLine("Obvod kruhu je {0:f}", ();
    }
    public override double Area()
    {
        return Math.PI * r * r;
        //Console.WriteLine(string.Format("Plocha kruhu je {0:f}", Math.PI * r *r));
    }

}
class Rectangle : Shape
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
        Console.WriteLine(string.Format($"Ctyruhelnik ma stranu A o delce {{0}}, stranu B o delce {{1}}, stred v bode {{2}}, obvod {{3:f}} a obsah {{4:f}}", a, b, getCenter().ToString(), Perimeter(), Area()));
        if (a != b) { Console.WriteLine("Je to obdelnik.\n"); }
        else { Console.WriteLine("Je to ctverec.\n"); }
    }
    public override double Perimeter()
    {
        return (2 * this.a) + (2 * this.b);
        //Console.WriteLine("Obvod ctyruhelniku je {0:f}", (2 * this.a) + (2 * this.b));
    }
    public override double Area()
    {
        return a * b;
        //Console.WriteLine("Plocha ctyruhelniku je {0:f}", a*b);
    }
}

class TestPoint
{
    public static void Mainx()
    {
        Point p1 = new Point(3.456, 2.765);
        //Circle c1 = new Circle(3);
        //Circle c2 = new Circle(4.5, 2.1, 10);
        Circle c3 = null;
        bool OK;
        do
        {
            OK = true;
            Console.WriteLine("Zadej polomer dalsiho kruhu");           //zadání poloměru z klávesnice
            try
            {
                int r = Convert.ToInt32(Console.ReadLine());
                c3 = new Circle(p1, r);
                Console.WriteLine(c3.ToString());
            }
            catch (BadRadiusException e)
            {
                OK = false;
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {                                     //program nehavaruje, když uživatel nečíselne znaky
                OK = false;
                Console.WriteLine("Nemuzes zadat polomer jako necislo."); ;
            }
        } while (!OK);
        Point p2 = new Point(3.123, 4.098);
        Point p3 = new Point(7.321, 9.45);
        //Console.WriteLine(c1.ToString());
        //Console.WriteLine(c2.ToString());
        //Console.WriteLine(c3.ToString());
        bool OKParse;
        do
        {
            OKParse = true;
            Console.WriteLine("Zadej stranu dalsiho ctverce:");
            string s = Console.ReadLine();
            int x;
            bool b = int.TryParse(s, out x);                            //Strany obdélníka pomoci TryParse
            if (x == 0 && !b)
            {
                OKParse = false;
                Console.WriteLine("Zadej znovu");
            }
            else
            {
                Rectangle r1 = new Rectangle(x);
                Console.WriteLine(r1.ToString());
            }
        } while (!OKParse);
        //Rectangle r2 = new Rectangle(p3, 7, 2);
        //Rectangle r3 = new Rectangle(p3, 10);
        //Console.WriteLine(r2.ToString());
        //Console.WriteLine(r3.ToString());
        //Console.WriteLine(s2.ToString());

        Console.WriteLine("Konec!");
    }

}
