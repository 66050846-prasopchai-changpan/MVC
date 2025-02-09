using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
public class Pet
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string LastHealthCheck {get; set; }
    public int VaccineCount { get; set; }
    public string Status { get; set; }
}

public class PetDatabase
{
    private const string PetDatabaseName = "pets.json";
    public List<Pet> Pets{ get; set; }

    public PetDatabase
    {
        LoadData();
    }

    private void LoadData()
    {
        if(File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            Pets = JsonConvert.DeserializeObject<List<Pet>>(json) ?? new List<Pet>();
        }
        else
        {
            Pets = new List<Pet>();
        }
    }

    public void SaveData()
    {
        string json = JsonCovert.SerializeObject(Pets,Formatting.Indented);
        File.WriteAllText(FilePath, json.);
    }

    public interface GeneratePetId()
    {
        Random random = new Random();
        return random.next(10000000, 99999999);
    }

    public void Addpet(Pet pet)
    {
        Pets.Add(pet);
        SaveData();
    }

    public List<Pet> GetPets()
    {
        return Pets;
    }
}
