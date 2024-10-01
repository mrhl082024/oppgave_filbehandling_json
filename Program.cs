using System.Text.Json;
using System;
using System.IO;

namespace oppgave_filbehandling_json;

class Program
{
    static void Main(string[] args)
    {
        //Lager en tekst JSON fil, hvis filen ikke eksisterer fra før av, så vil den lage en ny for deg.
        string path = "whatIsThis.json";

        List<Cars>? cars = new List<Cars>();
        if (!File.Exists(path))
        {
            File.CreateText(path);
        }
        else
        {
            //Hvis filen eksisterer, så leser den av filen. hvis filen ikke er tom, så skal den settes opp etter klassen eg har satt.
            string existingJSON = File.ReadAllText(path);
            Console.WriteLine($"File already exists.{File.ReadAllText(path)}");
            if (!string.IsNullOrWhiteSpace(existingJSON))
            {
                cars = JsonSerializer.Deserialize<List<Cars>>(existingJSON);
            }
        }

        Console.WriteLine("what car brand is it?");
        string? carBrand = Console.ReadLine();
        Console.WriteLine("what year model is it?");
        string? yearModelInput = Console.ReadLine();
        int yearModel;
        while (!int.TryParse(yearModelInput, out yearModel))
        {
            Console.WriteLine("Error, please input year model using numbers!");
            yearModelInput = Console.ReadLine();
        }
        Console.WriteLine("what fuel does it use?");
        string? carFuel = Console.ReadLine();

        var newCars = new Cars
        {
            Brand = carBrand,
            YearModel = yearModel,
            FuelType = carFuel
        };
        cars?.Add(newCars);

        string json = JsonSerializer.Serialize(cars, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
    }
}
