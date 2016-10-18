using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LogitechLEDController
{
    public static class ConfigParser
    {
        public static Keyboard ParseConfigFromFile(string filePath)
        {
            var content = "";
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    content = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                return null; // TODO handle exceptions
            }
            return ConfigParser.ParseConfigFromString(content);
        }

        public static Keyboard ParseConfigFromString(string json)
        {
            try
            {
                const int MaxRowsOnKeyboard = 8;

                dynamic config = JsonConvert.DeserializeObject(json);
                string keyboardName = config.KeyboardName;
                string layoutName = config.LayoutName;
                var keyboard = new Keyboard(keyboardName, layoutName);

                Key[,] keys = new Key[,]{};
                var rows = config.KeyboardKeys.Rows;

                int x = 0;
                int y = 0;
                foreach(var row in rows)
                {
                    foreach(var key in row)
                    {
                        int code = key.Code;
                        string name = key.Name;
                        string label = key.Label;
                        var k = new Key(code, name, label);
                        keys[x, y] = k; // TODO this could throw an error if the array is not big enough
                        x++;
                    }
                    y++;
                }

                keyboard.SetKeys(keys);
                return keyboard;
            }
            catch(Exception e)
            {
                return null; // TODO handle exceptions
            }
            return null;
        }
    }
}
