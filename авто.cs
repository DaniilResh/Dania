using System;

// Батьківський клас "Транспортний засіб"
public class Vehicle
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public int Year { get; set; }

    
    public Vehicle(string brand, string model, string color, int year)
    {
        Brand = brand;
        Model = model;
        Color = color;
        Year = year;
    }

  
    public void Start()
    {
        Console.WriteLine("Vehicle started.");
    }

    public void Stop()
    {
        Console.WriteLine("Vehicle stopped.");
    }
}

// Підклас "Автомобіль", який успадковує клас "Vehicle"
public class Car : Vehicle
{
   
    public Engine CarEngine { get; set; }
    public SteeringWheel CarSteeringWheel { get; set; }

 
    public Car(string brand, string model, string color, int year, Engine engine, SteeringWheel steeringWheel)
        : base(brand, model, color, year)
    {
        CarEngine = engine;
        CarSteeringWheel = steeringWheel;
    }

    public string DisplayInfo()
    {
        return $"Brand: {Brand}, Model: {Model}, Color: {Color}, Year: {Year}";
    }
}

// Підклас "Двигун"
public class Engine
{
    public string Type { get; set; }
    public int Horsepower { get; set; }

    public Engine(string type, int horsepower)
    {
        Type = type;
        Horsepower = horsepower;
    }

    public void Start()
    {
        Console.WriteLine("Engine started.");
    }

    public void Stop()
    {
        Console.WriteLine("Engine stopped.");
    }
}

// Підклас "Кермо"
public class SteeringWheel
{
    public string Material { get; set; }
    public bool HasButtons { get; set; }

    public SteeringWheel(string material, bool hasButtons)
    {
        Material = material;
        HasButtons = hasButtons;
    }

    public void TurnLeft()
    {
        Console.WriteLine("Turning left.");
    }

    public void TurnRight()
    {
        Console.WriteLine("Turning right.");
    }
}

class Program
{
    static void Main(string[] args)
    {
       
        Engine carEngine = new Engine("V8", 300);
        SteeringWheel carSteeringWheel = new SteeringWheel("Leather", true);

        Car car = new Car("Toyota", "Camry", "Black", 2022, carEngine, carSteeringWheel);

       
        Console.WriteLine(car.DisplayInfo());
        car.Start();
        car.CarEngine.Start();
        car.CarSteeringWheel.TurnLeft();
        car.Stop();
        car.CarEngine.Stop();
    }
}
