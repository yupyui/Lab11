using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarCar;

namespace SUVCar
{
    public class SUV : Car
    {
        public override Car GetBase()
        {
            return new Car(Brand, Year, Color, Price, GroundClearance);
        }

        public bool FourWheelDrive { get; set; }
        public string TerrainType { get; set; }

        public SUV() : base()
        {
            FourWheelDrive = false;
            TerrainType = "Unknown";
        }

        public SUV(string brand, int year, string color, double price, double groundClearance, bool fourWheelDrive, string terrainType)
            : base(brand, year, color, price, groundClearance)
        {
            FourWheelDrive = fourWheelDrive;
            TerrainType = terrainType;
        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Полный привод: {FourWheelDrive}, Тип местности: {TerrainType}");
        }

        public override void Init()
        {
            base.Init();

            bool isValidInput = false;
            while (!isValidInput)
            {
                try
                {
                    Console.Write("Есть полный привод (true/false): ");
                    string input = Console.ReadLine();
                    Console.WriteLine($"Введено значение для полного приводв: {input}"); //отладка
                    if (string.IsNullOrEmpty(input))
                    {
                        throw new ArgumentNullException(nameof(input), "Ошибка!Ввод не может быть пустым");
                    }
                    FourWheelDrive = bool.Parse(input);
                    isValidInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Пожалуйста, введите 'true' или 'false'.");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Ошибка! Ввод не может быть пустым.");
                }
            }
            isValidInput = false;
            while (!isValidInput)
            {
                try
                {
                    Console.Write("Введите тип местности: ");
                    string input = Console.ReadLine();
                    Console.WriteLine($"Введено значение для типа местности: {input}"); //отладка
                    if (string.IsNullOrEmpty(input))
                    {
                        throw new ArgumentNullException(nameof(input), "Ошибка! Ввод не может быть пустым");
                    }
                    TerrainType = input;
                    isValidInput = true;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Ошибка ввода. Ввод не может быть пустым.Ошибка!Ввод не может быть пустым");
                }
            }
        }

        public override void RandomInit(Random rand)
        {
            base.RandomInit(rand);
            FourWheelDrive = rand.Next(2) == 1;
            string[] terrains = { "Sand", "Mud", "Snow", "Rock" };
            TerrainType = terrains[rand.Next(terrains.Length)];
        }

        public override string ToString()
        {
            return base.ToString() + $", Полный привод: {FourWheelDrive}, Тип местности: {TerrainType}";
        }
    }
}
