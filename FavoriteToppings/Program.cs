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
            List<string> OrdersString = new List<string>();

            /* Looping over JSON PizzaOrders to join at "," and give ability to
             * use the "Distinct()" IEnumerable method on. */
            foreach (var order in PizzaOrders)
            {
                // Joins Toppings array items together and adds to the StringOrders
                OrdersString.Add(string.Join(",", order.Toppings));
            }

            /* Creates a IEnumerable variable to run the Distinct method on.
             * I can now see which combos are distinct from other combos */
            IEnumerable<string> DistinctToppings = OrdersString.Distinct();

            Console.WriteLine("Hello World!");

            var OrderCount = new Dictionary<string, int>();

            foreach (var toppingCombo in DistinctToppings)
            {
                int totalOrdered = 0;
                for (int i = 0; i < OrdersString.Count; i++)
                {
                    if (OrdersString[i] == toppingCombo)
                    {
                        totalOrdered++;
                    }
                }
                OrderCount.Add(toppingCombo, totalOrdered);
            };

            // orders list from most ordered to least ordered
            var r = OrderCount.OrderByDescending(x => x.Value);

            Console.Write("The top 20 orders by popularity are ");

            // prints each order out
            for (int i = 0; i < 20; i++)
            {
                Console.Write($"\n{i+1}: {OrderCount.ElementAt(i).Key} \t\t total count: {OrderCount.ElementAt(i).Value}");
            }

            Console.ReadKey();
        }
    }
}