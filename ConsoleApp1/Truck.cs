using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarCar;

namespace TruckCar
{
    public class Truck : Car
    {
        public override Car GetBase()
        {
            return new Car(Brand, Year, Color, Price, GroundClearance);
        }

        public double LoadCapacity { get; set; }

        public Truck() : base()
        {
            LoadCapacity = 0;
        }

        public Truck(string brand, int year, string color, double price, double groundClearance, double loadCapacity)
            : base(brand, year, color, price, groundClearance)
        {
            LoadCapacity = loadCapacity;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Грузоподъёмность: {LoadCapacity} кг");
        }

        public override void Init()
        {
            base.Init();
            bool isValidInput = false;
            while (!isValidInput)
            {
                try
                {
                    Console.Write("Введите грузоподъёмность: ");
                    string input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        throw new ArgumentNullException(nameof(input), "Ошибка! Ввод не может быть пустым");
                    }
                    LoadCapacity = double.Parse(input);
                    isValidInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка!Пожалуйста, введите корректное число");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Ошибка! Ввод не может быть пустым");
                }
            }
        }
        public override void RandomInit(Random rand)
        {
            base.RandomInit(rand);
            LoadCapacity = rand.Next(1000, 5000);
        }

        public override string ToString()
        {
            return base.ToString() + $", Грузоподъёмность: {LoadCapacity} кг";
        }
    }
}
