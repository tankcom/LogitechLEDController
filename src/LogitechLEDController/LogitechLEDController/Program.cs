using System;
using System.Collections.Generic;

namespace LogitechLEDController
{
    class Program
    {
        static void Main(string[] args)
        {
            var configPath = @"J:\projects\LogitechLEDController\src\LogitechLEDController\LogitechLEDController\KeyboardConfig\G910DEISO.json";
            var orion = ConfigParser.ParseConfigFromFile(configPath);
            orion.SetLighting(0, 0, 0);

            // var z = orion.GetKeyByCharacter("g");

            var z = orion.GetKeyByCharacter("<");
           
              orion.SetLightingForKey(z, 100, 10, 10);
            // var text = "qwertzuiopü+";
            //orion.TypeText(text, 100, 0, 60); 

            /*
            var currentRow = orion.GetKeyByLabel("G6");
            while (true)
            {
                loopright(currentRow);
                if (!currentRow.HasNeighbour(RelativeKeyPosition.BOTTOM_CENTER)) break;
                currentRow = currentRow.GetNeighbour(RelativeKeyPosition.BOTTOM_CENTER);
            }
*/
            Console.ReadLine();
        }

        static void loopright(Key key)
        {
            var currentKey = key;
            while (true)
            {
                currentKey.SetLighting(100, 0, 100);
                if (!currentKey.HasNeighbour(RelativeKeyPosition.RIGHT)) break;
                currentKey = currentKey.GetNeighbour(RelativeKeyPosition.RIGHT);
            }
        }
    }
}
