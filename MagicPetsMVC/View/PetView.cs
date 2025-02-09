using System;
using System.Collections.Generic;
using MagicPetsMVC.Model;



namespace MagicPetsMVC.View
{
    // คลาส PetView ใช้สำหรับแสดงผลลัพธ์ใน View ของแอปพลิเคชัน
    class PetView
    {
        Pet pet = new Pet(); //เรียกใช้ Class Pet

        // ฟังก์ชัน ShowMessage ใช้สำหรับแสดงข้อความในคอนโซล
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        // ฟังก์ชัน GetInput ใช้สำหรับรับข้อมูลจากผู้ใช้ในคอนโซล
        public static string GetInput(string input)
        {
            Console.WriteLine(input + ":");
            return Console.ReadLine();
        }

        // ฟังก์ชัน DisplayReport ใช้สำหรับแสดงรายงานของสัตว์เลี้ยงที่ถูกนำเข้ามา
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
