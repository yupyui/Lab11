using SUVCar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckCar;
using CarCar;
using CarTestCollections;

namespace Collections
{
    public class CarCollection
    {
        public class CarComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                if (x is Car carX && y is Car carY)
                {
                    return carX.Price.CompareTo(carY.Price);
                }
                throw new ArgumentException("Объекты не являются типом Car");
            }
        }

        public static void TestArrayList()
        {
            ArrayList cars = new ArrayList();

            cars.Add(new Car("Toyota", 2015, "Blue", 4500000, 20));
            cars.Add(new SUV("Ford", 2018, "Black", 600000, 25, true, "Sand"));
            cars.Add(new Truck("Volvo", 2019, "Red", 7000000, 30, 3000));

            Console.WriteLine("Все автомобили в коллекции:");
            foreach (Car car in cars)
            {
                car.Show();
            }

            cars.RemoveAt(1);

            ArrayList clonedCars = (ArrayList)cars.Clone();

            cars.Sort(new CarComparer());

            Console.WriteLine("\nКоллекция после сортировки по цене:");
            foreach (Car car in cars)
            {
                car.Show();
            }

            Car searchCar = new Car("Toyota", 2015, "Blue", 4500000, 20);
            if (cars.Contains(searchCar))
            {
                Console.WriteLine("Автомобиль найден в коллекции");
            }
            else
            {
                Console.WriteLine("Автомобиль не найден в коллекции");
            }
        }

        public static void TestSortedDictionary()
        {
            SortedDictionary<string, Car> cars = new SortedDictionary<string, Car>();

            cars.Add("Toyota", new Car("Toyota", 2015, "Blue", 4500000, 20));
            cars.Add("Ford", new SUV("Ford", 2018, "Black", 600000, 25, true, "Sand"));
            cars.Add("Volvo", new Truck("Volvo", 2019, "Red", 7000000, 30, 3000));

            Console.WriteLine("Все автомобили в коллекции:");
            foreach (var car in cars)
            {
                Console.WriteLine($"Ключ: {car.Key}");
                car.Value.Show();
            }

            cars.Remove("Ford");

            SortedDictionary<string, Car> clonedCars = new SortedDictionary<string, Car>(cars);

            if (cars.ContainsKey("Toyota"))
            {
                Console.WriteLine("Автомобиль Toyota найден в коллекции");
            }
            else
            {
                Console.WriteLine("Автомобиль Toyota не найден в коллекции");
            }
        }
    }
}
