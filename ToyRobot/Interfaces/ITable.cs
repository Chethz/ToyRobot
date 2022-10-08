using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot.Interfaces
{
    public interface ITable
    {
        int Width { get; }
        int Length { get; }
        bool IsValidPlace(int x, int y);
    }
}
