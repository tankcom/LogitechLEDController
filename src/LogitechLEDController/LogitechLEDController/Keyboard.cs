using System;
using System.Collections.Generic;

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

        public Key GetNeightbourOfKey(Key key, RelativeKeyPosition pos)
        {

            switch (pos)
            {
                var coordinates = GetCoordinatesOfKey(key);
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
            return new KeyCoordinates(0, 0);
        }

        public Key GetKeyByCoordinates(KeyCoordinates coords)
        {
            return GetKeyByCoordinates(coords.X, coords.Y);
        }

        public Key GetKeyByCoordinates(int x, int y)
        {
            try 
            {
                return keys[x][y];
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
        }

        public void SetLighting(int red, int green, int blue)
        {
            sdk.SetGlobalLighting(red, green, blue);
        }

        // get key by name
        public Key GetKeyByName(string name)
        {
            foreach(Key key in keys)
            {
                if (key.Name == name)
                    return key;
            }
            return null;
        }
        // get key by label
        // get key by code
        // mit LINQ
        
    }
}
