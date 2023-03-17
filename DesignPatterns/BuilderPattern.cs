using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public interface IItem
    {
        string name { get; set; }
        int Price();
        IPacking Packing { get; }
    }
    public interface IPacking
    {
        void pack();
    }

    public class Wrapper : IPacking
    {
        public void pack()
        {
            Console.WriteLine("Wrappeing Item");
        }
    }
    public class Bottle : IPacking
    {
        public void pack()
        {
            Console.WriteLine("Filling Bottle...");
        }
    }

    public abstract class Burger : IItem
    {
        public string name
        {
            get; set;
        }

        public IPacking Packing
        {
            get
            {
                return new Wrapper();
            }
        }

        public abstract int Price();
    }
    public abstract class ColdDrink : IItem
    {
        public string name
        {
            get; set;

        }

        public IPacking Packing
        {
            get
            {
                return new Bottle();
            }
        }

        public abstract int Price();
    }

    public class ChickenBurger : Burger
    {
        public override int Price()
        {
            return 45;
        }
    }
    public class VegBurger : Burger
    {
        public override int Price()
        {
            return 45;
        }
    }
    public class Pepsi : ColdDrink
    {
        public override int Price()
        {
            return 20;
        }
    }
    public class Meal
    {
        List<IItem> Items = new List<IItem>();
        public void AddItem(IItem item)
        {
            Items.Add(item);
        }
        public void RemoveItem(IItem item)
        {
            Items.Remove(item);
        }
        public void ShowItem()
        {

        }
        //public int TotalCost()
        //{
        //    int tc;// = Items.Sum(x => x.Price);
        //    return tc;
        //}
    }

    public class MealBuilder
    {
        public Meal PreparevegMeal()
        {
            var meal = new Meal();
            meal.AddItem(new VegBurger());
            meal.AddItem(new Pepsi());
            return meal;
        }

        public Meal PrepareNonVegMeal()
        {
            var meal = new Meal();
            meal.AddItem(new ChickenBurger());
            meal.AddItem(new Pepsi());
            return meal;
        }
    }
}
