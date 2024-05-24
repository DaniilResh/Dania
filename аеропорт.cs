using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public enum FlightStatus
{
    OnTime,
    Delayed,
    Cancelled,
    Boarding,
    InFlight
}

public class Flight
{
    public string FlightNumber { get; set; }
    public string Airline { get; set; }
    public string Destination { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public FlightStatus Status { get; set; }
    public TimeSpan Duration { get; set; }
    public string AircraftType { get; set; }
    public string Terminal { get; set; }
}

public class FlightInformationSystem
{
    private List<Flight> flights;

    public FlightInformationSystem()
    {
        flights = new List<Flight>();
    }

    public void LoadDataFromJson(string filePath)
    {
        if (File.Exists(filePath))
        {
            var jsonData = File.ReadAllText(filePath);
            var flightData = JsonConvert.DeserializeObject<FlightData>(jsonData);
            flights = flightData.Flights;
        }
        else
        {
            throw new FileNotFoundException("File not found: " + filePath);
        }
    }

    public List<Flight> GetAllFlights()
    {
        return flights;
    }

    private class FlightData
    {
        public List<Flight> Flights { get; set; }
    }
}

public class FlightQueryHandler
{
    private FlightInformationSystem flightInformationSystem;

    public FlightQueryHandler(FlightInformationSystem system)
    {
        flightInformationSystem = system;
    }

    public List<Flight> GetFlightsByStatus(FlightStatus status)
    {
        return flightInformationSystem.GetAllFlights().Where(f => f.Status == status).ToList();
    }

    public List<Flight> GetFlightsByAirline(string airline)
    {
        return flightInformationSystem.GetAllFlights()
            .Where(f => f.Airline.Equals(airline, StringComparison.OrdinalIgnoreCase))
            .OrderBy(f => f.DepartureTime)
            .ToList();
    }

    public List<Flight> GetDelayedFlights()
    {
        return flightInformationSystem.GetAllFlights()
            .Where(f => f.Status == FlightStatus.Delayed)
            .OrderBy(f => f.DepartureTime)
            .ToList();
    }

    public List<Flight> GetFlightsByDay(DateTime date)
    {
        return flightInformationSystem.GetAllFlights()
            .Where(f => f.DepartureTime.Date == date.Date)
            .OrderBy(f => f.DepartureTime)
            .ToList();
    }

    public List<Flight> GetFlightsByTimeRangeAndDestination(DateTime startTime, DateTime endTime, string destination)
    {
        return flightInformationSystem.GetAllFlights()
            .Where(f => f.DepartureTime >= startTime && f.DepartureTime <= endTime && f.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase))
            .OrderBy(f => f.DepartureTime)
            .ToList();
    }

    public List<Flight> GetArrivalsWithinLastHour()
    {
        DateTime oneHourAgo = DateTime.Now.AddHours(-1);
        return flightInformationSystem.GetAllFlights()
            .Where(f => f.ArrivalTime >= oneHourAgo && f.ArrivalTime <= DateTime.Now)
            .OrderBy(f => f.ArrivalTime)
            .ToList();
    }

    public List<Flight> GetArrivalsByTimeRange(DateTime startTime, DateTime endTime)
    {
        return flightInformationSystem.GetAllFlights()
            .Where(f => f.ArrivalTime >= startTime && f.ArrivalTime <= endTime)
            .OrderBy(f => f.ArrivalTime)
            .ToList();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var flightInfoSystem = new FlightInformationSystem();

        // Load flight data from JSON file
        flightInfoSystem.LoadDataFromJson("flights.json");

        var queryHandler = new FlightQueryHandler(flightInfoSystem);

        // Examples of queries
        var onTimeFlights = queryHandler.GetFlightsByStatus(FlightStatus.OnTime);
        var delayedFlights = queryHandler.GetDelayedFlights();
        var flightsByAirline = queryHandler.GetFlightsByAirline("WizAir");
        var flightsByDay = queryHandler.GetFlightsByDay(new DateTime(2023, 6, 12));
        var flightsByTimeRangeAndDestination = queryHandler.GetFlightsByTimeRangeAndDestination(new DateTime(2023, 5, 1), new DateTime(2023, 5, 31), "Kyiv");
        var arrivalsWithinLastHour = queryHandler.GetArrivalsWithinLastHour();
        var arrivalsByTimeRange = queryHandler.GetArrivalsByTimeRange(new DateTime(2023, 5, 1), new DateTime(2023, 5, 31));

        // Print results
        Console.WriteLine("On Time Flights:");
        foreach (var flight in onTimeFlights)
        {
            Console.WriteLine($"Flight Number: {flight.FlightNumber}, Airline: {flight.Airline}, Status: {flight.Status}, Departure: {flight.DepartureTime}");
        }

        Console.WriteLine("\nDelayed Flights:");
        foreach (var flight in delayedFlights)
        {
            Console.WriteLine($"Flight Number: {flight.FlightNumber}, Airline: {flight.Airline}, Status: {flight.Status}, Departure: {flight.DepartureTime}");
        }

        Console.WriteLine("\nFlights by Airline (WizAir):");
        foreach (var flight in flightsByAirline)
        {
            Console.WriteLine($"Flight Number: {flight.FlightNumber}, Airline: {flight.Airline}, Departure: {flight.DepartureTime}");
        }

        Console.WriteLine("\nFlights by Day (2023-06-12):");
        foreach (var flight in flightsByDay)
        {
            Console.WriteLine($"Flight Number: {flight.FlightNumber}, Departure: {flight.DepartureTime}");
        }

        Console.WriteLine("\nFlights by Time Range and Destination (from 2023-05-01 to 2023-05-31, Destination: Kyiv):");
        foreach (var flight in flightsByTimeRangeAndDestination)
        {
            Console.WriteLine($"Flight Number: {flight.FlightNumber}, Departure: {flight.DepartureTime}, Destination: {flight.Destination}");
        }

        Console.WriteLine("\nArrivals within Last Hour:");
        foreach (var flight in arrivalsWithinLastHour)
        {
            Console.WriteLine($"Flight Number: {flight.FlightNumber}, Arrival: {flight.ArrivalTime}");
        }

        Console.WriteLine("\nArrivals by Time Range (from 2023-05-01 to 2023-05-31):");
        foreach (var flight in arrivalsByTimeRange)
        {
            Console.WriteLine($"Flight Number: {flight.FlightNumber}, Arrival: {flight.ArrivalTime}");
        }
    }
}
