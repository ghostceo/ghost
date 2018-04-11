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



class Demo
{
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
}