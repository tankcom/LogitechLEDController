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
                const int MaxRowsOnKeyboard = 10; // extract to config file?
                const int MaxElementsInRow  = 150;

                dynamic config = JsonConvert.DeserializeObject(json);
                string keyboardName = config.KeyboardName;
                string layoutName = config.LayoutName;
                var keyboard = new Keyboard(keyboardName, layoutName);

                Key[][] keys = new Key[MaxRowsOnKeyboard][];
                var rows = config.KeyboardKeys.Rows;

                int x = 0;
                int y = 0;
                foreach(var row in rows)
                {
                    var rowElements = new Key[MaxElementsInRow];
                    foreach(var key in row)
                    {
                        int code = key.Code;
                        string name = key.Name;
                        string label = key.Label;
                        rowElements[x] = new Key(KeyType.NormalKey, code, name, label);
                        x++;
                    }
                    keys[y] = rowElements;
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
