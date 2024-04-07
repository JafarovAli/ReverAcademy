using System;

namespace Task1
{
    public class Car
    {
        public int serialNumber;
        public string name;
        public string brand;
        public decimal oilLiter;
        public string color;
        public bool isAuto;
        public int year;

        public bool Driving()
        {
            return oilLiter > 0;
        }
        public decimal GetOilLiter()
        {
            return oilLiter;
        }

        public void GetAllInformation()
        {
            Console.WriteLine("Information about the car!");
            Console.WriteLine($" Serial number : {serialNumber}\n Name : {name}\n Brand: {brand}\n Oil : {oilLiter} litr\n" +
                              $" Color : {color}\n isAuto : {isAuto}\n Year : {year}\n");
        }
    }
}
