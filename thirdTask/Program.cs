using System;

// Базовый класс Транспортное средство
abstract class Vehicle
{
    public string Model { get; }
    public int Year { get; }

    public Vehicle(string model, int year)
    {
        Model = model;
        Year = year;
    }

    public virtual void Drive()
    {
        Console.WriteLine($"Транспортное средство {Model} движется.");
    }
}

// Класс Автомобиль
class Car : Vehicle
{
    public int HorsePower { get; }

    public Car(string model, int year, int horsePower)
        : base(model, year)
    {
        HorsePower = horsePower;
    }

    public override void Drive()
    {
        Console.WriteLine($"Автомобиль {Model} ({Year}) едет по дороге. Мощность: {HorsePower} л.с.");
    }
}

// Класс Велосипед
class Bicycle : Vehicle
{
    public string Type { get; } // Тип (горный, дорожный и т. д.)

    public Bicycle(string model, int year, string type)
        : base(model, year)
    {
        Type = type;
    }

    public override void Drive()
    {
        Console.WriteLine($"Велосипед {Model} ({Year}) типа {Type} движется по велодорожке.");
    }
}

// Класс Лодка
class Boat : Vehicle
{
    public double Length { get; } // Длина лодки в метрах

    public Boat(string model, int year, double length)
        : base(model, year)
    {
        Length = length;
    }

    public override void Drive()
    {
        Console.WriteLine($"Лодка {Model} ({Year}) длиной {Length} метров плывет по воде.");
    }
}

// Класс Гараж (Агрегация)
class Garage
{
    public string Name { get; }
    private List<Vehicle> vehicles = new List<Vehicle>();

    public Garage(string name)
    {
        Name = name;
    }

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
        Console.WriteLine($"{vehicle.Model} добавлен в гараж {Name}.");
    }

    public void ShowVehicles()
    {
        Console.WriteLine($"Гараж {Name} содержит:");
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"- {vehicle.Model} ({vehicle.Year})");
        }
    }
}

class Program
{
    static void Main()
    {
        Car myCar = new Car("Toyota Camry", 2022, 203);
        Bicycle myBike = new Bicycle("Giant Talon", 2021, "Горный");
        Boat myBoat = new Boat("Yamaha 242X", 2023, 7.2);

        myCar.Drive();
        myBike.Drive();
        myBoat.Drive();

        Console.WriteLine();

        Garage myGarage = new Garage("Мой гараж");
        myGarage.AddVehicle(myCar);
        myGarage.AddVehicle(myBike);
        myGarage.ShowVehicles();
    }
}