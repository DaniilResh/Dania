using System;
using System.Collections.Generic;

public class Carriage
{
    
    public int Id { get; set; }

    public string Type { get; set; }

    
    public double Weight { get; set; }

    
    public double Length { get; set; }

    
    public Carriage(int id, string type, double weight, double length)
    {
        Id = id;
        Type = type;
        Weight = weight;
        Length = length;
    }

    
    public virtual string GetInfo()
    {
        return $"ID: {Id}, Type: {Type}, Weight: {Weight}, Length: {Length}";
    }

    
    public virtual double CalculateVolume()
    {
       
        return Length * 2.5; 
    }
}




public class PassengerCarriage : Carriage
{
    
    public int SeatsCount { get; set; }

    
    public string ComfortLevel { get; set; }

    
    public PassengerCarriage(int id, double weight, double length, int seatsCount, string comfortLevel) 
        : base(id, "passenger", weight, length)
    {
        SeatsCount = seatsCount;
        ComfortLevel = comfortLevel;
    }

   
}




public class FreightCarriage : Carriage
{
    public double MaxLoadCapacity { get; set; }

    
    public string CargoType { get; set; }

    
    public FreightCarriage(int id, double weight, double length, double maxLoadCapacity, string cargoType) 
        : base(id, "freight", weight, length)
    {
        MaxLoadCapacity = maxLoadCapacity;
        CargoType = cargoType;
    }

    
}




public class DiningCarriage : Carriage
{
    
    public int TablesCount { get; set; }

    
    public bool HasKitchen { get; set; }

    
    public DiningCarriage(int id, double weight, double length, int tablesCount, bool hasKitchen) 
        : base(id, "dining", weight, length)
    {
        TablesCount = tablesCount;
        HasKitchen = hasKitchen;
    }

    
}

public class SleepingCarriage : Carriage
{
   
    public int CompartmentsCount { get; set; }

    
    public bool HasShowers { get; set; }

    
    public SleepingCarriage(int id, double weight, double length, int compartmentsCount, bool hasShowers) 
        : base(id, "sleeping", weight, length)
    {
        CompartmentsCount = compartmentsCount;
        HasShowers = hasShowers;
    }

    
}


public class Train
{
    
    private LinkedList<Carriage> carriages = new LinkedList<Carriage>();

    
    public string Name { get; set; }

    public string RouteNumber { get; set; }

   
    public void AddCarriage(Carriage carriage)
    {
        
        if ((carriage.Type == "passenger" && carriages.Any(c => c.Type == "freight")) ||
            (carriage.Type == "freight" && carriages.Any(c => c.Type == "passenger")))
        {
            throw new InvalidOperationException("Потяг не може мати пасажирські та вантажні типи вагонів в одному списку вагонів");
        }

        
        if (carriages.Any(c => c.Id == carriage.Id))
        {
            throw new InvalidOperationException("Не може бути 2 вагони з однаковим ідентифікатором в одному списку");
        }

        carriages.AddLast(carriage);
    }

    
    public void RemoveCarriage(Carriage carriage)
    {
        carriages.Remove(carriage);
    }

   
    public IEnumerable<Carriage> FindCarriages(Func<Carriage, bool> predicate)
    {
        return carriages.Where(predicate);
    }

    
    public double CalculateTotalWeight()
    {
        return carriages.Sum(c => c.Weight);
    }

    
    public void DisplayAllCarriagesInfo()
    {
        foreach (var carriage in carriages)
        {
            Console.WriteLine($"Carriage ID: {carriage.Id}, Type: {carriage.Type}, Weight: {carriage.Weight}, Length: {carriage.Length}");
        }
    }

    
    public void DisplayCarriageInfo(int id)
    {
        var carriage = carriages.FirstOrDefault(c => c.Id == id);
        if (carriage != null)
        {
            Console.WriteLine($"Carriage ID: {carriage.Id}, Type: {carriage.Type}, Weight: {carriage.Weight}, Length: {carriage.Length}");
        }
        else
        {
            Console.WriteLine($"Carriage with ID {id} not found.");
        }
    }
       
    public void AddCarriageAtPosition(Carriage carriage, int position)
    {
        
    }

    
    public void RemoveCarriageAtPosition(int position)
    {
        
    }

}



{
    
    public int CalculateTotalPassengers()
    {
        int totalPassengers = 0;
        foreach (var carriage in carriages)
        {
            if (carriage is PassengerCarriage passengerCarriage)
            {
                totalPassengers += passengerCarriage.SeatsCount;
            }
        }
        return totalPassengers;
    }

    
    public FreightCarriage FindMaxLoadCapacityCarriage()
    {
        FreightCarriage maxLoadCarriage = null;
        double maxLoad = 0;
        foreach (var carriage in carriages)
        {
            if (carriage is FreightCarriage freightCarriage && freightCarriage.MaxLoadCapacity > maxLoad)
            {
                maxLoad = freightCarriage.MaxLoadCapacity;
                maxLoadCarriage = freightCarriage;
            }
        }
        return maxLoadCarriage;
    }

    
    public Dictionary<string, int> CountCarriagesByType()
    {
        Dictionary<string, int> carriageCountByType = new Dictionary<string, int>();
        foreach (var carriage in carriages)
        {
            if (carriageCountByType.ContainsKey(carriage.Type))
            {
                carriageCountByType[carriage.Type]++;
            }
            else
            {
                carriageCountByType.Add(carriage.Type, 1);
            }
        }
        return carriageCountByType;
    }

    

}
