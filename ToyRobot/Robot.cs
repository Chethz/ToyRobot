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
        private bool _isPlaced = false;

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
            if (!_isPlaced)
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
            _isPlaced = true;
        }

        public void Report()
        {
            if (_isPlaced)
            {
                _report.Print(_xPosition, _yPosition, _face);
            }
        }

        public void TurnRobot(string command)
        {
            if (_isPlaced)
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
            switch (face)
            {
                case Face.NORTH:
                    return Face.WEST;
                case Face.SOUTH:
                    return Face.EAST;
                case Face.EAST:
                    return Face.NORTH;
                case Face.WEST:
                    return Face.SOUTH;
                default:
                    throw new Exception("Invalid turn command : " + face);
            }
        }

        private Face TurnRight(Face face)
        {
            switch (face)
            {
                case Face.NORTH:
                    return Face.EAST;
                case Face.SOUTH:
                    return Face.WEST;
                case Face.EAST:
                    return Face.SOUTH;
                case Face.WEST:
                    return Face.NORTH;
                default: 
                    throw new Exception("Invalid turn command : " + face);
            }
        }

        private Face GetFace(string face)
        {
            if (string.IsNullOrEmpty(face))
            {
                throw new Exception("Empty face command");
            }

            face = face.Trim().ToUpper();

            switch (face)
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
                    throw new Exception("Invalid face command : " + face);
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
                    throw new Exception("Invalid turn command : " + command);
            }
        }
    }
}
