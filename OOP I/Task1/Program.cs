using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the oil of car : ");
            Car car = new()
            {
                serialNumber = 1,
                name = "Bmw",
                brand = "M5",
                oilLiter = Convert.ToInt32(Console.ReadLine()),
                color = "Black",
                isAuto = true,
                year = 2024
            };


            car.GetAllInformation();
            Console.WriteLine($"Oil : {car.GetOilLiter()} litr");
            Console.WriteLine("Can be driven : " + car.Driving());
        }
    }
}
