using System;
using System.Collections.Generic;

namespace LogitechLEDController
{
    public class Key
    {
        public KeyType Type { get; private set; }

        public int Code { get; private set; }

        public string Name { get; private set; }

        public string Label { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public string PrintableCharacters { get; private set; }

        public Keyboard keyboard { private get; set; }

        public Key(KeyType type, int code, string name, string label, int width = 1, int height = 1, string characters = "")
        {
            Type = type;
            Code = code;
            Name = name;
            Label = label;
            Width = width;
            Height = height;
            PrintableCharacters = characters;
            keyboard = null;
        }

        public Key GetNeighbour(RelativeKeyPosition pos)
        {
            if (pos == RelativeKeyPosition.CENTER) return this;
            return keyboard.GetNeighbourOfKey(this, pos);
        }
        public bool HasNeighbour(RelativeKeyPosition pos)
        {
            if (pos == RelativeKeyPosition.CENTER) return true;
            return (keyboard.GetNeighbourOfKey(this, pos) != null);
        }

        public bool CanPrintCharacter(string character)
        {
            return PrintableCharacters.Contains(character);
        }
        public void SetLighting(int red,int green, int blue)
        {
            if (null == keyboard) throw new ArgumentException($"Keyboard is not set in key { Name }.");
            keyboard.SetLightingForKey(this ,red, green, blue);
        }
    }

    public enum KeyType
    {
        Spacer = 1,
        NormalKey = 2,
    }
}


