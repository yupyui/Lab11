using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarCar;

namespace PassengerCarCar
{
    public class PassengerCar : Car
    {
        public override Car GetBase()
        {
            return new Car(Brand, Year, Color, Price, GroundClearance);
        }

        public int DoorsCount { get; set; }
        public double MaxSpeed { get; set; }

        public PassengerCar() : base("Unknown", 2000, "Black", 0, 0)
        {
            DoorsCount = 4;
            MaxSpeed = 200;
        }

        public PassengerCar(string brand, int year, string color, double price, double groundClearance, int doorsCount, double maxSpeed)
            : base(brand, year, color, price, groundClearance)
        {
            DoorsCount = doorsCount;
            MaxSpeed = maxSpeed;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Количество дверей: {DoorsCount}, Максимальная скорость: {MaxSpeed} км/ч");
        }

        public override void Init()
        {
            base.Init();

            bool isValidInput = false;
            while (!isValidInput)
            {
                try
                {
                    Console.Write("Введите количество дверей: ");
                    DoorsCount = int.Parse(Console.ReadLine());

                    Console.Write("Введите максимальную скорость: ");
                    MaxSpeed = double.Parse(Console.ReadLine());

                    isValidInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Пожалуйста, введите корректные данные");
                }
            }
        }

        public override void RandomInit(Random rand)
        {
            base.RandomInit(rand);
            DoorsCount = rand.Next(2, 5);
            MaxSpeed = rand.Next(150, 250);
        }

        public override string ToString()
        {
            return base.ToString() + $", Количество дверей: {DoorsCount}, Максимальная скорость: {MaxSpeed} км/ч";
        }
    }
}
