using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Enums;

namespace ToyRobot.Interfaces
{
    public interface IMove
    {
        int NextX { get; set; }
        int NextY { get; set; }
        void NextLocation(int currentX, int currentY, Face face);
    }
}
