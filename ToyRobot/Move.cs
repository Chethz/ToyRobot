using System;
using System.Collections.Generic;
using System.Text;
using ToyRobot.Enums;
using ToyRobot.Interfaces;

namespace ToyRobot
{
    public class Move : IMove
    {
        public int NextX { get; set; }
        public int NextY { get; set; }

        public void NextLocation(int currentX, int currentY, Face face)
        {
            this.NextX = currentX;
            this.NextY = currentY;

            switch (face)
            {
                case Face.NORTH:
                    NextY += 1;
                    break;
                case Face.SOUTH:
                    NextY -= 1;
                    break;
                case Face.EAST:
                    NextX += 1;
                    break;
                case Face.WEST:
                    NextX -= 1;
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
