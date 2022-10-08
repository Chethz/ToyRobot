using ToyRobot.Interfaces;

namespace ToyRobot
{
    public class Table : ITable
    {
        private int _length;
        private int _width;

        public int Length { get => _length; }
        public int Width { get => _width; }

        public Table(int length, int width)
        {
            _length = length;
            _width = width;
        }

        public bool IsValidPlace(int x, int y)
        {
            return (x >= 0 && x <= Width && y >= 0 && y <= Length);
        }
    }
}
