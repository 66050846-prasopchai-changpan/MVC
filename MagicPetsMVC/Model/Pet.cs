using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MagicPetsMVC.Model
{
     // คลาส Pet สำหรับเก็บข้อมูลสัตว์เลี้ยง
    public class Pet
    {
        public int Id { get; set; } // ID ของสัตว์เลี้ยง
        public string Type { get; set; } // ประเภทของสัตว์ (Phoenix, Dragon, Owl)
        public string LastHealthCheck { get; set; } // วันที่ตรวจสุขภาพล่าสุด
        public int VaccineCount { get; set; } // จำนวนวัคซีนที่ได้รับ
        public string Status { get; set; }  // สถานะของสัตว์
    }

    public class PetDatabase
    {
        private const string FilePath = "pets.json"; // พาธของไฟล์ JSON ที่ใช้เก็บข้อมูลสัตว์เลี้ยง

        //private string FilePath => Path.Combine(Directory.GetCurrentDirectory(), PetDatabaseName);

        public List<Pet> Pets { get; private set; } // รายการสัตว์เลี้ยงทั้งหมดที่บันทึกไว้

        // Constructor: เมื่อสร้างอ็อบเจ็กต์ PetDatabase จะโหลดข้อมูลจากไฟล์
        public PetDatabase()
        {
            LoadData();
        }

        // ฟังก์ชันสำหรับโหลดข้อมูลสัตว์เลี้ยงจากไฟล์
        private void LoadData()
        {
            if (File.Exists(FilePath)) //ตรวจสอบว่าไฟล์มีอยู่
            {
                string json = File.ReadAllText(FilePath); // อ่านข้อมูลจากไฟล์
                Pets = JsonConvert.DeserializeObject<List<Pet>>(json) ?? new List<Pet>();
            }
            else
            {
                Pets = new List<Pet>(); // ถ้าไม่พบไฟล์ให้สร้าง List<Pet> ว่าง
            }
        }

        // ฟังก์ชันสำหรับบันทึกข้อมูลสัตว์เลี้ยงลงในไฟล์
        public void SaveData()
        {
            string json = JsonConvert.SerializeObject(Pets, Formatting.Indented); // แปลง List<Pet> เป็น JSON
            File.WriteAllText(FilePath, json); // บันทึกข้อมูล JSON ลงในไฟล์
        }

        // ฟังก์ชันสำหรับสร้าง ID สัตว์เลี้ยงแบบสุ่ม
        public int GeneratePetId()
        {
            Random random = new Random();
            return random.Next(10000000, 99999999);
        }

        // ฟังก์ชันสำหรับเพิ่มสัตว์เลี้ยงใหม่เข้าไปในฐานข้อมูล
        public void AddPet(Pet pet)
        {
            Pets.Add(pet);
            SaveData();
        }

        // ฟังก์ชันสำหรับดึงข้อมูลสัตว์เลี้ยงทั้งหมด
        public List<Pet> GetPets()
        {
            return Pets;
        }
    }
}