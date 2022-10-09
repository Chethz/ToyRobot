using ToyRobotSimulator;
using ToyRobot;
using ToyRobot.Interfaces;
using Xunit;
using System;
using ToyRobot.Enums;
using System.IO;
using System.Reflection;

namespace ToyRobotSimulatorTests
{
    public class ToyRobotSimulatorTests
    {
        private Simulator _simulator;

        public ToyRobotSimulatorTests()
        {
            _simulator = new Simulator();
        }

        [Fact]
        public void ProcessCommand_WhenPassedInValidCommand_Throwexception()
        {
            Action result = () => _simulator.ProcessCommand("RUN");
            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Command is not valid : RUN", exception.Message);
        }

        [Fact]
        public void ProcessCommand_WhenPassedInValidPlaceCommand_Returnexception()
        {
            Action result = () => _simulator.ProcessCommand("PLACE A, B, NORTH");

            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Invalid X or Y command.", exception.Message);
        }

        [Fact]
        public void ProcessCommand_WhenPassedPlaceCommandWithTab_PlacedRobot()
        {
            _simulator.ProcessCommand("PLACE   2, 3, NORTH");
            IRobot _robot = (IRobot)_simulator.GetType().GetField("_robot", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_simulator);

            Assert.Equal(2, _robot.XPosition);
        }


        [Fact]
        public void ProcessCommand_WhenPlaceRobot_PlacedOnTable()
        {
            _simulator.ProcessCommand("PLACE 2, 2, NORTH");
            IRobot _robot = (IRobot)_simulator.GetType().GetField("_robot", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_simulator);

            Assert.Equal(2, _robot.XPosition);
        }

        [Fact]
        public void ProcessCommand_WhenMove_MoveRobot()
        {
            _simulator.ProcessCommand("PLACE 2, 2, NORTH");
            _simulator.ProcessCommand("MOVE");
            IRobot _robot = (IRobot)_simulator.GetType().GetField("_robot", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_simulator);

            Assert.Equal(3, _robot.YPosition);
        }

        [Fact]
        public void ProcessCommand_WhenInvalidMove_ThrowException()
        {
            _simulator.ProcessCommand("PLACE 2, 2, NORTH");
            Action result = () => _simulator.ProcessCommand("MO0VE");
            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Command is not valid : MO0VE", exception.Message);
        }

        [Fact]
        public void ProcessCommand_WhenMoveWithSpaceAtFront_MoveRobot()
        {
            _simulator.ProcessCommand("PLACE 2, 2, NORTH");
            _simulator.ProcessCommand(" MOVE");
            IRobot _robot = (IRobot)_simulator.GetType().GetField("_robot", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_simulator);

            Assert.Equal(3, _robot.YPosition);
        }

        [Fact]
        public void ProcessCommand_WhenTurnLeft_TurnRobot()
        {
            _simulator.ProcessCommand("PLACE 2, 2, NORTH");
            _simulator.ProcessCommand("LEFT");
            IRobot _robot = (IRobot)_simulator.GetType().GetField("_robot", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_simulator);

            Assert.Equal(Face.WEST, _robot.Face);
        }

        [Fact]
        public void ProcessCommand_WhenTurnRight_TurnRobot()
        {
            _simulator.ProcessCommand("PLACE 2, 2, NORTH");
            _simulator.ProcessCommand("RIGHT");
            IRobot _robot = (IRobot)_simulator.GetType().GetField("_robot", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetValue(_simulator);

            Assert.Equal(Face.EAST, _robot.Face);
        }

        [Fact]
        public void ProcessCommand_WhenReport_PrintReport()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            _simulator.ProcessCommand("PLACE 2, 2, NORTH");
            _simulator.ProcessCommand("REPORT");

            var outputString = output.ToString();

            Assert.Equal("Output : 2 2 NORTH\r\n", outputString);
        }
    }
}
