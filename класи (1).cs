using System;

// Клас 1: Студент
public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string StudentId { get; set; }
    public string Major { get; set; }

    public string DisplayInfo()
    {
        return $"Name: {Name}, Age: {Age}, ID: {StudentId}, Major: {Major}";
    }

    public void Study()
    {
        Console.WriteLine($"{Name} is studying.");
    }

    public void TakeExam(string subject)
    {
        Console.WriteLine($"{Name} is taking an exam in {subject}.");
    }

    public void JoinClub(string club)
    {
        Console.WriteLine($"{Name} joined the {club} club.");
    }
}

// Клас 2: Комп'ютер
public class Computer
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Processor { get; set; }
    public int RAM { get; set; }

    public string DisplayInfo()
    {
        return $"Brand: {Brand}, Model: {Model}, Processor: {Processor}, RAM: {RAM}GB";
    }

    public void TurnOn()
    {
        Console.WriteLine("The computer is turning on.");
    }

    public void ShutDown()
    {
        Console.WriteLine("The computer is shutting down.");
    }

    public void UpgradeRAM(int additionalRAM)
    {
        RAM += additionalRAM;
        Console.WriteLine($"RAM upgraded to {RAM}GB.");
    }
}

// Клас 3: Тварина
public class Animal
{
    public string Name { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }

    public string DisplayInfo()
    {
        return $"Name: {Name}, Species: {Species}, Age: {Age}";
    }

    public void MakeSound(string sound)
    {
        Console.WriteLine($"{Name} says {sound}!");
    }

    public void Feed()
    {
        Console.WriteLine($"Feeding {Name}.");
    }

    public void Sleep()
    {
        Console.WriteLine($"{Name} is sleeping.");
    }
}

// Інтерфейс для взаємодії з тваринами
public interface IPet
{
    void Play();
}

// Клас, який успадковує функціональність класу "Тварина" і реалізує інтерфейс IPet
public class Dog : Animal, IPet
{
    public void WagTail()
    {
        Console.WriteLine($"{Name} is wagging its tail.");
    }

    public void Play()
    {
        Console.WriteLine($"{Name} is playing fetch.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення об'єктів
        Student student = new Student { Name = "Daniil", Age = 20, StudentId = "2021001", Major = "Computer Science" };
        Computer computer = new Computer { Brand = "Dell", Model = "Inspiron", Processor = "Intel Core i7", RAM = 8 };
        Dog dog = new Dog { Name = "Buddy", Species = "Dog", Age = 3 };

        // Використання об'єктів
        Console.WriteLine(student.DisplayInfo());
        student.Study();
        computer.TurnOn();
        dog.MakeSound("Woof");
        dog.Play();
    }
}
