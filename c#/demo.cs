using System;

class Box
{
   public double length;   // 长度
   public double breadth;  // 宽度
   public double height;   // 高度
   public Box() //构造函数
   {
        Console.WriteLine("对象已创建");
   }

  ~Box() //析构函数
      {
         Console.WriteLine("对象已删除");
      }
}

class Shape
   {
      public void setWidth(int w)
      {
         width = w;
      }
      public void setHeight(int h)
      {
         height = h;
      }
      protected int width;
      protected int height;

      public Shape( int a=0, int b=0)
      {
         width = a;
         height = b;
      }


      //当有一个定义在类中的函数需要在继承类中实现时，
      //可以使用虚方法。虚方法是使用关键字 virtual 声明的。虚方法可以在不同的继承类中有不同的实现。对虚方法的调用是在运行时发生的。
      public virtual int area()
      {
         Console.WriteLine("父类的面积：");
         return 0;
      }

   }

   // 不支持多重继承  可以使用接口来扩展 基类 PaintCost
   public interface PaintCost
   {
      int getCost(int area);

   }


   // 派生类
   class Rectangle : Shape, PaintCost
   {
      public int getArea()
      {
         return (width * height);
      }
      public int getCost(int area)
      {
         return area * 70;
      }
      public Rectangle( int a=0, int b=0): base(a, b)
      {

      }
      public override int area ()
      {
         Console.WriteLine("Rectangle 类的面积：");
         return (width * height);
      }

   }


   class Triangle: Shape
   {
      public Triangle(int a = 0, int b = 0): base(a, b)
      {

      }
      public override int area()
      {
         Console.WriteLine("Triangle 类的面积：");
         return (width * height / 2);
      }
   }
   class Caller
   {
      public void CallArea(Shape sh)
      {
         int a;
         a = sh.area();
         Console.WriteLine("面积： {0}", a);
      }
   }


   //抽象类
   abstract class AbsShape
   {
      public abstract int area();
   }
   class AbsRectangle:  AbsShape
   {
      private int length;
      private int width;
      public AbsRectangle( int a=0, int b=0)
      {
         length = a;
         width = b;
      }
      public override int area ()
      {
         Console.WriteLine("Rectangle 类的面积：");
         return (width * length);
      }
   }

class Rectangle2
   {
      // 成员变量
      protected double length;
      protected double width;
      public Rectangle2(double l, double w)
      {
         length = l;
         width = w;
      }
      public double GetArea()
      {
         return length * width;
      }
      public void Display()
      {
         Console.WriteLine("长度： {0}", length);
         Console.WriteLine("宽度： {0}", width);
         Console.WriteLine("面积： {0}", GetArea());
      }
   }//end class Rectangle
   class Tabletop : Rectangle2
   {
      private double cost;
      public Tabletop(double l, double w) : base(l, w)
      { }
      public double GetCost()
      {
         //double cost;
         cost = GetArea() * 70;
         return cost;
      }
      public new void Display()
      {
         base.Display();
         Console.WriteLine("成本： {0}", GetCost());
      }
   }




[AttributeUsage(AttributeTargets.All)]
public class HelpAttribute : System.Attribute
{
   public readonly string Url;

   public string Topic  // Topic 是一个命名（named）参数
   {
      get
      {
         return topic;
      }
      set
      {

         topic = value;
      }
   }

   public HelpAttribute(string url)  // url 是一个定位（positional）参数
   {
      this.Url = url;
   }

   private string topic;
}
[HelpAttribute("Information on the class MyClass")]
class MyClass
{
}




public class EventTest
  {
    private int value;

    public delegate void NumManipulationHandler();


    public event NumManipulationHandler ChangeNum;
    protected virtual void OnNumChanged()
    {
      if ( ChangeNum != null )
      {
        ChangeNum(); /* 事件被触发 */
      }else {
        Console.WriteLine( "event not fire" );
        Console.ReadKey(); /* 回车继续 */
      }
    }


    public EventTest()
    {
      int n = 5;
      SetValue( n );
    }


    public void SetValue( int n )
    {
      if ( value != n )
      {
        value = n;
        OnNumChanged();
      }
    }
  }


  /***********订阅器类***********/

  public class subscribEvent
  {
    public void printf()
    {
      Console.WriteLine( "event fire" );
      Console.ReadKey(); /* 回车继续 */
    }
  }

public class MyGenericArray<T>
    {
        private T[] array;
        public MyGenericArray(int size)
        {
            array = new T[size + 1];
        }
        public T getItem(int index)
        {
            return array[index];
        }
        public void setItem(int index, T value)
        {
            array[index] = value;
        }
    }



class Demo
{
	delegate int NumberChanger(int n);

	static int num = 10;
	public static int AddNum(int p)
	{
	 num += p;
	 return num;
	}

	public static int MultNum(int q)
	{
	 num *= q;
	 return num;
	}
	public static int getNum()
	{
	 return num;
	}

	static void Swap<T>(ref T lhs, ref T rhs)
    {
        T temp;
        temp = lhs;
        lhs = rhs;
        rhs = temp;
    }

    static void Main(string[] args)
    {
        Demo d = new Demo();
        //int.Parse(string s)
        switch (args[0])
            {
                case "1":
                    d.fun1();
                    break;
                case "2" :
                    d.fun2();
                    break;
                case "3" :
                    d.fun3();
                    break;
                case "4" :
                    d.fun4();
                    break;
                case "5" :
                    d.fun5();
                    break;
                case "6" :
                	d.fun6();
                	break;
                case "7" :
                	d.fun7();
                	break;
                case "8" :
                	d.fun8();
                	break;
                case "9" :
                	d.fun9();
                	break;
                case "10" :
                	d.fun10();
                	break;
                default:
                    Console.WriteLine("无效的参数");
                    break;
            }
        Console.ReadKey();
    }

   void fun1()
   {
   	    Box Box1 = new Box();        // 声明 Box1，类型为 Box
        Box Box2 = new Box();        // 声明 Box2，类型为 Box
        double volume = 0.0;         // 体积

        // Box1 详述
        Box1.height = 5.0;
        Box1.length = 6.0;
        Box1.breadth = 7.0;

        // Box2 详述
        Box2.height = 10.0;
        Box2.length = 12.0;
        Box2.breadth = 13.0;

        // Box1 的体积
        volume = Box1.height * Box1.length * Box1.breadth;
        Console.WriteLine("Box1 的体积： {0}",  volume);

        // Box2 的体积
        volume = Box2.height * Box2.length * Box2.breadth;
        Console.WriteLine("Box2 的体积： {0}", volume);

   }

   void fun2()
   {
         Rectangle Rect = new Rectangle();
         int area;
         Rect.setWidth(5);
         Rect.setHeight(7);
         area = Rect.getArea();
         // 打印对象的面积
         Console.WriteLine("总面积： {0}",  Rect.getArea());
         Console.WriteLine("油漆总成本： ${0}" , Rect.getCost(area));

   }

   void fun3()
   {
   	  Tabletop t = new Tabletop(4.5, 7.5);
      t.Display();

   }

   void fun4()
   {
   	 AbsRectangle r = new AbsRectangle(10, 7);
     double a = r.area();
     Console.WriteLine("面积： {0}",a);

   }

   void fun5()
   {
   	   Caller c = new Caller();
       Rectangle r = new Rectangle(10, 7);
       Triangle t = new Triangle(10, 5);
       c.CallArea(r);
       c.CallArea(t);
   }

   void fun6()
   {
   		System.Reflection.MemberInfo info = typeof(MyClass);
         object[] attributes = info.GetCustomAttributes(true);
         for (int i = 0; i < attributes.Length; i++)
         {
            Console.WriteLine(attributes[i]);
         }

   }

   void fun7()
   {
   		// 创建委托实例
         NumberChanger nc1 = new NumberChanger(AddNum);
         NumberChanger nc2 = new NumberChanger(MultNum);
         // 使用委托对象调用方法
         nc1(25);
         Console.WriteLine("Value of Num: {0}", getNum());
         nc2(5);
         Console.WriteLine("Value of Num: {0}", getNum());

   }

   void fun8()
   {
   	  EventTest e = new EventTest(); /* 实例化对象,第一次没有触发事件 */
      subscribEvent v = new subscribEvent(); /* 实例化对象 */
      e.ChangeNum += new EventTest.NumManipulationHandler( v.printf ); /* 注册 */
      e.SetValue( 7 );
      e.SetValue( 11 );

   }

   void fun9()
   {
   	// 声明一个整型数组
            MyGenericArray<int> intArray = new MyGenericArray<int>(5);
            // 设置值
            for (int c = 0; c < 5; c++)
            {
                intArray.setItem(c, c*5);
            }
            // 获取值
            for (int c = 0; c < 5; c++)
            {
                Console.Write(intArray.getItem(c) + " ");
            }
            Console.WriteLine();
            // 声明一个字符数组
            MyGenericArray<char> charArray = new MyGenericArray<char>(5);
            // 设置值
            for (int c = 0; c < 5; c++)
            {
                charArray.setItem(c, (char)(c+97));
            }
            // 获取值
            for (int c = 0; c < 5; c++)
            {
                Console.Write(charArray.getItem(c) + " ");
            }

   }

   void fun10()
   {
   	int a, b;
    char c, d;
    a = 10;
    b = 20;
    c = 'I';
    d = 'V';

    // 在交换之前显示值
    Console.WriteLine("Int values before calling swap:");
    Console.WriteLine("a = {0}, b = {1}", a, b);
    Console.WriteLine("Char values before calling swap:");
    Console.WriteLine("c = {0}, d = {1}", c, d);

    // 调用 swap
    Swap<int>(ref a, ref b);
    Swap<char>(ref c, ref d);

    // 在交换之后显示值
    Console.WriteLine("Int values after calling swap:");
    Console.WriteLine("a = {0}, b = {1}", a, b);
    Console.WriteLine("Char values after calling swap:");
    Console.WriteLine("c = {0}, d = {1}", c, d);

   }
}