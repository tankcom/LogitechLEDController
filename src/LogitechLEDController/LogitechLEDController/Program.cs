using System;
using System.Collections.Generic;

namespace LogitechLEDController
{
    class Program
    {
        static void Main(string[] args)
        {
            var configPath = @"J:\projects\LogitechLEDController\src\LogitechLEDController\ConsoleApplication1\KeyboardConfig\DefaultLayout.json";
            var oreo = ConfigParser.ParseConfigFromFile(configPath);

            Console.ReadLine();
        }
    }
}
