using System;
using System.Collections.Generic;
/// <summary>
/// Базовий клас для всіх типів вагонів.
/// </summary>
public class Carriage
{
    /// <summary>
    /// Унікальний ідентифікатор вагона.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Опис типу вагона (наприклад, "passenger", "freight").
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Вага вагона.
    /// </summary>
    public double Weight { get; set; }

    /// <summary>
    /// Довжина вагона.
    /// </summary>
    public double Length { get; set; }

    /// <summary>
    /// Конструктор, що ініціалізує атрибути вагона.
    /// </summary>
    /// <param name="id">Унікальний ідентифікатор вагона.</param>
    /// <param name="type">Тип вагона.</param>
    /// <param name="weight">Вага вагона.</param>
    /// <param name="length">Довжина вагона.</param>
    public Carriage(int id, string type, double weight, double length)
    {
        Id = id;
        Type = type;
        Weight = weight;
        Length = length;
    }

    // Віртуальні або абстрактні методи для можливого перевизначення у похідних класах
}



/// <summary>
/// Клас, що представляє пасажирський вагон.
/// </summary>
public class PassengerCarriage : Carriage
{
    /// <summary>
    /// Загальна кількість місць для сидіння.
    /// </summary>
    public int SeatsCount { get; set; }

    /// <summary>
    /// Рівень комфорту.
    /// </summary>
    public string ComfortLevel { get; set; }

    /// <summary>
    /// Конструктор, що ініціалізує атрибути пасажирського вагона.
    /// </summary>
    /// <param name="id">Унікальний ідентифікатор вагона.</param>
    /// <param name="weight">Вага вагона.</param>
    /// <param name="length">Довжина вагона.</param>
    /// <param name="seatsCount">Загальна кількість місць для сидіння.</param>
    /// <param name="comfortLevel">Рівень комфорту.</param>
    public PassengerCarriage(int id, double weight, double length, int seatsCount, string comfortLevel) 
        : base(id, "passenger", weight, length)
    {
        SeatsCount = seatsCount;
        ComfortLevel = comfortLevel;
    }

    // Можливість перевизначення віртуальних методів базового класу
}



/// <summary>
/// Клас, що представляє вантажний вагон.
/// </summary>
public class FreightCarriage : Carriage
{
    /// <summary>
    /// Максимально дозволена вага вантажу.
    /// </summary>
    public double MaxLoadCapacity { get; set; }

    /// <summary>
    /// Опис типу вантажу.
    /// </summary>
    public string CargoType { get; set; }

    /// <summary>
    /// Конструктор, що ініціалізує атрибути вантажного вагона.
    /// </summary>
    /// <param name="id">Унікальний ідентифікатор вагона.</param>
    /// <param name="weight">Вага вагона.</param>
    /// <param name="length">Довжина вагона.</param>
    /// <param name="maxLoadCapacity">Максимально дозволена вага вантажу.</param>
    /// <param name="cargoType">Опис типу вантажу.</param>
    public FreightCarriage(int id, double weight, double length, double maxLoadCapacity, string cargoType) 
        : base(id, "freight", weight, length)
    {
        MaxLoadCapacity = maxLoadCapacity;
        CargoType = cargoType;
    }

    // Можливість перевизначення віртуальних методів базового класу
}



/// <summary>
/// Клас, що представляє вагон ресторанного типу.
/// </summary>
public class DiningCarriage : Carriage
{
    /// <summary>
    /// Кількість столів у вагоні.
    /// </summary>
    public int TablesCount { get; set; }

    /// <summary>
    /// Чи є в вагоні кухня.
    /// </summary>
    public bool HasKitchen { get; set; }

    /// <summary>
    /// Конструктор, що ініціалізує атрибути вагона ресторанного типу.
    /// </summary>
    /// <param name="id">Унікальний ідентифікатор вагона.</param>
    /// <param name="weight">Вага вагона.</param>
    /// <param name="length">Довжина вагона.</param>
    /// <param name="tablesCount">Кількість столів у вагоні.</param>
    /// <param name="hasKitchen">Чи є в вагоні кухня.</param>
    public DiningCarriage(int id, double weight, double length, int tablesCount, bool hasKitchen) 
        : base(id, "dining", weight, length)
    {
        TablesCount = tablesCount;
        HasKitchen = hasKitchen;
    }

    // Можливість перевизначення віртуальних методів базового класу
}



/// <summary>
/// Клас, що представляє спальний вагон.
/// </summary>
public class SleepingCarriage : Carriage
{
    /// <summary>
    /// Кількість купе у вагоні.
    /// </summary>
    public int CompartmentsCount { get; set; }

    /// <summary>
    /// Чи є у вагоні душові кабіни.
    /// </summary>
    public bool HasShowers { get; set; }

    /// <summary>
    /// Конструктор, що ініціалізує атрибути спального вагона.
    /// </summary>
    /// <param name="id">Унікальний ідентифікатор вагона.</param>
    /// <param name="weight">Вага вагона.</param>
    /// <param name="length">Довжина вагона.</param>
    /// <param name="compartmentsCount">Кількість купе у вагоні.</param>
    /// <param name="hasShowers">Чи є у вагоні душові кабіни.</param>
    public SleepingCarriage(int id, double weight, double length, int compartmentsCount, bool hasShowers) 
        : base(id, "sleeping", weight, length)
    {
        CompartmentsCount = compartmentsCount;
        HasShowers = hasShowers;
    }

    // Можливість перевизначення віртуальних методів базового класу
}



/// <summary>
/// Клас, що представляє потяг.
/// </summary>
public class Train
{
    /// <summary>
    /// Самостійно реалізований зв'язний список вагонів.
    /// </summary>
    private LinkedList<Carriage> carriages = new LinkedList<Carriage>();

    /// <summary>
    /// Назва потягу.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Унікальний номер маршруту.
    /// </summary>
    public string RouteNumber { get; set; }

    /// <summary>
    /// Додає вагон до потягу.
    /// </summary>
    /// <param name="carriage">Вагон, який додається.</param>
    public void AddCarriage(Carriage carriage)
    {
        // Перевірка, чи вагон відповідає обмеженням потягу
        if ((carriage.Type == "passenger" && carriages.Any(c => c.Type == "freight")) ||
            (carriage.Type == "freight" && carriages.Any(c => c.Type == "passenger")))
        {
            throw new InvalidOperationException("Потяг не може мати пасажирські та вантажні типи вагонів в одному списку вагонів");
        }

        // Перевірка, чи немає вагона з таким самим ідентифікатором
        if (carriages.Any(c => c.Id == carriage.Id))
        {
            throw new InvalidOperationException("Не може бути 2 вагони з однаковим ідентифікатором в одному списку");
        }

        carriages.AddLast(carriage);
    }

    /// <summary>
    /// Видаляє вагон з потягу.
    /// </summary>
    /// <param name="carriage">Вагон, який видаляється.</param>
    public void RemoveCarriage(Carriage carriage)
    {
        carriages.Remove(carriage);
    }

    /// <summary>
    /// Пошук вагонів за різними критеріями.
    /// </summary>
    /// <param name="predicate">Умова пошуку.</param>
    /// <returns>Список знайдених вагонів.</returns>
    public IEnumerable<Carriage> FindCarriages(Func<Carriage, bool> predicate)
    {
        return carriages.Where(predicate);
    }

    /// <summary>
    /// Розраховує загальну вагу потягу.
    /// </summary>
    /// <returns>Загальна вага потягу.</returns>
    public double CalculateTotalWeight()
    {
        return carriages.Sum(c => c.Weight);
    }

    /// <summary>
    /// Виводить інформацію про всі вагони потягу.
    /// </summary>
    public void DisplayAllCarriagesInfo()
    {
        foreach (var carriage in carriages)
        {
            Console.WriteLine($"Carriage ID: {carriage.Id}, Type: {carriage.Type}, Weight: {carriage.Weight}, Length: {carriage.Length}");
        }
    }

    /// <summary>
    /// Виводить інформацію про вагон з конкретним ідентифікатором.
    /// </summary>
    /// <param name="id">Ідентифікатор вагона.</param>
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
}



{
    // Попередні атрибути та методи класу Train

    /// <summary>
    /// Розраховує загальну кількість пасажирів у потязі.
    /// </summary>
    /// <returns>Загальна кількість пасажирів у потязі.</returns>
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

    /// <summary>
    /// Визначає вагон з найбільшою вантажопідйомністю.
    /// </summary>
    /// <returns>Вагон з найбільшою вантажопідйомністю.</returns>
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

    /// <summary>
    /// Підраховує кількість вагонів кожного типу.
    /// </summary>
    /// <returns>Словник, де ключ - тип вагона, значення - кількість вагонів цього типу.</returns>
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

    // Інші методи та атрибути класу Train

}
