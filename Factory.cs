using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{

    public interface IIngredient
    {
        string Dough();
        string Sauce();
        string Cheese();
        string Vegetable();

    }
    public class NYPizzaIngredientFactory : IIngredient
    {
        public string Dough()
        {
            return "Thin dough";
        }
        public string Sauce()
        {
            return "Motley sauce";
        }
        public string Cheese()
        {
            return "Parmesan cheese";
        }
        public string Vegetable()
        {
            return "Eggplant";
        }
    }

    public class ChicagoPizzaIngredientFactory : IIngredient
    {
        public string Dough()
        {
            return "Deep dough";
        }

        public string Sauce()
        {
            return "Tomato sauce";
        }

        public string Cheese()
        {
            return "Cheddar cheese";
        }

        public string Vegetable()
        {
            return "Cucumber";
        }
    }

    public class CaliforniaPizzaIngredientFactory : IIngredient
    {
        public string Dough()
        {
            return "Deep dough";
        }

        public string Sauce()
        {
            return "Cheese sauce";
        }

        public string Cheese()
        {
            return "Mozzarella cheese";
        }

        public string Vegetable()
        {
            return "Onion";
        }
    }

    public abstract class Pizza
    {
        public IIngredient ingredient;
        public string name;

        public string dough;
        public string sause;
        public string cheese;
        public string vegetable;

        public abstract void Preparing();

        public void Bake()
        {
            Console.WriteLine("Baked");
        }

        public void Cut()
        {
            Console.WriteLine("Cut");
        }

        public void Box()
        {
            Console.WriteLine("Boxing pizza");

        }

    }

    public class CheesePizza : Pizza
    {

        IIngredient ingredient;

        public CheesePizza(IIngredient ingredient)
        {
            this.ingredient = ingredient;
        }
        public override void Preparing()
        {
            Console.WriteLine("Preparing cheese pizza " + name);
            dough = ingredient.Dough();
            Console.WriteLine("-" + dough);
            sause = ingredient.Sauce();
            Console.WriteLine("-" + sause);
            cheese = ingredient.Cheese();
            Console.WriteLine("-" + dough);
            vegetable = ingredient.Vegetable();
            Console.WriteLine("-" + vegetable);
            Console.WriteLine("Done preparing cheese pizza");
        }
    }
    public class PepperoniPizza : Pizza
    {
        IIngredient ingredient;

        public PepperoniPizza(IIngredient ingredient)
        {
            this.ingredient = ingredient;
        }
        public override void Preparing()
        {
            Console.WriteLine("Preparing pepperoni pizza " + name);
            dough = ingredient.Dough();
            Console.WriteLine("-" + dough);
            sause = ingredient.Sauce();
            Console.WriteLine("-" + sause);
            cheese = ingredient.Cheese();
            Console.WriteLine("-" + dough);
            vegetable = ingredient.Vegetable();
            Console.WriteLine("-" + vegetable);
            Console.WriteLine("Done preparing pepperoni pizza");
        }
    }
    public class GreekPizza : Pizza
    {
        IIngredient ingredient;

        public GreekPizza(IIngredient ingredient)
        {
            this.ingredient = ingredient;
        }
        public override void Preparing()
        {
            Console.WriteLine("Preparing greek pizza " + name);
            dough = ingredient.Dough();
            Console.WriteLine("-" + dough);
            sause = ingredient.Sauce();
            Console.WriteLine("-" + sause);
            cheese = ingredient.Cheese();
            Console.WriteLine("-" + dough);
            vegetable = ingredient.Vegetable();
            Console.WriteLine("-" + vegetable);
            Console.WriteLine("Done preparing greek pizza");
        }
    }

    public abstract class PizzaStore
    {
        public abstract Pizza OrderPizza(string type);
    }

    public class NYPizzaStore : PizzaStore
    {

        IIngredient ingredient = new NYPizzaIngredientFactory();

        public override Pizza OrderPizza(string type)
        {
            Pizza pizza;

            if (type == "Cheese")
                pizza = new CheesePizza(ingredient);
            else if (type == "Peperoni")
                pizza = new PepperoniPizza(ingredient);
            else
                pizza = new GreekPizza(ingredient);


            Console.WriteLine("Preparing NY Style Sauce and Cheese Pizza");
            pizza.Preparing();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }

    }

    public class ChicagoPizzaStore : PizzaStore
    {

        IIngredient ingredient = new ChicagoPizzaIngredientFactory();

        public override Pizza OrderPizza(string type)
        {
            Pizza pizza;

            if (type == "Cheese")
                pizza = new CheesePizza(ingredient);
            else if (type == "Peperoni")
                pizza = new PepperoniPizza(ingredient);
            else
                pizza = new GreekPizza(ingredient);


            Console.WriteLine("Chicago Style Deep Dish Cheese Pizza");
            pizza.Preparing();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }

    }

    public class CaliforniaPizzaStore : PizzaStore
    {

        IIngredient ingredient = new CaliforniaPizzaIngredientFactory();

        public override Pizza OrderPizza(string type)
        {
            Pizza pizza;

            if (type == "Cheese")
                pizza = new CheesePizza(ingredient);
            else if (type == "Peperoni")
                pizza = new PepperoniPizza(ingredient);
            else
                pizza = new GreekPizza(ingredient);


            Console.WriteLine("California Style Deep Dish Cheese Pizza");
            pizza.Preparing();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {

            PizzaStore NYStore = new NYPizzaStore();
            PizzaStore ChicagoStore = new ChicagoPizzaStore();
            PizzaStore CaliforniaStore = new CaliforniaPizzaStore();

            NYStore.OrderPizza("Cheese");
            Console.WriteLine("==================");
            NYStore.OrderPizza("Peperoni");
            Console.WriteLine("==================");
            ChicagoStore.OrderPizza("Cheese");
            Console.WriteLine("==================");
            ChicagoStore.OrderPizza("Greek");
            Console.WriteLine("==================");
            CaliforniaStore.OrderPizza("Peperoni");
            Console.WriteLine("==================");
            CaliforniaStore.OrderPizza("Greek");
            Console.Read();

        }
    }
}
