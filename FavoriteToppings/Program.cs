using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FavoriteToppings
{
    class Program
    {
        static void Main(string[] args)
        {
            var JsonPizzaOrders = File.ReadAllText(@"D:\Coding\backend\Orientation\Exersizes\FavoriteToppings\FavoriteToppings\NewFolder\pizzas.json");
            var PizzaOrders = JsonConvert.DeserializeObject<List<PizzaToppigns>>(JsonPizzaOrders);

            // Creating an empty list of strings to access later
            List<string> StringOrders = new List<string>();

            /* Looping over JSON PizzaOrders to join at "," and give ability to
             * use the "Distinct()" IEnumerable method on. */
            foreach (var order in PizzaOrders)
            {
                // Joins Toppings array items together and adds to the StringOrders
                StringOrders.Add(string.Join(",", order.Toppings));
            }

            /* Creates a IEnumerable variable to run the Distinct method on.
             * I can now see which combos are distinct from other combos */
            IEnumerable<string> DistinctToppings = StringOrders.Distinct();

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}