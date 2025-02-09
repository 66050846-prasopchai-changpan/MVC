using System;

class PetController
{
    private PetDatabase database;

    public PetController()
    {   
        database = new PetDatabase();
    }

    public void Addpet()
    {   
        string petType = PetView.GetInput("Please select an animal type (Phoenix/Dragon/Owl").ToLower();
        int petId = database.GeneratePetId();
        string lastHealthCheck = PetView.GetInput("Date of last health check (dd/mm/yyyy)");
        int vaccineCount = int.Parse(PetView.GetInput("Number of vaccines received"));

        string status = "Accepted";

        if(petType == "phoenix")
        {
            bool fireproof = PetView.GetInput("มีใบรับรองไฟไม่ลาม? (yes/no)").ToLower() == "yes";
            if(!fireproof) status = "Rejected";
        }
        else if(petType == "dragon")
        {
            double smolePollution = double.Parse(PetView.GetInput("ระดับมลพิษที่เกิดจากควัน (%)"));
            if(smolePollution > 70) status = "Rejected";
        }
        else if(petType == "owl")
        {
            double flightDistance = double.Parse(PetView.GetInput("ระยะทางบินได้โดยไม่ทานข้าว (km)"));
            if(flightDistance < 100) status = "Rejected";
        }
        else
        {
            PetView.ShowMessage("Incorrect animal type!");
            return;
        }

        Pet pet = new Pet {Id = petId , Type = petType , LastHealthCheck = lastHealthCheck , vaccineCount = vaccineCount , status = status};
        database.AddPet(pet);
        PetView.ShowMessage($"✅ Animal added successfully! ID: {petId} Status: {status}");
    }

    public void ShowReport()
    {
        var pets = database.GetPets();
        PetView.DisplayReport(pets);
    }
}