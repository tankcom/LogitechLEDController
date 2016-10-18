using System;
using System.Collections.Generic;

namespace LogitechLEDController
{
    class Program
    {
        static void Main(string[] args)
        {
            var configPath = @"J:\projects\LogitechLEDController\src\LogitechLEDController\LogitechLEDController\KeyboardConfig\G910USANSI.json";
            var oreo = ConfigParser.ParseConfigFromFile(configPath);

            Console.ReadLine();
        }
    }
}
