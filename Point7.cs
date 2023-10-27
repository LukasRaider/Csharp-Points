using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point7;
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
        return $"Kruh ma polomer {r} a stred v bode {getCenter().ToString()}";
    }
    public override void writeInfo()
    {
        base.writeInfo();
        Console.WriteLine((string.Format($"Kruh ma polomer {{0}}, stred v bode {{1}}, obvod {{2:f}} a obsah {{3:f}}\n", r, getCenter().ToString(), perimeter(), area())));
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
        base.writeInfo();
        Console.WriteLine(string.Format($"Ctyruhelnik ma stranu A o delce {{0}}, stranu B o delce {{1}}, stred v bode {{2}}, obvod {{3:f}} a obsah {{4:f}}", a, b, getCenter().ToString(), perimeter(), area()));
        if (a != b) { Console.WriteLine("Je to obdelnik.\n"); }
        else { Console.WriteLine("Je to ctverec.\n"); }
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
public class TestPoint
{
    public static void Mainx()
    {
        Point p1 = new Point(3.456, 2.765);
        Circle c1 = new Circle(3);
        Circle c2 = new Circle(4.5, 2.1, 10);
        IPerimeter[] tvary = new IPerimeter[6];
        List<IPerimeter> tvary2 = new List<IPerimeter>();

        bool OK = true;
        do
        {
            OK = true;
            Console.WriteLine("Zadej polomer dalsiho kruhu");
            try
            {
                int r = Convert.ToInt32(Console.ReadLine());
                Circle c3 = new Circle(p1, r);
                Console.WriteLine(c3.ToString());
            }
            catch (BadRadiusException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                OK = false;
                Console.WriteLine("Nemuzes zadat polomer jako necislo."); ;
            }
        } while (OK == false);
        Point p2 = new Point(3.123, 4.098);

        Point p3 = new Point(7.321, 9.45);
        bool OKParse = true;
        do
        {
            OKParse = true;
            Console.WriteLine("Zadej stranu dalsiho ctverce:");
            string s = Console.ReadLine();
            int x;
            bool b = int.TryParse(s, out x);
            if (x == 0 && !b)
            {
                OKParse = false;
                Console.WriteLine("Zadej znovu");
            }
            else
            {
                Rectangle r1 = new Rectangle(x);
                //Console.WriteLine(r1.ToString());
                tvary[2] = r1;
                tvary2.Add(r1);
            }
        } while (OKParse == false);
        Rectangle r2 = new Rectangle(p3, 7, 2);
        Rectangle r3 = new Rectangle(p3, 10);
        Person per1 = new Person(85, 1.5);

        tvary[0] = c1;
        tvary[1] = c2;
        tvary[3] = r2;
        tvary[4] = r3;
        tvary[5] = per1;
        double totalPerimeter = 0;
        for (int i = 0; i < tvary.Length; i++)
        {
            totalPerimeter += tvary[i].perimeter();
        }
        Console.WriteLine($"Celkovy soucet obvodu kruhu, obdelniku a lidi v poli je {{0:f}} ", totalPerimeter);

        //pomoci Listu
        tvary2.Add(c1);
        tvary2.Add(c2);
        tvary2.Add(r2);
        tvary2.Add(r3);
        tvary2.Add(per1);
        double total = 0;

        foreach (IPerimeter s in tvary2)
        {
            total += s.perimeter();
        }
        Console.WriteLine($"Celkovy soucet obvodu kruhu, obdelniku a lidi v kolekci je {{0:f}}", total);

        //pomoci ArrayListu i s inicializatorem
        ArrayList tvary3 = new ArrayList() { c1, c2, r2, r3, per1 };
        double totalArrayList = 0;
        foreach (IPerimeter tt in tvary3)
        {
            totalArrayList += tt.perimeter();       //nebo by to slo pomoci typu var, ale s pretypovanim
        }
        Console.WriteLine($"Celkovy soucet obvodu kruhu, obdelniku a lidi v kolekci ArrayList je {{0:f}}", totalArrayList);

        Console.WriteLine("Konec!");
    }
}