using System;
using System.Collections.Generic;
using MagicPetsMVC.Model;


namespace MagicPetsMVC.View
{
    class PetView
    {
        Pet pet = new Pet();
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static string GetInput(string input)
        {
            Console.WriteLine(input + ":");
            return Console.ReadLine();
        }

        public static void DisplayReport(List<Pet> pets)
        {
            int accepted = pets.FindAll(p => p.Status == "Accepted").Count;
            int rejected = pets.FindAll(p => p.Status == "Rejected").Count;

            Console.WriteLine("\n=== List of imported pets ===");
            Console.WriteLine($"✅ Accepted: {accepted}  items | ❌ Rejected: {rejected} items");
            foreach (var pet in pets)
            {
                Console.WriteLine($"{pet.Id} - {pet.Type} - {pet.Status}");
            }
        }
    }
}
