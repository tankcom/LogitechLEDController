using System.Collections.Generic;

namespace LogitechLEDController
{
    public class Key
    {
        public KeyType Type { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public int Code { get; private set; }

        public string Name { get; private set; }

        public string Label { get; private set; }

        public Keyboard keyboard { private get; set; }

        public Key(KeyType type, int code, string name, string label, int width = 1, int height = 1)
        {
            Type = type;
            Width = width;
            Height = height;
            Code = code;
            Name = name;
            Label = label;
            keyboard = null;
        }

        public Key GetNeighbour(RelativeKeyPosition pos)
        {
            if (pos == RelativeKeyPosition.CENTER) return this;
            return keyboard.GetNeightbourOfKey(this, pos);
        }
    }

    public enum KeyType
    {
        Spacer = 1,
        NormalKey = 2,
    }
}


