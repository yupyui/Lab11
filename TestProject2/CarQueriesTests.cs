using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using InterfacesAndClasses;
using CarQueries;

namespace Lab.Tests
{
    [TestClass]
    public class CarQueriesTests
    {
        public class IInitTests
        {
            [TestMethod]
            public void Car_Init_SetsBrandCorrectly()
            {
                var car = new Car();
                car.Init();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual("Unknown", car.Brand);
            }
            [TestMethod]
            public void Car_Init_SetsYearCorrectly()
            {
                var car = new Car();
                car.Init();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(2000, car.Year);
            }

            [TestMethod]
            public void Car_Init_SetsColorCorrectly()
            {
                var car = new Car();
                car.Init();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual("Black", car.Color); 
            }

            [TestMethod]
            public void Car_Init_SetsPriceCorrectly()
            {
                var car = new Car();
                car.Init();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(0, car.Price);
            }

            [TestMethod]
            public void Car_Init_SetsGroundClearanceCorrectly()
            {
                var car = new Car();
                car.Init();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(0, car.GroundClearance);
            }
            [TestMethod]
            public void Truck_Init_SetsLoadCapacityCorrectly()
            {
                var truck = new Truck();
                truck.Init();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(truck.LoadCapacity > 0);
            }
            [TestMethod]
            public void IInit_IsImplementedByCar()
            {
                var car = new Car();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(car is IInit);
            }

            [TestMethod]
            public void IInit_IsImplementedByPassengerCar()
            {
                var passengerCar = new PassengerCar();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(passengerCar is IInit);
            }

            [TestMethod]
            public void IInit_IsImplementedBySUV()
            {
                var suv = new SUV();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(suv is IInit);
            }

            [TestMethod]
            public void IInit_IsImplementedByTruck()
            {
                var truck = new Truck();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(truck is IInit);
            }
        }

        private List<Car> _cars;
        [TestInitialize]
        public void Initialize()
        {
            _cars = new List<Car>
        {
            new SUV("Ford", 2018, "Black", 600000, 25, true, "Sand"),
            new SUV("BMW", 2020, "White", 8000000, 15, false, "Mud"),
            new PassengerCar("Toyota", 2015, "Blue", 4500000, 20, 4, 250),
            new PassengerCar("Honda", 2017, "Red", 5000000, 18, 5, 220),
            new Truck("Volvo", 2019, "Red", 7000000, 30, 3000),
            new Truck("MAN", 2021, "Yellow", 6000000, 28, 2500)
        };
        }

        [TestMethod]
        public void GetMostExpensiveSUV_ReturnsCorrectSUV()
        {
            var result = CarQueries.CarQueries.GetMostExpensiveSUV(_cars);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("BMW", result.Brand);
        }

        [TestMethod]
        public void GetMostExpensiveSUV_ReturnsNull_WhenNoSUVsExist()
        {
            var cars = new List<Car>
        {
            new PassengerCar("Toyota", 2015, "Blue", 4500000, 20, 4, 250),
            new Truck("Volvo", 2019, "Red", 7000000, 30, 3000)
        };

            var result = CarQueries.CarQueries.GetMostExpensiveSUV(cars);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(result);
        }

        [TestMethod]
        public void GetAverageSpeedOfPassengerCars_ReturnsCorrectAverage()
        {
            double result = CarQueries.CarQueries.GetAverageSpeedOfPassengerCars(_cars);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(235, result);
        }

        [TestMethod]
        public void GetAverageSpeedOfPassengerCars_Returns0_WhenNoPassengerCarsExist()
        {
            var cars = new List<Car>
        {
            new SUV("Ford", 2018, "Black", 600000, 25, true, "Sand"),
            new Truck("Volvo", 2019, "Red", 7000000, 30, 3000)
        };

            double result = CarQueries.CarQueries.GetAverageSpeedOfPassengerCars(cars);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetColorsOfSUVsWithFourWheelDrive_ReturnsCorrectColors()
        {
            var result = CarQueries.CarQueries.GetColorsOfSUVsWithFourWheelDrive(_cars);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Black", result[0]);
        }

        [TestMethod]
        public void GetColorsOfSUVsWithFourWheelDrive_ReturnsEmptyList_WhenNoSUVsWithFourWheelDriveExist()
        {
            var cars = new List<Car>
        {
            new SUV("BMW", 2020, "White", 8000000, 15, false, "Mud"),
            new PassengerCar("Toyota", 2015, "Blue", 4500000, 20, 4, 250)
        };

            var result = CarQueries.CarQueries.GetColorsOfSUVsWithFourWheelDrive(cars);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetMostExpensiveCar_ReturnsCorrectCar()
        {
            var result = CarQueries.CarQueries.GetMostExpensiveCar(_cars);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("BMW", result.Brand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetMostExpensiveCar_ThrowsException_WhenListIsEmpty()
        {
            var cars = new List<Car>();
            CarQueries.CarQueries.GetMostExpensiveCar(cars);
        }

        [TestMethod]
        public void GetAveragePriceOfCars_ReturnsCorrectAverage()
        {
            double result = CarQueries.CarQueries.GetAveragePriceOfCars(_cars);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(5183333.33, result, 0.01);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetAveragePriceOfCars_ThrowsException_WhenListIsEmpty()
        {
            var cars = new List<Car>();
            CarQueries.CarQueries.GetAveragePriceOfCars(cars);
        }

        [TestMethod]
        public void GetSUVsWithFourWheelDrive_ReturnsCorrectCount()
        {
            var result = CarQueries.CarQueries.GetSUVsWithFourWheelDrive(_cars);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void GetSUVsWithFourWheelDrive_ReturnsEmptyList_WhenNoSUVsWithFourWheelDriveExist()
        {
            var cars = new List<Car>
        {
            new SUV("BMW", 2020, "White", 8000000, 15, false, "Mud"),
            new PassengerCar("Toyota", 2015, "Blue", 4500000, 20, 4, 250)
        };

            var result = CarQueries.CarQueries.GetSUVsWithFourWheelDrive(cars);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetPassengerCarsBySpeed_ReturnsCorrectCount()
        {
            var result = CarQueries.CarQueries.GetPassengerCarsBySpeed(_cars, 240);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void GetPassengerCarsBySpeed_ReturnsEmptyList_WhenNoPassengerCarsMeetCriteria()
        {
            var result = CarQueries.CarQueries.GetPassengerCarsBySpeed(_cars, 300);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetSUVsByPriceRange_ReturnsCorrectCount()
        {
            var result = CarQueries.CarQueries.GetSUVsByPriceRange(_cars, 500000, 9000000);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetSUVsByPriceRange_ReturnsEmptyList_WhenNoSUVsMeetCriteria()
        {
            var result = CarQueries.CarQueries.GetSUVsByPriceRange(_cars, 9000000, 10000000);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetCarsByColor_ReturnsCorrectCount()
        {
            var result = CarQueries.CarQueries.GetCarsByColor(_cars, "Red");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetCarsByColor_ReturnsEmptyList_WhenNoCarsWithSpecifiedColorExist()
        {
            var result = CarQueries.CarQueries.GetCarsByColor(_cars, "Green");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetSUVsByTerrain_ReturnsCorrectCount()
        {
            var result = CarQueries.CarQueries.GetSUVsByTerrain(_cars, "Mud");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void GetSUVsByTerrain_ReturnsEmptyList_WhenNoSUVsWithSpecifiedTerrainExist()
        {
            var result = CarQueries.CarQueries.GetSUVsByTerrain(_cars, "Snow");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetTrucksByLoadCapacity_ReturnsCorrectCount()
        {
            var result = CarQueries.CarQueries.GetTrucksByLoadCapacity(_cars, 2500);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetTrucksByLoadCapacity_ReturnsEmptyList_WhenNoTrucksMeetCriteria()
        {
            var result = CarQueries.CarQueries.GetTrucksByLoadCapacity(_cars, 4000);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetTrucksByPriceRange_ReturnsCorrectCount()
        {
            var result = CarQueries.CarQueries.GetTrucksByPriceRange(_cars, 5000000, 8000000);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetTrucksByPriceRange_ReturnsEmptyList_WhenNoTrucksMeetCriteria()
        {
            var result = CarQueries.CarQueries.GetTrucksByPriceRange(_cars, 9000000, 10000000);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, result.Count);
        }
    }

    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void Car_CompareTo_ReturnsPositive_WhenPriceIsNegative()
        {
            var car1 = new Car("Toyota", 2015, "Blue", -4500000, 20);
            var car2 = new Car("Honda", 2017, "Red", 5000000, 18);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(car1.CompareTo(car2) < 0);
        }
        [TestMethod]
        public void Car_Equals_ReturnsFalse_ForDifferentTypes()
        {
            var car = new Car("Toyota", 2015, "Blue", 4500000, 20);
            var passengerCar = new PassengerCar("Honda", 2017, "Red", 5000000, 18, 5, 220);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(car.Equals(passengerCar));
        }
        [TestMethod]
        public void Car_ShallowCopy_ReturnsNewObjectWithSameProperties()
        {
            var car = new Car("Toyota", 2015, "Blue", 4500000, 20);
            var shallowCopyCar = (Car)car.ShallowCopy();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(car.Brand, shallowCopyCar.Brand);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(car.Year, shallowCopyCar.Year);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(car.Color, shallowCopyCar.Color);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(car.Price, shallowCopyCar.Price);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(car.GroundClearance, shallowCopyCar.GroundClearance);
        }
        [TestMethod]
        public void Car_RandomInit_SetsRandomGroundClearance()
        {
            var car = new Car();
            var rand = new Random();
            car.RandomInit(rand);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(car.GroundClearance >= 10 && car.GroundClearance <= 30);
        }
        [TestMethod]
        public void Car_RandomInit_SetsRandomPrice()
        {
            var car = new Car();
            var rand = new Random();
            car.RandomInit(rand);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(car.Price >= 500000 && car.Price <= 10000000);
        }
        [TestMethod]
        public void Car_RandomInit_SetsRandomColor()
        {
            var car = new Car();
            var rand = new Random();
            car.RandomInit(rand);
            string[] expectedColors = { "Red", "Blue", "Black", "White", "Green" };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(expectedColors.Contains(car.Color));
        }
        [TestMethod]
        public void Car_Constructor_Default_BrandIsUnknown()
        {
            var car = new Car();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Unknown", car.Brand);
        }

        [TestMethod]
        public void Car_Constructor_Default_YearIs2000()
        {
            var car = new Car();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2000, car.Year);
        }

        [TestMethod]
        public void Car_Constructor_Default_ColorIsBlack()
        {
            var car = new Car();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Black", car.Color);
        }

        [TestMethod]
        public void Car_Constructor_Default_PriceIs0()
        {
            var car = new Car();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, car.Price);
        }

        [TestMethod]
        public void Car_Constructor_Default_GroundClearanceIs0()
        {
            var car = new Car();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, car.GroundClearance);
        }

        [TestMethod]
        public void Car_Constructor_WithParameters_BrandIsCorrect()
        {
            var car = new Car("Toyota", 2015, "Blue", 4500000, 20);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Toyota", car.Brand);
        }

        [TestMethod]
        public void Car_Constructor_WithParameters_YearIsCorrect()
        {
            var car = new Car("Toyota", 2015, "Blue", 4500000, 20);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(2015, car.Year);
        }

        [TestMethod]
        public void Car_Equals_ReturnsTrue_ForSameProperties()
        {
            var car1 = new Car("Toyota", 2015, "Blue", 4500000, 20);
            var car2 = new Car("Toyota", 2015, "Blue", 4500000, 20);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(car1.Equals(car2));
        }

        [TestMethod]
        public void Car_Equals_ReturnsFalse_ForDifferentProperties()
        {
            var car1 = new Car("Toyota", 2015, "Blue", 4500000, 20);
            var car2 = new Car("Honda", 2017, "Red", 5000000, 18);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(car1.Equals(car2));
        }

        [TestMethod]
        public void Car_Equals_ReturnsFalse_WhenComparingWithNull()
        {
            var car = new Car("Toyota", 2015, "Blue", 4500000, 20);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(car.Equals(null));
        }

        [TestMethod]
        public void Car_Equals_ReturnsFalse_WhenComparingWithDifferentType()
        {
            var car = new Car("Toyota", 2015, "Blue", 4500000, 20);
            var otherObject = new object();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(car.Equals(otherObject));
        }

        [TestMethod]
        public void Car_CompareTo_ReturnsNegative_WhenPriceIsLess()
        {
            var car1 = new Car("Toyota", 2015, "Blue", 4500000, 20);
            var car2 = new Car("Honda", 2017, "Red", 5000000, 18);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(car1.CompareTo(car2) < 0);
        }

        [TestMethod]
        public void Car_CompareTo_ReturnsZero_WhenPricesAreEqual()
        {
            var car1 = new Car("Toyota", 2015, "Blue", 4500000, 20);
            var car2 = new Car("Honda", 2017, "Red", 4500000, 18);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, car1.CompareTo(car2));
        }

        [TestMethod]
        public void Car_Clone_ReturnsNewObjectWithSameBrand()
        {
            var car = new Car("Toyota", 2015, "Blue", 4500000, 20);
            var clonedCar = (Car)car.Clone();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(car.Brand, clonedCar.Brand);
        }

        [TestMethod]
        public void Car_Clone_ReturnsNewObjectWithSameYear()
        {
            var car = new Car("Toyota", 2015, "Blue", 4500000, 20);
            var clonedCar = (Car)car.Clone();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(car.Year, clonedCar.Year);
        }

        [TestMethod]
        public void Car_Clone_ReturnsNewObjectWithSameGroundClearance()
        {
            var car = new Car("Toyota", 2015, "Blue", 4500000, 20);
            var clonedCar = (Car)car.Clone();
           Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(car.GroundClearance, clonedCar.GroundClearance);
        }

        [TestMethod]
        public void Car_ShallowCopy_ReturnsNewObjectWithSamePrice()
        {
            var car = new Car("Toyota", 2015, "Blue", 4500000, 20);
            var shallowCopyCar = (Car)car.ShallowCopy();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(car.Price, shallowCopyCar.Price);
        }

        [TestMethod]
        public void Car_ShallowCopy_ReturnsNewObjectWithSameGroundClearance()
        {
            var car = new Car("Toyota", 2015, "Blue", 4500000, 20);
            var shallowCopyCar = (Car)car.ShallowCopy();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(car.GroundClearance, shallowCopyCar.GroundClearance);
        }

        [TestMethod]
        public void Car_ToString_ReturnsCorrectString()
        {
            var car = new Car("Toyota", 2015, "Blue", 4500000, 20);
            string expected = "�����: Toyota, ��� �������: 2015, ����: Blue, ���������: 4500000, �������� �������: 20";
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, car.ToString());
        }
        [TestMethod]
        public void Car_Constructor_WithParameters_ColorIsCorrect()
        {
            var car = new Car("Toyota", 2015, "Blue", 4500000, 20);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Blue", car.Color);
        }

        [TestMethod]
        public void Car_Clone_ReturnsNewObjectWithSamePrice()
        {
            var car = new Car("Toyota", 2015, "Blue", 4500000, 20);
            var clonedCar = (Car)car.Clone();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(car.Price, clonedCar.Price);
        }

        [TestMethod]
        public void Car_ShallowCopy_ReturnsNewObjectWithSameColor()
        {
            var car = new Car("Toyota", 2015, "Blue", 4500000, 20);
            var shallowCopyCar = (Car)car.ShallowCopy();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(car.Color, shallowCopyCar.Color);
        }
    }

    [TestClass]
    public class PassengerCarTests
    {
        [TestMethod]
        public void PassengerCar_Init_HandlesInvalidInputForDoorsCount()
        {
            var passengerCar = new PassengerCar();
            using (var consoleInput = new StringReader("Toyota\n2020\nBlue\n4500000\n20\nInvalidDoorsCount\n4\n220"))
            {
                Console.SetIn(consoleInput);
                passengerCar.Init();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(4, passengerCar.DoorsCount);
            }
        }
        [TestMethod]
        public void Truck_ToString_ReturnsCorrectString()
        {
            var truck = new Truck("Volvo", 2019, "Red", 7000000, 30, 3000);
            string expected = "�����: Volvo, ��� �������: 2019, ����: Red, ���������: 7000000, �������� �������: 30, ����������������: 3000 ��";
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, truck.ToString());
        }
        [TestMethod]
        public void PassengerCar_RandomInit_SetsRandomMaxSpeed()
        {
            var passengerCar = new PassengerCar();
            var rand = new Random();
            passengerCar.RandomInit(rand);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(passengerCar.MaxSpeed >= 150 && passengerCar.MaxSpeed <= 250);
        }
        [TestMethod]
        public void PassengerCar_RandomInit_SetsRandomDoorsCount()
        {
            var passengerCar = new PassengerCar();
            var rand = new Random();
            passengerCar.RandomInit(rand);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(passengerCar.DoorsCount >= 2 && passengerCar.DoorsCount <= 5);
        }
        [TestMethod]
        public void PassengerCar_Constructor_Default_DoorsCountIs4()
        {
            var passengerCar = new PassengerCar();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(4, passengerCar.DoorsCount);
        }

        [TestMethod]
        public void PassengerCar_Constructor_Default_MaxSpeedIs200()
        {
            var passengerCar = new PassengerCar();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, passengerCar.MaxSpeed);
        }

        [TestMethod]
        public void PassengerCar_Constructor_WithParameters_DoorsCountIsCorrect()
        {
            var passengerCar = new PassengerCar("Honda", 2017, "Red", 5000000, 18, 5, 220);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(5, passengerCar.DoorsCount);
        }

        [TestMethod]
        public void PassengerCar_Equals_ReturnsTrue_ForSameProperties()
        {
            var car1 = new PassengerCar("Honda", 2017, "Red", 5000000, 18, 5, 220);
            var car2 = new PassengerCar("Honda", 2017, "Red", 5000000, 18, 5, 220);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(car1.Equals(car2));
        }

        [TestMethod]
        public void PassengerCar_ShallowCopy_ReturnsNewObjectWithSameMaxSpeed()
        {
            var passengerCar = new PassengerCar("Honda", 2017, "Red", 5000000, 18, 5, 220);
            var shallowCopyCar = (PassengerCar)passengerCar.ShallowCopy();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(passengerCar.MaxSpeed, shallowCopyCar.MaxSpeed);
        }

        [TestMethod]
        public void PassengerCar_ToString_ReturnsCorrectString()
        {
            var passengerCar = new PassengerCar("Honda", 2017, "Red", 5000000, 18, 5, 220);
            string expected = "�����: Honda, ��� �������: 2017, ����: Red, ���������: 5000000, �������� �������: 18, ���������� ������: 5, ������������ ��������: 220 ��/�";
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, passengerCar.ToString());
        }
        [TestMethod]
        public void PassengerCar_Constructor_WithParameters_MaxSpeedIsCorrect()
        {
            var passengerCar = new PassengerCar("Honda", 2017, "Red", 5000000, 18, 5, 220);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(220, passengerCar.MaxSpeed);
        }
    }

    [TestClass]
    public class SUVTests
    {
        [TestMethod]
        public void SUV_Init_HandlesInvalidInputForFourWheelDrive()
        {
            var suv = new SUV();
            using (var consoleInput = new StringReader("Toyota\n2020\nBlue\n4500000\n20\nInvalidFourWheelDrive\ntrue\nSand"))
            {
                Console.SetIn(consoleInput);
                suv.Init();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(suv.FourWheelDrive);
            }
        }
        [TestMethod]
        public void SUV_RandomInit_SetsRandomTerrainType()
        {
            var suv = new SUV();
            var rand = new Random();
            suv.RandomInit(rand);
            string[] expectedTerrains = { "Sand", "Mud", "Snow", "Rock" };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(expectedTerrains.Contains(suv.TerrainType));
        }
        [TestMethod]
        public void SUV_RandomInit_SetsRandomFourWheelDrive()
        {
            var suv = new SUV();
            var rand = new Random();
            suv.RandomInit(rand);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(suv.FourWheelDrive || !suv.FourWheelDrive);
        }
        [TestMethod]
        public void SUV_Constructor_Default_FourWheelDriveIsFalse()
        {
            var suv = new SUV();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(suv.FourWheelDrive);
        }

        [TestMethod]
        public void SUV_Constructor_Default_TerrainTypeIsUnknown()
        {
            var suv = new SUV();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Unknown", suv.TerrainType);
        }

        [TestMethod]
        public void SUV_Constructor_WithParameters_FourWheelDriveIsCorrect()
        {
            var suv = new SUV("BMW", 2020, "White", 8000000, 15, true, "Mud");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(suv.FourWheelDrive);
        }

        [TestMethod]
        public void SUV_Equals_ReturnsTrue_ForSameProperties()
        {
            var suv1 = new SUV("BMW", 2020, "White", 8000000, 15, true, "Mud");
            var suv2 = new SUV("BMW", 2020, "White", 8000000, 15, true, "Mud");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(suv1.Equals(suv2));
        }

        [TestMethod]
        public void SUV_ShallowCopy_ReturnsNewObjectWithSameTerrainType()
        {
            var suv = new SUV("BMW", 2020, "White", 8000000, 15, true, "Mud");
            var shallowCopySUV = (SUV)suv.ShallowCopy();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(suv.TerrainType, shallowCopySUV.TerrainType);
        }

        [TestMethod]
        public void SUV_ToString_ReturnsCorrectString()
        {
            var suv = new SUV("BMW", 2020, "White", 8000000, 15, true, "Mud");
            string expected = "�����: BMW, ��� �������: 2020, ����: White, ���������: 8000000, �������� �������: 15, ������ ������: True, ��� ���������: Mud";
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, suv.ToString());
        }
        [TestMethod]
        public void SUV_Constructor_WithParameters_TerrainTypeIsCorrect()
        {
            var suv = new SUV("BMW", 2020, "White", 8000000, 15, true, "Mud");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Mud", suv.TerrainType);
        }
    }

    [TestClass]
    public class TruckTests
    {
        [TestMethod]
        public void Truck_Init_HandlesInvalidInputForLoadCapacity()
        {
            var truck = new Truck();
            using (var consoleInput = new StringReader("Toyota\n2020\nBlue\n4500000\n20\nInvalidLoadCapacity\n3000"))
            {
                Console.SetIn(consoleInput);
                truck.Init();
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(3000, truck.LoadCapacity);
            }
        }
        [TestMethod]
        public void Truck_ShallowCopy_ReturnsNewObjectWithSameProperties()
        {
            var truck = new Truck("Volvo", 2019, "Red", 7000000, 30, 3000);
            var shallowCopyTruck = (Truck)truck.ShallowCopy();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(truck.Brand, shallowCopyTruck.Brand);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(truck.LoadCapacity, shallowCopyTruck.LoadCapacity);
        }
        [TestMethod]
        public void Truck_RandomInit_SetsRandomLoadCapacity()
        {
            var truck = new Truck();
            var rand = new Random();
            truck.RandomInit(rand);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(truck.LoadCapacity >= 1000 && truck.LoadCapacity <= 5000);
        }
        [TestMethod]
        public void Truck_Constructor_Default_LoadCapacityIs0()
        {
            var truck = new Truck();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(0, truck.LoadCapacity);
        }

        [TestMethod]
        public void Truck_Constructor_WithParameters_LoadCapacityIsCorrect()
        {
            var truck = new Truck("Volvo", 2019, "Red", 7000000, 30, 3000);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(3000, truck.LoadCapacity);
        }

        [TestMethod]
        public void Truck_Equals_ReturnsTrue_ForSameProperties()
        {
            var truck1 = new Truck("Volvo", 2019, "Red", 7000000, 30, 3000);
            var truck2 = new Truck("Volvo", 2019, "Red", 7000000, 30, 3000);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(truck1.Equals(truck2));
        }

        [TestMethod]
        public void Truck_ShallowCopy_ReturnsNewObjectWithSameLoadCapacity()
        {
            var truck = new Truck("Volvo", 2019, "Red", 7000000, 30, 3000);
            var shallowCopyTruck = (Truck)truck.ShallowCopy();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(truck.LoadCapacity, shallowCopyTruck.LoadCapacity);
        }

        [TestMethod]
        public void Truck_ToString_ReturnsCorrectString()
        {
            var truck = new Truck("Volvo", 2019, "Red", 7000000, 30, 3000);
            string expected = "�����: Volvo, ��� �������: 2019, ����: Red, ���������: 7000000, �������� �������: 30, ����������������: 3000 ��";
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, truck.ToString());
        }
        [TestMethod]
        public void Car_RandomInit_SetsRandomBrand()
        {
            var car = new Car();
            var rand = new Random();
            car.RandomInit(rand);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(car.Brand == "Toyota" || car.Brand == "Ford" || car.Brand == "BMW" || car.Brand == "Audi" || car.Brand == "Mercedes");
        }

        [TestMethod]
        public void Car_RandomInit_SetsRandomYear()
        {
            var car = new Car();
            var rand = new Random();
            car.RandomInit(rand);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(car.Year >= 2000 && car.Year <= 2023);
        }
    }
}
