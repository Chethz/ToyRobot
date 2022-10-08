using System;
using ToyRobot.Enums;
using ToyRobot.Interfaces;

namespace ToyRobot
{
    public class Robot : IRobot
    {
        private IMove _move;
        private ITable _table;
        private IReport _report;
        private int _xPosition = -1;
        private int _yPosition = -1;
        private Face _face;
        private bool IsPlaced = false;

        int IRobot.XPosition { get => _xPosition; set => _xPosition = value; }
        int IRobot.YPosition { get => _yPosition; set => _yPosition = value; }
        Face IRobot.Face { get => _face; set => _face = value; }

        public Robot(ITable table, IMove move, IReport report)
        {
            _move = move;
            _table = table;
            _report = report;
        }

        public void Move()
        {
            if (!IsPlaced)
            {
                return;
            }

            _move.NextLocation(_xPosition, _yPosition, _face);
            if (_table.IsValidPlace(_move.NextX, _move.NextY))
            {
                _xPosition = _move.NextX;
                _yPosition = _move.NextY;
            }
            else
            {
                throw new Exception("Cannot move in to requested position.");
            }
        }

        public void PlaceRobot(int x, int y, string face)
        {
            if (_table == null)
            {
                throw new Exception("Please add table.");
            }

            if (!_table.IsValidPlace(x, y))
            {
                throw new Exception("Can't place the robot on the table, Invalid position");
            }

            _xPosition = x;
            _yPosition = y;
            _face = GetFace(face);
            IsPlaced = true;
        }

        public void Report()
        {
            if (IsPlaced)
            {
                _report.Print(_xPosition, _yPosition, _face);
            }
        }

        public void TurnRobot(string command)
        {
            if (IsPlaced)
            {
                Side turnCommand = GetTurnCommand(command);

                if (turnCommand == Side.LEFT)
                {
                    _face = TurnLeft(_face);
                }
                else
                {
                    _face = TurnRight(_face);
                }
            }
            else
            {
                throw new Exception("Robot is not placed on the table");
            }
        }

        private Face TurnLeft(Face face)
        {
            var newFace = face;
            switch (face)
            {
                case Face.NORTH:
                    newFace = Face.WEST;
                    break;
                case Face.SOUTH:
                    newFace = Face.EAST;
                    break;
                case Face.EAST:
                    newFace = Face.NORTH;
                    break;
                case Face.WEST:
                    newFace = Face.SOUTH;
                    break;
            }
            return newFace;
        }

        private Face TurnRight(Face face)
        {
            var newFace = face;
            switch (face)
            {
                case Face.NORTH:
                    newFace = Face.EAST;
                    break;
                case Face.SOUTH:
                    newFace = Face.WEST;
                    break;
                case Face.EAST:
                    newFace = Face.SOUTH;
                    break;
                case Face.WEST:
                    newFace = Face.NORTH;
                    break;
            }
            return newFace;
        }

        private Face GetFace(string inputFace)
        {
            if (string.IsNullOrEmpty(inputFace))
            {
                throw new Exception("Empty face command");
            }

            inputFace = inputFace.Trim().ToUpper();

            switch (inputFace)
            {
                case "NORTH":
                    return Face.NORTH;
                case "SOUTH":
                    return Face.SOUTH;
                case "EAST":
                    return Face.EAST;
                case "WEST":
                    return Face.WEST;
                default:
                    throw new Exception("Invalid face");
            }
        }

        private Side GetTurnCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new Exception("Empty turn command");
            }

            command = command.Trim().ToUpper();

            switch (command)
            {
                case "LEFT":
                    return Side.LEFT;
                case "RIGHT":
                    return Side.RIGHT;
                default:
                    throw new Exception("Invalid command : " + command);
            }
        }
    }
}
