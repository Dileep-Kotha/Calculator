using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> menu = new Dictionary<string, int>();
            menu["chickenbiryani"] = 199;
            menu["vegbiryani"] = 149;
            menu["panneerbiryani"] = 219;
            menu["pizza"] = 149;
            menu["burger"] = 99;
            menu["starters"] = 59;
            menu["drink"] = 105;


            Console.WriteLine("Welcome to RMS");
            Console.WriteLine("Here is our Menu");
            DisplayMenu(menu);

            Dictionary<string, int> orders = new Dictionary<string, int>();
            while (true)
            {
                Console.WriteLine("Enter the Item you want to order(type done to finish order)");
                string itemname = Console.ReadLine();
                if (itemname.ToLower() == "done")
                {
                    break;
                }
                if (menu.ContainsKey(itemname))
                {
                    Console.WriteLine($"enter the quantity of {itemname}");
                    int q;//Convert.ToInt32(Console.ReadLine());
                    if ((int.TryParse(Console.ReadLine(), out q)) && (q > 0))
                    {
                        if (orders.ContainsKey(itemname))
                        {
                            orders[itemname] += q;

                        }
                        else
                        {
                            orders[itemname] = q;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity");
                    }
                }
                else
                {
                    Console.WriteLine("Item not found in the menu.Please try again");
                }



            }
            CalculateBill(menu,orders);
        }
        static void DisplayMenu(Dictionary<string,int> menus)
        {
            Console.WriteLine("------------MENU----------");
            Console.WriteLine("     Items               Prices");
            foreach(var item in menus)
            {
                Console.WriteLine($"Item:{item.Key}-->Price={item.Value}");

            }
            Console.WriteLine("--------------------------");

        }
        static void CalculateBill(Dictionary<string,int> menu,Dictionary<string,int> orders)
        {
            int tb = 0;
            foreach (var order in orders)
            {
                int it = order.Value * menu[order.Key];
                tb += it;
                Console.WriteLine($"{order.Key}: {order.Value} x ${menu[order.Key]}= ${it}");

            }
            if (tb > 1000)
            {
                int discount = 100;
                tb-=discount;
                Console.WriteLine($"discount applied {discount}");
            }
            Console.WriteLine($"Total Bill: {tb}");
            Console.WriteLine("Thank You Visit Again");


        }
    }
}
