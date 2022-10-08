using System;
using ToyRobot;
using ToyRobot.Enums;
using ToyRobot.Interfaces;
using Xunit;

namespace ToyRobotTests
{
    public class RobotTests
    {
        [Fact]
        public void PlaceRobot_XPositionIsTwo()
        {
            ITable table = new Table(5, 5);
            IReport report = new Report();
            IMove move = new Move();
            IRobot robot = new Robot(table, move, report);

            robot.PlaceRobot(2, 2, "NORTH");

            Assert.Equal(2, robot.XPosition);
        }

        [Fact]
        public void PlaceRobot_YPositionIsTwo()
        {
            ITable table = new Table(5, 5);
            IReport report = new Report();
            IMove move = new Move();
            IRobot robot = new Robot(table, move, report);

            robot.PlaceRobot(2, 2, "NORTH");

            Assert.Equal(2, robot.YPosition);
        }

        [Fact]
        public void PlaceRobot_FaceIsNorth()
        {
            ITable table = new Table(5, 5);
            IReport report = new Report();
            IMove move = new Move();
            IRobot robot = new Robot(table, move, report);

            robot.PlaceRobot(2, 2, "NORTH");

            Assert.Equal(Face.NORTH, robot.Face);
        }

        [Fact]
        public void PlaceRobot_WhenTableIsNull_ReturnException()
        {
            IReport report = new Report();
            IMove move = new Move();
            IRobot robot = new Robot(null, move, report);

            Action result = () => robot.PlaceRobot(2, 2, "NORTH");

            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Please add table.", exception.Message);
        }

        [Fact]
        public void PlaceRobot_WhenInValidPosition_ReturnException()
        {
            ITable table = new Table(5, 5);
            IReport report = new Report();
            IMove move = new Move();
            IRobot robot = new Robot(table, move, report);

            Action result = () => robot.PlaceRobot(6, 6, "NORTH");

            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Can't place the robot on the table, Invalid position", exception.Message);
        }

        [Fact]
        public void PlaceRobot_WhenInValidFace_ReturnException()
        {
            ITable table = new Table(5, 5);
            IReport report = new Report();
            IMove move = new Move();
            IRobot robot = new Robot(table, move, report);

            Action result = () => robot.PlaceRobot(3, 3, "");

            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Empty face command", exception.Message);
        }

        [Fact]
        public void Move_WhenIsPlacedFalse_ReturnNegetiveOne()
        {
            ITable table = new Table(5, 5);
            IReport report = new Report();
            IMove move = new Move();
            IRobot robot = new Robot(table, move, report);

            robot.Move();

            Assert.Equal(-1, robot.XPosition);
        }

        [Fact]
        public void Move_WhenInvalidPosition_ReturnException()
        {
            ITable table = new Table(5, 5);
            IReport report = new Report();
            IMove move = new Move();
            IRobot robot = new Robot(table, move, report);

            robot.PlaceRobot(5, 5, "NORTH");

            Action result = () => robot.Move();

            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Cannot move in to requested position.", exception.Message);
        }

        [Fact]
        public void TurnRobot_WhenTurnLeftWhileFaceNorth_ReturnWest()
        {
            ITable table = new Table(5, 5);
            IReport report = new Report();
            IMove move = new Move();
            IRobot robot = new Robot(table, move, report);

            robot.PlaceRobot(3, 3, "NORTH");
            robot.TurnRobot("LEFT");

            Assert.Equal(Face.WEST, robot.Face);
        }

        [Fact]
        public void TurnRobot_WhenTurnRightWhileFaceNorth_ReturnEast()
        {
            ITable table = new Table(5, 5);
            IReport report = new Report();
            IMove move = new Move();
            IRobot robot = new Robot(table, move, report);

            robot.PlaceRobot(3, 3, "NORTH");
            robot.TurnRobot("RIGHT");

            Assert.Equal(Face.EAST, robot.Face);
        }

        [Fact]
        public void TurnRobot_WhenRobotIsNotPlaced_ReturnException()
        {
            IReport report = new Report();
            IMove move = new Move();
            IRobot robot = new Robot(null, move, report);

            Action result = () => robot.TurnRobot("RIGHT");
            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Robot is not placed on the table", exception.Message);
        }

        [Fact]
        public void TurnRobot_WhenInvaliTurnCommandGiven_ReturnException()
        {
            ITable table = new Table(5, 5);
            IReport report = new Report();
            IMove move = new Move();
            IRobot robot = new Robot(table, move, report);

            robot.PlaceRobot(3, 3, "NORTH");
            Action result = () => robot.TurnRobot("RIGGHT");
            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Invalid command : RIGGHT", exception.Message);
        }

        [Fact]
        public void TurnRobot_WhenNullOrEmptyCommandGiven_ReturnException()
        {
            ITable table = new Table(5, 5);
            IReport report = new Report();
            IMove move = new Move();
            IRobot robot = new Robot(table, move, report);

            robot.PlaceRobot(3, 3, "NORTH");
            Action result = () => robot.TurnRobot("");
            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Empty turn command", exception.Message);
        }
    }
}
