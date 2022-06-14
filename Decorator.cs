using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    
    public interface IBeverage
    {
        string GetDescription();
        int Cost();
    }
    public interface ICondimentDecorator : IBeverage { }

    public class Espresso : IBeverage
    {
        public string GetDescription()
        {
            return "Espresso";
        }

        public int Cost()
        {
            return 20;
        }
    }

    public class HouseBlend : IBeverage
    {
        public string GetDescription()
        {
            return "HouseBlend";
        }

        public int Cost()
        {
            return 25;
        }
    }

    public class DarkRoast : IBeverage
    {
        public string GetDescription()
        {
            return "DarkRoast";
        }

        public int Cost()
        {
            return 30;
        }
    }

    public class Decaf : IBeverage
    {
        public string GetDescription()
        {
            return "Decaf";
        }

        public int Cost()
        {
            return 15;
        }
    }

    public class Soy : ICondimentDecorator
    {
        IBeverage beverage;
        public Soy(IBeverage beverage)
        {
            this.beverage = beverage;
        }
        public string GetDescription()
        {
            return beverage.GetDescription() + " with soy";
        }
        public int Cost()
        {
            return beverage.Cost() + 3;
        }
    }

    public class Whip : ICondimentDecorator
    {
        IBeverage beverage;
        public Whip(IBeverage beverage)
        {
            this.beverage = beverage;
        }
        public string GetDescription()
        {
            return beverage.GetDescription() + " with whip";
        }
        public int Cost()
        {
            return beverage.Cost() + 5;
        }
    }

    public class Mocha : ICondimentDecorator
    {
        IBeverage beverage;
        public Mocha(IBeverage beverage)
        {
            this.beverage = beverage;
        }
        public string GetDescription()
        {
            return beverage.GetDescription() + " with mocha";
        }
        public int Cost()
        {
            return beverage.Cost() + 8;
        }
    }

    public class Milk : ICondimentDecorator
    {
        IBeverage beverage;
        public Milk(IBeverage beverage)
        {
            this.beverage = beverage;
        }
        public string GetDescription()
        {
            return beverage.GetDescription() + " with milk";
        }
        public int Cost()
        {
            return beverage.Cost() + 10;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IBeverage beverage = new Milk(new Soy(new Mocha(new Whip(new Decaf()))));

            Console.WriteLine(beverage.GetDescription());
            Console.WriteLine(beverage.Cost());

            Console.ReadLine();
        }
    }
}
