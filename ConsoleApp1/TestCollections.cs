using CarCar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTestCollections
{
    public class TestCollections
    {
        private LinkedList<Car> _linkedList;
        private LinkedList<string> _stringLinkedList;
        private SortedDictionary<Car, string> _sortedDictionary;
        private SortedDictionary<string, Car> _stringSortedDictionary;

        public TestCollections(int count)
        {
            _linkedList = new LinkedList<Car>();
            _stringLinkedList = new LinkedList<string>();
            _sortedDictionary = new SortedDictionary<Car, string>(new CarComparer());
            _stringSortedDictionary = new SortedDictionary<string, Car>();

            for (int i = 0; i < count; i++)
            {
                Car car = new Car($"Brand{i}", 2000 + i, "Color", 100000 * i, 10 + i);
                _linkedList.AddLast(car);
                _stringLinkedList.AddLast(car.ToString());

                _sortedDictionary.Add(car, car.ToString());
                _stringSortedDictionary.Add(car.ToString(), car);
            }
        }

        public void MeasureSearchTime(int iterations = 10)
        {
            if (_linkedList.Count == 0 || _stringLinkedList.Count == 0 ||
                _sortedDictionary.Count == 0 || _stringSortedDictionary.Count == 0)
            {
                Console.WriteLine("Ошибка! Одна из коллекций пуста, поиск невозможен");
                return;
            }

            double linkedListTime = MeasureSearchTimeInCollection(
                () => _linkedList.Contains(_linkedList.First.Value), iterations);
            Console.WriteLine($"Среднее время поиска в LinkedList<Car>: {linkedListTime} мс");

            double stringLinkedListTime = MeasureSearchTimeInCollection(
                () => _stringLinkedList.Contains(_linkedList.First.Value.ToString()), iterations);
            Console.WriteLine($"Среднее время поиска в LinkedList<string>: {stringLinkedListTime} мс");

            double sortedDictionaryTime = MeasureSearchTimeInCollection(
                () => _sortedDictionary.ContainsKey(_linkedList.First.Value), iterations);
            Console.WriteLine($"Среднее время поиска в SortedDictionary<Car, string>: {sortedDictionaryTime} мс");

            double stringSortedDictionaryTime = MeasureSearchTimeInCollection(
                () => _stringSortedDictionary.ContainsKey(_linkedList.First.Value.ToString()), iterations);
            Console.WriteLine($"Среднее время поиска в SortedDictionary<string, Car>: {stringSortedDictionaryTime} мс");
        }

        private double MeasureSearchTimeInCollection(Func<bool> searchAction, int iterations)
        {
            Stopwatch stopwatch = new Stopwatch();
            double totalTime = 0;

            for (int i = 0; i < iterations; i++)
            {
                stopwatch.Restart();
                bool found = searchAction();
                stopwatch.Stop();

                totalTime += stopwatch.Elapsed.TotalMilliseconds;
            }

            return totalTime / iterations;
        }
    }

    public class CarComparer : IComparer<Car>
    {
        public int Compare(Car x, Car y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
}
