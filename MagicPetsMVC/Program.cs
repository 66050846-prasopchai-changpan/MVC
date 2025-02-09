// See https://aka.ms/new-console-template for more information
using System;
using MagicPetsMVC.Controller;
using MagicPetsMVC.Model;
using MagicPetsMVC.View;
class Program 
{
   static void Main(string[] args)
    {
        // สร้างอ็อบเจ็กต์ของ PetController เพื่อใช้ในการควบคุมการทำงาน
        PetController controller = new PetController();

        while (true)  // วนลูปจนกว่าผู้ใช้จะเลือกออกจากระบบ
        {
            //เมนูหลักสำหรับใช้เลือก
            Console.WriteLine("Magic pet management system");
            Console.WriteLine("1 Add a pet");
            Console.WriteLine("2 View report");
            Console.WriteLine("3 ออกจากระบบ");
            Console.Write("Select menu:");

            // รับค่าจากผู้ใช้เพื่อเลือกเมนู
            string choice = Console.ReadLine();
            // เช็คว่าเลือกเมนูไหนและเรียกใช้ฟังก์ชันที่เหมาะสม
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
                Console.WriteLine("Please choose the correct menu!");// หากผู้ใช้เลือกเมนูที่ไม่ถูกต้อง
            }
        }
    }
}
