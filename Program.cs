using System;

namespace PizzaOrder
{
    public class Order
    {
        public string Size { get; set; }
        public double Toppings { get; set; }
        public string? Crust { get; set; }

        public static Order operator ++(Order obj)
        {
            ++obj.Toppings;
            return obj;
        }
        public static Order operator --(Order obj)
        {
            obj.Toppings = --obj.Toppings;
            return obj;
        }

        public static Order operator +(Order lhs, int n)
        {
            return lhs + n;
        }
        public static Order operator -(Order lhs, int n)
        {
            return lhs - n;
        }
        public static bool operator >(Order left, Order right)
        {
            bool larger = false;
            if (left.Toppings > right.Toppings)
            {
                larger = true;
            }

            return larger;
        }

        public static bool operator <(Order left, Order right)
        {
            bool smaller = false;
            if (left.Toppings < right.Toppings)
            {
                smaller = true;
            }
            return smaller;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Order[] myOrder = new Order[10];
            for (int i = 0; i < myOrder.Length; i++)
            {
                myOrder[i] = new Order(); 
            }
            int selection = Menu();
            int index = 0, entry = 0;
            string ans = "";
            while (selection != 6)
            {
                switch (selection)
                {
                    case 1:
                        if (index < 10)
                        {
                            Console.Write("Pizza Size (Small, Medium, Large): ");
                            myOrder[index].Size = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Crust: ");
                            myOrder[index].Crust = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("How many toppings?: ");
                            myOrder[index].Toppings = double.Parse(Console.ReadLine());
                            Console.WriteLine();
                            index++;
                        }
                        else
                            Console.WriteLine("You've entered the maximum allowed orders.");
                        break;
                    case 2:
                        for (int i = 0; i < myOrder.Length; i++)
                        {
                            if (myOrder[i].Crust != "" && myOrder[i].Crust != null)
                            {
                                Console.WriteLine($"Size: {myOrder[i].Size}");
                                Console.WriteLine($"Crust: {myOrder[i].Crust}");
                                Console.WriteLine($"Toppings: {myOrder[i].Toppings}");
                            }
                        }
                        break;
                    case 3:
                        entry = pickEntry(index);
                        Console.Write("Change Pizza Size (Small, Medium, Large) Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            Console.Write("Size? ");
                            myOrder[entry].Size = Console.ReadLine();
                        }
                        Console.WriteLine();
                        Console.Write("Change Crust Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            Console.Write("Crust: ");
                            myOrder[entry].Crust = Console.ReadLine();
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        entry = pickEntry(index);

                        Console.Write("Add a topping?  Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            myOrder[entry]++;
                            Console.WriteLine();
                            break;
                        }

                        Console.Write("Get rid of a topping?  Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            myOrder[entry]--;
                            Console.WriteLine();
                            break;
                        }

                        Console.Write("Add many toppings?  Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            Console.Write("Enter how many toppings you'd like to add: ");
                            int top;
                            while (!int.TryParse(Console.ReadLine(), out top))
                                Console.WriteLine($"Please choose a number");
                            myOrder[entry] += top;
                            Console.WriteLine();
                            break;
                        }

                        Console.Write("Get rid of many toppings?  Y for Yes ");
                        ans = Console.ReadLine();
                        if (ans == "Y" || ans == "y")
                        {
                            Console.Write("Enter how many toppings you'd like to subtract: ");
                            int top;
                            while (!int.TryParse(Console.ReadLine(), out top))
                                Console.WriteLine($"Please choose a number");
                            myOrder[entry] -= top;
                            Console.WriteLine();
                            break;
                        }

                        break;
                    case 5:
                        Order totalSmall = new Order();
                        totalSmall.Size = "Small Pizza";
                        totalSmall.Crust = "Crust Type";
                        Order totalMedium = new Order();
                        totalMedium.Size = "Medium Pizza";
                        totalMedium.Crust = "Crust Type";
                        Order totalLarge = new Order();
                        totalLarge.Size = "Large Pizza";
                        totalLarge.Crust = "Crust Type";
                        for (int i = 0; i < myOrder.Length; i++)
                        {
                            switch (myOrder[i].Size)
                            {
                                case "Small Pizza":
                                    totalSmall.Toppings += myOrder[i].Toppings;
                                    break;
                                case "Medium Pizza":
                                    totalMedium.Toppings += myOrder[i].Toppings;
                                    break;
                                case "Large Pizza":
                                    totalLarge.Toppings += myOrder[i].Toppings;
                                    break;
                            }
                        }
                        Console.WriteLine("Total toppings by pizza size");
                        if (totalSmall > totalMedium && totalSmall > totalLarge)
                        {
                            Console.WriteLine("The largest number of toppings is on the small pizza");
                            Console.WriteLine($"Your total small pizza toppings = {totalSmall.Toppings}");
                            Console.WriteLine($"Your total medium pizza toppings = {totalMedium.Toppings}");
                            Console.WriteLine($"Your total large pizza toppings = {totalLarge.Toppings}");
                        }
                        else if (totalSmall < totalMedium && totalLarge < totalMedium)
                        {
                            Console.WriteLine("The largest number of toppings is on the medium pizza");
                            Console.WriteLine($"Your total small pizza toppings = {totalSmall.Toppings}");
                            Console.WriteLine($"Your total medium pizza toppings = {totalMedium.Toppings}");
                            Console.WriteLine($"Your total large pizza toppings = {totalLarge.Toppings}");
                        }
                        else
                        {
                            Console.WriteLine("The largest number of toppings is on the large pizza");
                            Console.WriteLine($"Your total small pizza toppings = {totalSmall.Toppings}");
                            Console.WriteLine($"Your total medium pizza toppings = {totalMedium.Toppings}");
                            Console.WriteLine($"Your total large pizza toppings = {totalLarge.Toppings}");
                        }
                        break;
                    default:
                        Console.WriteLine("You made an invalid selection, please try again");
                        break;
                }
                selection = Menu();

            }
        }
        public static int Menu()
        {
            int choice = 0;
            Console.WriteLine("Please make a selection from the menu");
            Console.WriteLine("1 - Start an Order");
            Console.WriteLine("2 - Print All Orders");
            Console.WriteLine("3 - Change Size or Crust");
            Console.WriteLine("4 - Adjust Topping Amount");
            Console.WriteLine("5 - Total Orders and compare");
            Console.WriteLine("6 - Quit");
            while (!int.TryParse(Console.ReadLine(), out choice))
                Console.WriteLine("Please select 1 - 6");
            return choice;
        }
        public static int pickEntry(int index)
        {
            Console.WriteLine("What order would you like to change?");
            Console.WriteLine($"1 through {index}");
            int entry;
            while (!int.TryParse(Console.ReadLine(), out entry))
                Console.WriteLine($"Please select 1 - {index}");
            entry -= 1;  
            return entry;
        }
    }
}