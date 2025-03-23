using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCar
{
    public class Car : IInit, IComparable<Car>, ICloneable
    {
        public string Brand { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public double GroundClearance { get; set; }

        public Car()
        {
            Brand = "Unknown";
            Year = 2000;
            Color = "Black";
            Price = 0;
            GroundClearance = 0;
        }

        public Car(string brand, int year, string color, double price, double groundClearance)
        {
            Brand = brand;
            Year = year;
            Color = color;
            Price = price;
            GroundClearance = groundClearance;
        }

        public virtual void Show()
        {
            Console.WriteLine($"Бренд: {Brand}, Год выпуска: {Year}, Цвет: {Color}, Стоимость: {Price}, Дорожный просвет: {GroundClearance}");
        }

        public virtual void Init()
        {
            try
            {
                Console.Write("Введите бренд: ");
                Brand = Console.ReadLine();
                Console.Write("Введите год выпуска: ");
                Year = int.Parse(Console.ReadLine());
                Console.Write("Введите цвет: ");
                Color = Console.ReadLine();
                Console.Write("Введите стоимость: ");
                Price = double.Parse(Console.ReadLine());
                Console.Write("Введите дорожный просвет: ");
                GroundClearance = double.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка! Пожалуйста, введите корректные данные.");
                Init();
            }
        }

        public virtual void RandomInit(Random rand)
        {
            string[] brands = { "Toyota", "Ford", "BMW", "Audi", "Mercedes" };
            string[] colors = { "Red", "Blue", "Black", "White", "Green" };

            Brand = brands[rand.Next(brands.Length)];
            Year = rand.Next(2000, 2023);
            Color = colors[rand.Next(colors.Length)];
            Price = rand.Next(500000, 10000000);
            GroundClearance = rand.Next(10, 30);
        }

        public override bool Equals(object obj)
        {
            if (obj is Car car)
            {
                return Brand == car.Brand && Year == car.Year && Color == car.Color && Price == car.Price && GroundClearance == car.GroundClearance;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Бренд: {Brand}, Год выпуска: {Year}, Цвет: {Color}, Стоимость: {Price}, Дорожный просвет: {GroundClearance}";
        }

        public int CompareTo(Car other) => Price.CompareTo(other.Price);

        public int CompareTo(object obj)
        {
            if (obj is Car other)
            {
                return Price.CompareTo(other.Price);
            }
            throw new ArgumentException("Объект не является типом Car");
        }

        public object Clone()
        {
            return new Car(Brand, Year, Color, Price, GroundClearance);
        }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        public virtual Car GetBase()
        {
            return new Car(Brand, Year, Color, Price, GroundClearance);
        }
    }
}
