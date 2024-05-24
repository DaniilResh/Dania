using System;
using System.Collections.Generic;

// Клас страви
class Dish
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public double Weight { get; set; }
    public Dictionary<string, string> Attributes { get; set; }

    // Конструктор класу
    public Dish(string name, string description, double price, double weight)
    {
        Name = name;
        Description = description;
        Price = price;
        Weight = weight;
        Attributes = new Dictionary<string, string>();
    }
    
   {
    if (string.IsNullOrWhiteSpace(name))
    {
        throw new ArgumentException("Ім'я страви не може бути порожнім або містити лише пробіли.", nameof(name));
    }

    if (price <= 0)
    {
        throw new ArgumentException("Ціна повинна бути більше нуля.", nameof(price));
    }

    if (weight <= 0)
    {
        throw new ArgumentException("Вага повинна бути більше нуля.", nameof(weight));
    }

    Name = name;
    Description = description;
    Price = price;
    Weight = weight;
    Attributes = new Dictionary<string, string>();
    }

}

// Клас ресторану
class Restaurant
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Type { get; set; }
    public double Rating { get; set; }
    public List<Dish> Menu { get; set; }

    public Restaurant(string name, string address, string type, double rating)
    {
        Name = name;
        Address = address;
        Type = type;
        Rating = rating;
        Menu = new List<Dish>();
    }


    // Метод для виведення інформації про ресторан
    public void DisplayInfo()
    {
        Console.WriteLine($"Назва: {Name}");
        Console.WriteLine($"Адреса: {Address}");
        Console.WriteLine($"Тип: {Type}");
        Console.WriteLine("Меню:");
        foreach (var dish in Menu)
        {
            Console.WriteLine($"- {dish.Name}: {dish.Description}, Ціна: {dish.Price} грн");
        }
    }
    
   {
    if (Menu == null || Menu.Count == 0)
    {
        Console.WriteLine("Меню відсутнє.");
        return;
    }

    Console.WriteLine($"Назва: {Name}");
    Console.WriteLine($"Адреса: {Address}");
    Console.WriteLine($"Тип: {Type}");
    Console.WriteLine("Меню:");
    foreach (var dish in Menu)
    {
        Console.WriteLine($"- {dish.Name}: {dish.Description}, Ціна: {dish.Price} грн");
    }
    }

}

class Program
{
    static void Main(string[] args)
    {
        // Приклад використання класу Restaurant
        var restaurant = new Restaurant("Ресторан 'Смачна кухня'", "вул. Шевченка, 10", "Ресторан", 4.5);
        restaurant.Menu.Add(new Dish("Борщ", "Класичний український борщ", 50.0));
        restaurant.Menu.Add(new Dish("Котлета по-київськи", "Куряча котлета з начинкою", 120.0));
        restaurant.DisplayInfo();
    }
    
    {
        try
        {
            // Приклад використання класу Restaurant з обробкою помилок
            var restaurant = new Restaurant(null, "вул. Шевченка, 10", "Ресторан");
            restaurant.Menu.Add(new Dish("Борщ", "Класичний український борщ", 50.0));
            restaurant.Menu.Add(new Dish("Котлета по-київськи", "Куряча котлета з начинкою", 120.0));
            restaurant.DisplayInfo();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
        // Власний атрибут для страви
[AttributeUsage(AttributeTargets.Class)]
class DishAttribute : Attribute
{
    public string CuisineType { get; }

    public DishAttribute(string cuisineType)
    {
        CuisineType = cuisineType;
    }
}

// Власний атрибут для ресторану
[AttributeUsage(AttributeTargets.Class)]
class RestaurantAttribute : Attribute
{
    public string CuisineType { get; }

    public RestaurantAttribute(string cuisineType)
    {
        CuisineType = cuisineType;
    }
}

// Методи для обробки атрибутів
static void ProcessDishAttributes(Dish dish)
{
    var attributes = dish.GetType().GetCustomAttributes(typeof(DishAttribute), true);
    foreach (var attribute in attributes)
    {
        var dishAttribute = (DishAttribute)attribute;
        Console.WriteLine($"Cuisine Type: {dishAttribute.CuisineType}");
    }
}

static void ProcessRestaurantAttributes(Restaurant restaurant)
{
    var attributes = restaurant.GetType().GetCustomAttributes(typeof(RestaurantAttribute), true);
    foreach (var attribute in attributes)
    {
        var restaurantAttribute = (RestaurantAttribute)attribute;
        Console.WriteLine($"Cuisine Type: {restaurantAttribute.CuisineType}");
    }
}

}



// Клас кур'єра
class Courier
{
    public string Name { get; set; }
    public string ContactInfo { get; set; }
    public double Rating { get; set; }
    public string TransportType { get; set; }

    // Конструктор класу
    public Courier(string name, string contactInfo, double rating, string transportType)
    {
        Name = name;
        ContactInfo = contactInfo;
        Rating = rating;
        TransportType = transportType;
    }

    // Метод для відображення інформації про кур'єра
    public void DisplayInfo()
    {
        Console.WriteLine($"Ім'я: {Name}");
        Console.WriteLine($"Контактні дані: {ContactInfo}");
        Console.WriteLine($"Рейтинг: {Rating}");
        Console.WriteLine($"Тип транспорту: {TransportType}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Приклад використання класу Courier
        var courier = new Courier("Іван Петров", "тел. 123-456-789", 4.5, "авто");
        courier.DisplayInfo();
    }
}


// Клас клієнта
class Client
{
    public string Name { get; set; }
    public string DeliveryAddress { get; set; }
    public string ContactNumber { get; set; }
    public List<Order> OrderHistory { get; set; }

    // Конструктор класу
    public Client(string name, string deliveryAddress, string contactNumber)
    {
        Name = name;
        DeliveryAddress = deliveryAddress;
        ContactNumber = contactNumber;
        OrderHistory = new List<Order>();
    }
}


class Program
{
    static void Main(string[] args)
    {
        // Приклад використання класу Client
        var client = new Client("Олексій", "вул. Леніна, 10", "тел. 987-654-321");
        Console.WriteLine($"Ім'я: {client.Name}");
        Console.WriteLine($"Адреса доставки: {client.DeliveryAddress}");
        Console.WriteLine($"Контактний номер: {client.ContactNumber}");
    }
}

// Клас замовлення
class Order
{
    public List<Dish> Items { get; set; }
    public double TotalAmount { get; set; }
    public string Status { get; set; }
    public Restaurant RestaurantInfo { get; set; }
    public Courier CourierInfo { get; set; }
    public Client ClientInfo { get; set; }

    // Конструктор класу
    public Order(List<Dish> items, double totalAmount, string status, Restaurant restaurantInfo, Courier courierInfo, Client clientInfo)
    {
        Items = items;
        TotalAmount = totalAmount;
        Status = status;
        RestaurantInfo = restaurantInfo;
        CourierInfo = courierInfo;
        ClientInfo = clientInfo;
    }

    // Метод для оновлення статусу замовлення
    public void UpdateStatus(string newStatus)
    {
        Status = newStatus;
    }
}



// Клас страви
class Dish
{
    // Визначення властивостей страви
}

// Клас ресторану
class Restaurant
{
    // Визначення властивостей ресторану
}

// Клас кур'єра
class Courier
{
    // Визначення властивостей кур'єра
}

// Клас клієнта
class Client
{
    // Визначення властивостей клієнта
}

class Program
{
    static void Main(string[] args)
    {
        // Приклад використання класу Order
        var client = new Client("Олексій", "вул. Леніна, 10", "тел. 987-654-321");
        var restaurant = new Restaurant("Ресторан 'Смачна кухня'", "вул. Шевченка, 10", "Ресторан");
        var courier = new Courier("Іван Петров", "тел. 123-456-789", 4.5, "авто");
        var order = new Order(new List<Dish>(), 0, "В обробці", restaurant, courier, client);

        // Приклад оновлення статусу замовлення
        Console.WriteLine($"Початковий статус: {order.Status}");
        order.UpdateStatus("Відправлено");
        Console.WriteLine($"Оновлений статус: {order.Status}");
    }
}

// Клас менеджера доставки
class DeliveryManager
{
    public List<Courier> AvailableCouriers { get; set; }

    // Конструктор класу
    public DeliveryManager()
    {
        AvailableCouriers = new List<Courier>();
    }

    // Метод для вибору кур'єра
    public Courier ChooseCourier()
    {
        // Реалізуйте логіку вибору кур'єра тут
        // Наприклад, можна вибрати першого доступного кур'єра зі списку AvailableCouriers
        return AvailableCouriers[0];
    }

    // Метод для відстеження статусу замовлення
    public void TrackOrderStatus(Order order)
    {
        // Реалізуйте логіку відстеження статусу замовлення тут
    }
}

// Клас кур'єра
class Courier
{
    // Визначення властивостей кур'єра
}

// Клас замовлення
class Order
{
    // Визначення властивостей замовлення
}

class Program
{
    static void Main(string[] args)
    {
        // Приклад використання класу DeliveryManager
        var deliveryManager = new DeliveryManager();

        // Приклад вибору кур'єра
        var courier = deliveryManager.ChooseCourier();
        Console.WriteLine($"Вибраний кур'єр: {courier.Name}");

        // Приклад відстеження статусу замовлення
        var order = new Order();
        deliveryManager.TrackOrderStatus(order);
    }
}


/// Клас для тестування
class MockTester
{
    public List<Client> AvailableClients { get; set; }
    public DeliveryManager Manager { get; set; }
    public List<Restaurant> AvailableRestaurants { get; set; }

    public MockTester(List<Client> availableClients, DeliveryManager manager, List<Restaurant> availableRestaurants)
    {
        AvailableClients = availableClients;
        Manager = manager;
        AvailableRestaurants = availableRestaurants;
    }

    public void TestFunctionality()
    {
        // Логіка тестування функціональності сервісу доставки

        // Створення випадкового замовлення
        Random random = new Random();
        int clientIndex = random.Next(AvailableClients.Count);
        Client randomClient = AvailableClients[clientIndex];

        int restaurantIndex = random.Next(AvailableRestaurants.Count);
        Restaurant randomRestaurant = AvailableRestaurants[restaurantIndex];

        List<Dish> randomDishes = new List<Dish>();
        int numDishes = random.Next(1, 5); // Випадкова кількість страв у замовленні
        for (int i = 0; i < numDishes; i++)
        {
            int dishIndex = random.Next(randomRestaurant.Menu.Count);
            randomDishes.Add(randomRestaurant.Menu[dishIndex]);
        }

        double totalAmount = 0;
        foreach (var dish in randomDishes)
        {
            totalAmount += dish.Price;
        }

        int courierIndex = random.Next(Manager.AvailableCouriers.Count);
        Courier randomCourier = Manager.AvailableCouriers[courierIndex];

        Order randomOrder = new Order(randomDishes, totalAmount, "Нове", randomRestaurant, randomCourier, randomClient);

        // Виведення інформації про створене замовлення
        Console.WriteLine("Створено випадкове замовлення:");
        Console.WriteLine($"Клієнт: {randomOrder.ClientInfo.Name}");
        Console.WriteLine($"Адреса доставки: {randomOrder.ClientInfo.DeliveryAddress}");
        Console.WriteLine("Страви:");
        foreach (var dish in randomOrder.Items)
        {
            Console.WriteLine($"- {dish.Name}: {dish.Description}, Ціна: {dish.Price} грн");
        }
        Console.WriteLine($"Загальна сума: {randomOrder.TotalAmount} грн");
        Console.WriteLine($"Ресторан: {randomOrder.RestaurantInfo.Name}");
        Console.WriteLine($"Кур'єр: {randomOrder.CourierInfo.Name}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Приклад використання класу MockTester
        var deliveryManager = new DeliveryManager();
        var client1 = new Client("Олексій", "вул. Леніна, 10", "тел. 987-654-321");
        var client2 = new Client("Іван", "вул. Гоголя, 5", "тел. 123-456-789");
        var availableClients = new List<Client> { client1, client2 };

        var restaurant1 = new Restaurant("Ресторан 'Смачна кухня'", "вул. Шевченка, 10", "Ресторан", 4.2);
        restaurant1.Menu.Add(new Dish("Борщ", "Класичний український борщ", 50.0, 300.0));
        restaurant1.Menu.Add(new Dish("Котлета по-київськи", "Куряча котлета з начинкою", 120.0, 200.0));

        var restaurant2 = new Restaurant("Ресторан 'Смачні страви'", "вул. Пушкіна, 20", "Ресторан", 4.5);
        restaurant2.Menu.Add(new Dish("Піца Маргарита", "Піца з томатним соусом та сиром", 100.0, 400.0));
        restaurant2.Menu.Add(new Dish("Салат Цезар", "Салат з курячим філе та смаженими грінками", 80.0, 250.0));

        var availableRestaurants = new List<Restaurant> { restaurant1, restaurant2 };

        var courier1 = new Courier("Іван Петров", "тел. 123-456-789", 4.5, "авто");
        var courier2 = new Courier("Петро Іванов", "тел. 987-654-321", 4.3, "велосипед");
        deliveryManager.AvailableCouriers.Add(courier1
    }
}
// Клас відгуку
class Review
{
    public string Author { get; set; }
    public string Content { get; set; }
    public double Rating { get; set; }

    // Конструктор класу
    public Review(string author, string content, double rating)
    {
        Author = author;
        Content = content;
        Rating = rating;
    }

    // Метод для відображення інформації про відгук
    public void DisplayInfo()
    {
        Console.WriteLine($"Автор: {Author}");
        Console.WriteLine($"Рейтинг: {Rating}");
        Console.WriteLine($"Відгук: {Content}");
    }
}

// Клас меню
class Menu
{
    public List<Dish> Items { get; set; }

    // Конструктор класу
    public Menu()
    {
        Items = new List<Dish>();
    }

    // Метод для додавання страви в меню
    public void AddDish(Dish dish)
    {
        Items.Add(dish);
    }

    // Метод для видалення страви з меню
    public void RemoveDish(Dish dish)
    {
        Items.Remove(dish);
    }

    // Метод для відображення меню
    public void DisplayMenu()
    {
        foreach (var dish in Items)
        {
            Console.WriteLine($"- {dish.Name}: {dish.Description}, Ціна: {dish.Price} грн");
        }
    }
}

// Клас для оплати
class Payment
{
    public double Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; }

    // Конструктор класу
    public Payment(double amount, string paymentMethod)
    {
        Amount = amount;
        PaymentDate = DateTime.Now;
        PaymentMethod = paymentMethod;
    }

    // Метод для відображення інформації про оплату
    public void DisplayInfo()
    {
        Console.WriteLine($"Сума: {Amount} грн");
        Console.WriteLine($"Дата оплати: {PaymentDate}");
        Console.WriteLine($"Метод оплати: {PaymentMethod}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Приклад використання класу Menu
        var menu = new Menu();
        menu.AddDish(new Dish("Борщ", "Класичний український борщ", 50.0, 300.0));
        menu.AddDish(new Dish("Котлета по-київськи", "Куряча котлета з начинкою", 120.0, 200.0));
        menu.DisplayMenu();

        // Приклад використання класу Payment
        var payment = new Payment(150.0, "Готівка");
        payment.DisplayInfo();
    }
}
// Клас замовлення
class Order
{
    // Визначення властивостей замовлення
}
// Клас відгуку
class Review
{
    // Визначення властивостей відгуку
}
