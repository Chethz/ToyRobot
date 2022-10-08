using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Enums;

namespace ToyRobot.Interfaces
{
    public interface IReport
    {
        void Print(int x, int y, Face face);
    }
}
