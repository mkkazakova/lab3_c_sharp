using System;
using System.Xml.Linq;


class Car : IEquatable<Car>
{
    // Свойства класса Car
    public string Name { get; set; }
    public int Engine { get; set; }
    public int MaxSpeed { get; set; }

    // Конструктор класса Car
    public Car(string name, int engine, int maxSpeed)
    {
        Name = name;
        Engine = engine;
        MaxSpeed = maxSpeed;
    }

    // Переопределение метода ToString() для класса Car
    public override string ToString()
    {
        return Name;
    }

    // Приведение переданного объекта к типу Car.
    // Если приведение успешно, мы вызываем второй метод Equals(),
    // который принимает объект типа Car в качестве параметра
    public override bool Equals(object obj)
    {
        return Equals(obj as Car);
    }

    // Реализация метода Equals для интерфейса IEquatable<Car>
    public bool Equals(Car other)
    {
        if (other == null)
            return false;

        return Engine == other.Engine && MaxSpeed == other.MaxSpeed;
    }
    

}
class CarsCatalog
{
    private List<Car> cars;
    public int cout;

    public CarsCatalog()
    {
        cars = new List<Car>();
    }

    // Добавление автомобилей
    public void AddCar(Car car)
    {
        cars.Add(car);
        this.cout++;
    }

    // проверка индекса (нахождение в допустимом диапазоне)
    public Car this[int index]
    {
        get
        {
            if (index >= 0 && index < cars.Count)
                return cars[index];
            else
                throw new IndexOutOfRangeException("Index is out of range");
        }
    }
}



class Program
{
    static void Main()
    {
        CarsCatalog cars = new CarsCatalog();

        cars.cout = 0;
        Car car1 = new Car("Car 1", 2000, 200);
        Car car2 = new Car("Car 2", 3000, 250);
        Car car3 = new Car("Car 3", 2000, 200);

        // Add the cars to the catalog
        cars.AddCar(car1);
        cars.AddCar(car2);
        cars.AddCar(car3);

        // Access the cars in the catalog using indexing
        Console.WriteLine("Cars in catalog:");
        for (int i = 0; i < cars.cout; i++)
        {
            Console.WriteLine(cars[i]);
        }


        if (Equals(car1, car2))
            Console.WriteLine($"\n{car1} and {car2} are equal");
        else
            Console.WriteLine($"\n{car1} and {car2} are not equal");
        if (Equals(car1, car3))
            Console.WriteLine($"\n{car1} and {car3} are equal");      
        else
            Console.WriteLine($"\n{car1} and {car3} are not equal");
        if (Equals(car2, car3))
            Console.WriteLine($"\n{car2} and {car3} are equal");
        else
            Console.WriteLine($"\n{car2} and {car3} are not equal");
    }
}