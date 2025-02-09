using System;
using System.Collections.Generic;

class PetView
{
    public static void ShowMessage(string message)
    {
        Consloe.Writeline("\n" + message);
    }

    public static string GetInput(string input)
    {
        Console.WriteLine(input + ":");
        return Console.ReadLine();
    }

    public static void DisplayReport(List<Pet> pets)
    {
        int accepted = pets.FindAll(pets => =.Status == "Accepted").Count;
        int rejected = pets.FindAll(pets => =.Status == "Rejected").Count;

        Console.WriteLine("\n=== รายการนำเข้าสัตว์เลี้ยง ===");
        Console.WriteLine($"✅ รับเข้า: {accepted} ตัว | ❌ ปฏิเสธ: {rejected} ตัว");
        foreach (var pet in pets)
        {
            Console.WriteLine(${pet.Id} - {pet.Type} - {pet.Status});
        }
    }
}