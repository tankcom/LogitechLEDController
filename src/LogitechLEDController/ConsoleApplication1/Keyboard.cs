using System;
using System.Collections.Generic;

namespace LogitechLEDController
{
    public class Keyboard
    {
        public string KeyboardName { get; set; }
        public string LayoutName { get; set; }

        private List<Key> keys;
        private LogitechLEDSDKWrapper sdk;

        public Keyboard(string keyboardName, string layoutName)
        {
            if (string.IsNullOrWhiteSpace(keyboardName))
                throw new ArgumentException("KeyboardName is empty.");
            if (string.IsNullOrWhiteSpace(layoutName))
                throw new ArgumentException("LayoutName is empty.");

            KeyboardName = keyboardName;
            LayoutName = layoutName;

            keys = new List<Key>();
            sdk = new LogitechLEDSDKWrapper();
        }

        public void SetKeys(List<Key> newKeys)
        {
            keys.Clear();
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
