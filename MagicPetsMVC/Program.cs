// See https://aka.ms/new-console-template for more information
using System;
using MagicPetsMVC.Controller;
using MagicPetsMVC.Model;
using MagicPetsMVC.View;
class Program 
{
   static void Main(string[] args)
    {
        PetController controller = new PetController();

        while (true)
        {
            Console.WriteLine("Magic pet management system");
            Console.WriteLine("1 Add a pet");
            Console.WriteLine("2 View report");
            Console.WriteLine("3 ออกจากระบบ");
            Console.Write("Select menu:");

            string choice = Console.ReadLine();

            if(choice == "1")
            {
                controller.Addpet();
            }
            else if(choice == "2")
            {
                controller.ShowReport();
            }
            else if(choice == "3")
            {
                Console.WriteLine("Exit...");
                break;
            }
            else
            {
                Console.WriteLine("Please choose the correct menu!");
            }
        }
    }
}
