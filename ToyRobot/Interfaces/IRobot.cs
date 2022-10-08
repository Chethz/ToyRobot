using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Enums;

namespace ToyRobot.Interfaces
{
    public interface IRobot
    {
        int XPosition { get; set; }
        int YPosition { get; set; }
        Face Face { get; set; }
        void Report();
        void Move();
        void TurnRobot(string command);
        void PlaceRobot(int x, int y, string face);
    }
}
