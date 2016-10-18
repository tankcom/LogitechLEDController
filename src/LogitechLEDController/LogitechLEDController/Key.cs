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

        public Key GetNeighbour(KeyPosition pos)
        {
            if (pos == KeyPosition.CENTER) return this;
            return keyboard.getNeightbour(this, pos);
        }
    }
}


