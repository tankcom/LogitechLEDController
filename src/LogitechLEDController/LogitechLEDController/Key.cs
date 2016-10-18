using System.Collections.Generic;

namespace LogitechLEDController
{
    public class Key
    {
        public int Code { get; set; }

        public string Name { get; set; }

        public string Label { get; set; }

        public int LogitechKeyCode { get; set; }

        private List<Key> neighbours;

        public Key(int code, string name, string label)
        {
            Code = code;
            Name = name;
            Label = label;
        }

        public void SetNeighbours(List<Key> keys)
        {
            neighbours.Clear();
            neighbours[0] = keys[0];
            neighbours[1] = keys[1];
            neighbours[2] = keys[2];
            neighbours[3] = keys[3];
            neighbours[5] = keys[5];
            neighbours[6] = keys[6];
            neighbours[7] = keys[7];
            neighbours[8] = keys[8];
        }

        public Key GetNeighbour(KeyPosition p)
        {
            if (p == KeyPosition.CENTER) return this;
            return neighbours[(int)p];
        }
    }

    public enum KeyPosition
    {
        TOP_LEFT = 0,
        TOP_CENTER = 1,
        TOP_RIGHT = 2,
        LEFT = 3,
        CENTER = 4,
        RIGHT = 5,
        BOTTOM_LEFT = 6,
        BOTTOM_CENTER = 7,
        BOTTOM_RIGHT = 8,

    }
}


