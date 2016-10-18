using System.Collections.Generic;

namespace LogitechLEDController
{
    public class Key
    {
        public int Code { get; private set; }

        public string Name { get; private set; }

        public string Label { get; private set; }

        public int LogitechKeyCode { get; private set; }

        public Keyboard keyboard { private get; set; }

        public Key(int code, string name, string label)
        {
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
}


