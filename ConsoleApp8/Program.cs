using Interface;
using CarCar;
using PassengerCarCar;
using SUVCar;
using TruckCar;
using System.Linq;
using System.Collections.Generic;
using System;
using Collections;
using CarTestCollections;

namespace MainProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            Random rand = new Random();

            Console.WriteLine("Выберите способ создания объектов:");
            Console.WriteLine("1. Вручную (с клавиатуры)");
            Console.WriteLine("2. Автоматически (случайные значения)");
            Console.Write("Выберите способ: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("\nВведите данные для легкового автомобиля:");
                PassengerCar passengerCar = new PassengerCar();
                passengerCar.Init();
                cars.Add(passengerCar);

                Console.WriteLine("\nВведите данные для внедорожника:");
                SUV suv = new SUV();
                suv.Init();
                cars.Add(suv);

                Console.WriteLine("\nВведите данные для грузовика:");
                TruckCar.Truck truck = new TruckCar.Truck();
                truck.Init();
                cars.Add(truck);
            }
            else if (choice == 2)
            {
                for (int i = 0; i < 20; i++)
                {
                    Car car;
                    switch (i % 3)
                    {
                        case 0:
                            car = new PassengerCar();
                            break;
                        case 1:
                            car = new SUV();
                            break;
                        case 2:
                            car = new TruckCar.Truck();
                            break;
                        default:
                            car = new Car();
                            break;
                    }
                    car.RandomInit(rand);
                    cars.Add(car);
                }
            }
            else
            {
                Console.WriteLine("Ошибка! Неверный выбор");
                return;
            }

            Console.WriteLine("\nИнформация о всех автомобилях:");
            foreach (var car in cars)
            {
                car.Show();
                Console.WriteLine();
            }

            Console.WriteLine("\nВыполнение запросов:");

            SUV mostExpensiveSUV = CarQueries.CarQueries.GetMostExpensiveSUV(cars);
            if (mostExpensiveSUV != null)
            {
                Console.WriteLine("Самый дорогой внедорожник:");
                mostExpensiveSUV.Show();
            }
            else
            {
                Console.WriteLine("Внедорожники не найдены");
            }

            double averageSpeed = CarQueries.CarQueries.GetAverageSpeedOfPassengerCars(cars);
            Console.WriteLine($"Средняя (максимальная) скорость легковых автомобилей: {averageSpeed} км/ч");

            Console.Write("Введите минимальную грузоподъёмность для поиска грузовиков: ");
            double minLoadCapacity = double.Parse(Console.ReadLine());
            List<TruckCar.Truck> trucksWithHighLoadCapacity = CarQueries.CarQueries.GetTrucksByLoadCapacity(cars, minLoadCapacity);
            if (trucksWithHighLoadCapacity.Any())
            {
                Console.WriteLine();
                Console.WriteLine($"Грузовики с грузоподъёмностью выше {minLoadCapacity} кг:");
                foreach (var truck in trucksWithHighLoadCapacity)
                {
                    truck.Show();
                }
            }
            else
            {
                Console.WriteLine("Грузовики с указанной грузоподъёмностью не найдены");
            }

            //1
            Console.WriteLine();
            Console.WriteLine("ArrayList");
            CarCollection.TestArrayList();

            //2
            Console.WriteLine("\nSortedDictionary");
            CarCollection.TestSortedDictionary();

            //3
            Console.WriteLine("\nТестирование коллекций");
            TestCollections testCollections = new TestCollections(1000);
            testCollections.MeasureSearchTime();
        }
    }
}