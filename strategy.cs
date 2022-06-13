using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    interface FlyBehavior
    {
        void fly();
    }
    interface QuackBehavior
    {
        void quack();
        //
    }

    class FlywithWings : FlyBehavior
    {
        public void fly()
        {
            Console.WriteLine("I'm flying");
        }
    }

    class FlyNoWay : FlyBehavior
    {
        public void fly()
        {
            Console.WriteLine("I can't flying");
        }
    }

    class Quack : QuackBehavior
    {
        public void quack()
        {
            Console.WriteLine("quack!!!!!!!!!!!!!!!");
        }
    }

    class MuteQuack : QuackBehavior
    {
        public void quack()
        {
            Console.WriteLine("tsssss");
        }
    }

    class Squeak : QuackBehavior
    {
        public void quack()
        {
            Console.WriteLine("SQUEAKKKKKKKKKKKKK");
        }
    }


    abstract class Duck
    {
        public FlyBehavior flyBehavior;
        public QuackBehavior quackBehavior;

        public void setFlyBehavior(FlyBehavior fb)
        {
            flyBehavior = fb;
        }

        public void setQuackBehavior(QuackBehavior qb)
        {
            quackBehavior = qb;
        }

        public void performFly()
        {
            flyBehavior.fly();
        }
        public void performQuack()
        {
            quackBehavior.quack();
        }

        public void swim()
        {
            Console.WriteLine("I'm swimming");
        }

        public abstract void display();

    }


    class MalladDuck : Duck
    {
        public MalladDuck()
        {
            flyBehavior = new FlyNoWay();
            quackBehavior = new MuteQuack();
        }
        override public void display()
        {
            Console.WriteLine("I'm a MalladDuck");
        }
    }

    class ModelDuck : Duck
    {
        public ModelDuck()
        {
            flyBehavior = new FlywithWings();
            quackBehavior = new Squeak();
        }
        override public void display()
        {
            Console.WriteLine("I'm model duck!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Duck duck = new ModelDuck();
            duck.performFly();
            duck.performQuack();

            Console.WriteLine("=========================");

            duck.setFlyBehavior(new FlyNoWay());
            duck.setQuackBehavior(new Quack());
            duck.performFly();
            duck.performQuack();
            Console.Read();
        }
    }
}
