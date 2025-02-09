using System;
using MagicPetsMVC.Model;
using MagicPetsMVC.View; // เพิ่มการอ้างถึง PetView


namespace MagicPetsMVC.Controller
{
    // คลาส PetController ใช้ในการควบคุมการทำงานของโปรแกรมระหว่าง Model และ View
    class PetController
    {
        private PetDatabase database; // ตัวแปรสำหรับเก็บฐานข้อมูลของสัตว์เลี้ยง

        public PetController()
        {
            database = new PetDatabase(); // สร้างอ็อบเจ็กต์ของฐานข้อมูล
        }

        // ฟังก์ชัน Addpet ใช้เพื่อเพิ่มสัตว์เลี้ยงใหม่
        public void Addpet()
        {
            // รับข้อมูลประเภทสัตว์เลี้ยงจากผู้ใช้ (แปลงเป็นตัวพิมพ์เล็ก)
            string petType = PetView.GetInput("Please select an animal type (Phoenix/Dragon/Owl) (Please type in lowercase letters)").ToLower();
            int petId = database.GeneratePetId();// สร้าง ID สำหรับสัตว์เลี้ยงใหม่
            string lastHealthCheck = PetView.GetInput("Date of last health check (dd/mm/yyyy)"); // รับข้อมูลวันที่ตรวจสุขภาพล่าสุด
            int vaccineCount = int.Parse(PetView.GetInput("Number of vaccines received"));  // รับข้อมูลจำนวนวัคซีนที่ได้รับ

            string status = "Accepted"; // กำหนดสถานะเริ่มต้น

            // ตรวจสอบประเภทของสัตว์เลี้ยงที่ผู้ใช้เลือกและตรวจสอบเงื่อนไขต่างๆ
            if (petType == "phoenix")//เช็คใบรับรองไฟไม่ลาม
            {
                bool fireproof = PetView.GetInput("Is there a fire proof certificate? (yes/no)").ToLower() == "yes";
                if (!fireproof) status = "Rejected";
            }
            else if (petType == "dragon")// เช็คระดับผมลพิษที่เกิดจากคัวน
            {
                double smolePollution = double.Parse(PetView.GetInput("Level of pollution caused by smoke (%)"));
                if (smolePollution > 70) status = "Rejected";
            }
            else if (petType == "owl")//เช็คระยะทางบินโดยไม่กินข้าว
            {
                double flightDistance = double.Parse(PetView.GetInput("Distance to fly without eating (km)"));
                if (flightDistance < 100) status = "Rejected";
            }
            else
            {
                PetView.ShowMessage("Incorrect animal type!"); // หากประเภทสัตว์เลี้ยงไม่ถูกต้อง
                return;
            }

            // สร้างอ็อบเจ็กต์ Pet และกำหนดข้อมูลต่างๆ
            Pet pet = new Pet { Id = petId, Type = petType, LastHealthCheck = lastHealthCheck, VaccineCount = vaccineCount, Status = status }; // เพิ่มสัตว์เลี้ยงใหม่เข้าไปในฐานข้อมูล
            database.AddPet(pet);
            PetView.ShowMessage($"✅ Animal added successfully! ID: {petId} Status: {status}");
        }

        // ฟังก์ชัน ShowReport ใช้ในการแสดงรายงานสัตว์เลี้ยงทั้งหมด
        public void ShowReport()
        {
            var pets = database.GetPets();
            PetView.DisplayReport(pets);
        }
    }
    
}