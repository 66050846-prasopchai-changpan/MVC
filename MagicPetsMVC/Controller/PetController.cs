using System;
using MagicPetsMVC.Model;
using MagicPetsMVC.View; // เพิ่มการอ้างถึง PetView


namespace MagicPetsMVC.Controller
{
    class PetController
    {
        private PetDatabase database;

        public PetController()
        {
            database = new PetDatabase();
        }

        public void Addpet()
        {
            string petType = PetView.GetInput("Please select an animal type (Phoenix/Dragon/Owl) (Please type in lowercase letters)").ToLower();
            int petId = database.GeneratePetId();
            string lastHealthCheck = PetView.GetInput("Date of last health check (dd/mm/yyyy)");
            int vaccineCount = int.Parse(PetView.GetInput("Number of vaccines received"));

            string status = "Accepted";

            if (petType == "phoenix")
            {
                bool fireproof = PetView.GetInput("Is there a fire proof certificate? (yes/no)").ToLower() == "yes";
                if (!fireproof) status = "Rejected";
            }
            else if (petType == "dragon")
            {
                double smolePollution = double.Parse(PetView.GetInput("Level of pollution caused by smoke (%)"));
                if (smolePollution > 70) status = "Rejected";
            }
            else if (petType == "owl")
            {
                double flightDistance = double.Parse(PetView.GetInput("Distance to fly without eating (km)"));
                if (flightDistance < 100) status = "Rejected";
            }
            else
            {
                PetView.ShowMessage("Incorrect animal type!");
                return;
            }

            Pet pet = new Pet { Id = petId, Type = petType, LastHealthCheck = lastHealthCheck, VaccineCount = vaccineCount, Status = status };
            database.AddPet(pet);
            PetView.ShowMessage($"✅ Animal added successfully! ID: {petId} Status: {status}");
        }

        public void ShowReport()
        {
            var pets = database.GetPets();
            PetView.DisplayReport(pets);
        }
    }
}