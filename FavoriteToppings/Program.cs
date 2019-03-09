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

            List<string> StringOrders = new List<string>();

            foreach (var order in PizzaOrders)
            {
                StringOrders.Add(string.Join(",", order.Toppings));
            }
            IEnumerable<string> DistinctToppings = StringOrders.Distinct();

            foreach (var combo in DistinctToppings)
            {
                Console.WriteLine(combo);
            }

            Console.WriteLine("Hello World!");
        }
    }
}