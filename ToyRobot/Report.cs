using System;
using ToyRobot.Enums;
using ToyRobot.Interfaces;

namespace ToyRobot
{
    public class Report : IReport
    {
        public void Print(int x, int y, Face face)
        {
            Console.WriteLine("Output : {0} {1} {2}", x, y, face);
        }
    }
}
