using ToyRobot.Enums;

namespace ToyRobot.Interfaces
{
    public interface IRobot
    {
        int XPosition { get; set; }
        int YPosition { get; set; }
        Face Face { get; set; }
        bool IsPlaced { get; }
        void Report();
        void Move();
        void TurnRobot(string command);
        void PlaceRobot(int x, int y, string face);
    }
}
