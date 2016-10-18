using System;
using System.Collections.Generic;
using System.Threading;

namespace LogitechLEDController
{
    public class Keyboard
    {
        public string KeyboardName { get; set; }
        public string LayoutName { get; set; }

        private Key[][] keys;
        private LogitechLEDSDKWrapper sdk;

        public Keyboard(string keyboardName, string layoutName)
        {
            if (string.IsNullOrWhiteSpace(keyboardName))
                throw new ArgumentException("KeyboardName is empty.");
            if (string.IsNullOrWhiteSpace(layoutName))
                throw new ArgumentException("LayoutName is empty.");

            KeyboardName = keyboardName;
            LayoutName = layoutName;

            keys = null;
            sdk = new LogitechLEDSDKWrapper();
        }

        public Key GetNeighbourOfKey(Key key, RelativeKeyPosition pos)
        {
            var coordinates = GetCoordinatesOfKey(key);
            switch (pos)
            {
                case RelativeKeyPosition.TOP_LEFT:
                    coordinates.X--;
                    coordinates.Y--;
                    return GetKeyByCoordinates(coordinates);
                case RelativeKeyPosition.TOP_CENTER:
                    coordinates.Y--;
                    return GetKeyByCoordinates(coordinates);
                case RelativeKeyPosition.TOP_RIGHT:
                    coordinates.X++;
                    coordinates.Y--;
                    return GetKeyByCoordinates(coordinates);
                case RelativeKeyPosition.LEFT:
                    coordinates.X--;
                    return GetKeyByCoordinates(coordinates);
                case RelativeKeyPosition.CENTER:
                    return key;
                case RelativeKeyPosition.RIGHT:
                    coordinates.X++;
                    return GetKeyByCoordinates(coordinates);
                case RelativeKeyPosition.BOTTOM_LEFT:
                    coordinates.X--;
                    coordinates.Y++;
                    return GetKeyByCoordinates(coordinates);
                case RelativeKeyPosition.BOTTOM_CENTER:
                    coordinates.Y++;
                    return GetKeyByCoordinates(coordinates);
                case RelativeKeyPosition.BOTTOM_RIGHT:
                    coordinates.X++;
                    coordinates.Y++;
                    return GetKeyByCoordinates(coordinates);
                default:
                    return null; // what to do here
            }
        }

        public KeyCoordinates GetCoordinatesOfKey(Key key)
        {
            // TODO max values hard coded --> config
            for (int y = 0; y <= 10; y++)
                for (int x = 0; x <= 150; x++)
                    if (key == GetKeyByCoordinates(x, y))
                        return new KeyCoordinates(x, y);
            return null;
        }

        public Key GetKeyByCoordinates(KeyCoordinates coords)
        {
            return GetKeyByCoordinates(coords.X, coords.Y);
        }

        public Key GetKeyByCoordinates(int x, int y)
        {
            try 
            {
                return keys[y][x];
            }
            catch(IndexOutOfRangeException)
            {
                return null;
            }
        }

        public void SetKeys(Key[][] newKeys)
        {
            // Previous keys will be overwritten!
            keys = newKeys;
            foreach (Key[] row in keys)
                if (row != null)
                foreach (Key key in row)
                {
                    if (key != null)
                        key.keyboard = this;
                }
        }

        public List<Key> GetAllKeys()
        {
            var allkeys = new List<Key>();
            foreach (Key[] row in keys)
                if (row != null) 
                    foreach (Key key in row)
                    {
                        if (key != null && key.Type == KeyType.NormalKey)
                            allkeys.Add(key);
                    }
            return allkeys;
        }
        
        public Key GetKeyByName(string name)
        {
            foreach (Key key in GetAllKeys())
                if (key.Name == name)
                    return key;
            return null;
        }

        public Key GetKeyByLabel(string label)
        {
            foreach (Key key in GetAllKeys())
                if (key.Label == label)
                    return key;
            return null;
        }

        public Key GetKeyByCode(int code)
        {
            foreach (Key key in GetAllKeys())
                if (key.Code == code)
                    return key;
            return null;
        }

        public Key GetKeyByCharacter(char character)
        {
            return GetKeyByCharacter(character.ToString());
        }

        public Key GetKeyByCharacter(string character)
        {
            foreach (Key key in GetAllKeys())
                if (key.CanPrintCharacter(character.ToLowerInvariant()))
                    return key;
            return null;
        }

        public void SetLighting(int red, int green, int blue)
        {
            sdk.SetGlobalLighting(red, green, blue);
        }

        public void SetLightingForKey(Key key, int red, int green, int blue)
        {

            sdk.SetKeyLighting(key.Code, red, green, blue);
        }

        public void HighlightText(string text, int red, int green, int blue)
        {
            foreach(char c in text)
            {
                var currentKey = GetKeyByCharacter(c);
                currentKey.SetLighting(red, green, blue);
            }
        }

        public void TypeText(string text, int red, int green, int blue)
        {
            foreach (char c in text)
            {
                var currentKey = GetKeyByCharacter(c);
                currentKey.SetLighting(red, green, blue);
                Thread.Sleep(70);
                currentKey.SetLighting(10, 100, 100);
            }
        }
    }
}
