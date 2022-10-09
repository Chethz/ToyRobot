using System;
using System.Reflection;
using ToyRobot;
using ToyRobot.Enums;
using ToyRobot.Interfaces;
using Xunit;

namespace ToyRobotTests
{
    public class RobotTests
    {
        private ITable _table;
        private IReport _report;
        private IMove _move;
        private IRobot _robot;

        public RobotTests()
        {
            _table = new Table(5, 5);
            _report = new Report();
            _move = new Move();
            _robot = new Robot(_table, _move, _report);
        }

        [Fact]
        public void PlaceRobot_XPositionIsTwo()
        {
            _robot.PlaceRobot(2, 2, "NORTH");

            Assert.Equal(2, _robot.XPosition);
        }

        [Fact]
        public void PlaceRobot_YPositionIsTwo()
        {
            _robot.PlaceRobot(2, 2, "NORTH");

            Assert.Equal(2, _robot.YPosition);
        }

        [Fact]
        public void PlaceRobot_FaceIsNorth()
        {
            _robot.PlaceRobot(2, 2, "NORTH");

            Assert.Equal(Face.NORTH, _robot.Face);
        }

        [Fact]
        public void PlaceRobot_WhenTableIsNull_ReturnException()
        {
            IRobot robot = new Robot(null, _move, _report);

            Action result = () => robot.PlaceRobot(2, 2, "NORTH");

            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Please add table.", exception.Message);
        }

        [Fact]
        public void PlaceRobot_WhenInValidPosition_ReturnException()
        {
            Action result = () => _robot.PlaceRobot(6, 6, "NORTH");

            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Can't place the robot on the table, Invalid position", exception.Message);
        }

        [Fact]
        public void PlaceRobot_WhenEmptyFace_ReturnException()
        {
            Action result = () => _robot.PlaceRobot(3, 3, "");

            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Empty face command", exception.Message);
        }

        [Fact]
        public void PlaceRobot_WhenInValidFace_ReturnException()
        {
            Action result = () => _robot.PlaceRobot(3, 3, "FACE");

            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Invalid face command : FACE", exception.Message);
        }

        [Fact]
        public void Move_WhenIsPlacedFalse_IgnoreMove()
        {
            var xBeforeMove = _robot.XPosition;
            var yBeforeMove = _robot.YPosition;

            _robot.Move();

            Assert.Equal(xBeforeMove, _robot.XPosition);
            Assert.Equal(yBeforeMove, _robot.YPosition);
        }

        [Fact]
        public void Move_WhenInvalidPosition_ReturnException()
        {
            _robot.PlaceRobot(5, 5, "NORTH");

            Action result = () => _robot.Move();

            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Cannot move in to requested position.", exception.Message);
        }

        [Fact]
        public void TurnRobot_WhenTurnLeftWhileFaceNorth_ReturnWest()
        {
            _robot.PlaceRobot(3, 3, "NORTH");
            _robot.TurnRobot("LEFT");

            Assert.Equal(Face.WEST, _robot.Face);
        }

        [Fact]
        public void TurnRobot_WhenTurnRightWhileFaceNorth_ReturnEast()
        {
            _robot.PlaceRobot(3, 3, "NORTH");
            _robot.TurnRobot("RIGHT");

            Assert.Equal(Face.EAST, _robot.Face);
        }

        [Fact]
        public void TurnRobot_WhenRobotIsNotPlaced_ReturnException()
        {
            IRobot robot = new Robot(null, _move, _report);

            Action result = () => robot.TurnRobot("RIGHT");
            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Robot is not placed on the table", exception.Message);
        }

        [Fact]
        public void TurnRobot_WhenInvalidTurnCommandGiven_ReturnException()
        {
            _robot.PlaceRobot(3, 3, "NORTH");
            Action result = () => _robot.TurnRobot("RIGGHT");
            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Invalid turn command : RIGGHT", exception.Message);
        }

        [Fact]
        public void TurnRobot_WhenInvalidleftTurnCommandGiven_ReturnException()
        {
            _robot.PlaceRobot(3, 3, "NORTH");
            Action result = () => _robot.TurnRobot("LEF");
            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Invalid turn command : LEF", exception.Message);
        }

        [Fact]
        public void TurnRobot_WhenNullOrEmptyCommandGiven_ReturnException()
        {
            _robot.PlaceRobot(3, 3, "NORTH");
            Action result = () => _robot.TurnRobot("");
            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Empty turn command", exception.Message);
        }
    }
}
