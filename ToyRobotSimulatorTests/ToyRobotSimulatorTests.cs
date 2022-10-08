using ToyRobotSimulator;
using ToyRobot;
using ToyRobot.Interfaces;
using Xunit;
using System;

namespace ToyRobotSimulatorTests
{
    public class ToyRobotSimulatorTests
    {
        [Fact]
        public void ProcessCommand_WhenPassedInValidCommand_Throwexception()
        {
            ITable table = new Table(5, 5);
            IMove move = new Move();
            IReport report = new Report();
            IRobot robot = new Robot(table, move, report);

            var Simulator = new Simulator(table, robot);

            Action result = () => Simulator.ProcessCommand("RUN");
            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Command is not valid : RUN", exception.Message);
        }

        [Fact]
        public void ProcessCommand_WhenPassedInValidPlaceCommand_Returnexception()
        {
            ITable table = new Table(5, 5);
            IMove move = new Move();
            IReport report = new Report();
            IRobot robot = new Robot(table, move, report);

            var Simulator = new Simulator(table, robot);

            Action result = () => Simulator.ProcessCommand("PLACE A, B, NORTH");

            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Invalid place command.", exception.Message);
        }


        [Fact]
        public void ProcessCommand_WhenPlaceRobot_PlacedOnTable()
        {
            ITable table = new Table(5, 5);
            IMove move = new Move();
            IReport report = new Report();
            IRobot robot = new Robot(table, move, report);

            var Simulator = new Simulator(table, robot);

            Simulator.ProcessCommand("PLACE 2, 2, NORTH");

            Assert.Equal(2, robot.XPosition);
        }

        [Fact]
        public void ProcessCommand_WhenMove_MoveRobot()
        {
            ITable table = new Table(5, 5);
            IMove move = new Move();
            IReport report = new Report();
            IRobot robot = new Robot(table, move, report);

            var Simulator = new Simulator(table, robot);

            Simulator.ProcessCommand("PLACE 2, 2, NORTH");
            Simulator.ProcessCommand("MOVE");
            Assert.Equal(3, robot.YPosition);
        }

        [Fact]
        public void ProcessCommand_WhenInvalidMove_ThrowException()
        {
            ITable table = new Table(5, 5);
            IMove move = new Move();
            IReport report = new Report();
            IRobot robot = new Robot(table, move, report);

            var Simulator = new Simulator(table, robot);

            Simulator.ProcessCommand("PLACE 2, 2, NORTH");
            Action result = () => Simulator.ProcessCommand("MO0VE");
            Exception exception = Assert.Throws<Exception>(result);

            Assert.Equal("Command is not valid : MO0VE", exception.Message);
        }

        [Fact]
        public void ProcessCommand_WhenMoveWithSpaceAtFront_MoveRobot()
        {
            ITable table = new Table(5, 5);
            IMove move = new Move();
            IReport report = new Report();
            IRobot robot = new Robot(table, move, report);

            var Simulator = new Simulator(table, robot);

            Simulator.ProcessCommand("PLACE 2, 2, NORTH");
            Simulator.ProcessCommand(" MOVE");

            Assert.Equal(3, robot.YPosition);
        }

        [Fact]
        public void ProcessCommand_WhenTurnLeft_TurnRobot()
        {
            ITable table = new Table(5, 5);
            IMove move = new Move();
            IReport report = new Report();
            IRobot robot = new Robot(table, move, report);

            var Simulator = new Simulator(table, robot);

            Simulator.ProcessCommand("PLACE 2, 2, NORTH");
            Simulator.ProcessCommand("LEFT");

            Assert.Equal(Face.WEST, robot.Face);
        }

        [Fact]
        public void ProcessCommand_WhenTurnRight_TurnRobot()
        {
            ITable table = new Table(5, 5);
            IMove move = new Move();
            IReport report = new Report();
            IRobot robot = new Robot(table, move, report);

            var Simulator = new Simulator(table, robot);

            Simulator.ProcessCommand("PLACE 2, 2, NORTH");
            Simulator.ProcessCommand("RIGHT");

            Assert.Equal(Face.EAST, robot.Face);
        }

        [Fact]
        public void ProcessCommand_WhenReport_PrintReport()
        {
            ITable table = new Table(5, 5);
            IMove move = new Move();
            IReport report = new Report();
            IRobot robot = new Robot(table, move, report);

            var Simulator = new Simulator(table, robot);
            var output = new StringWriter();
            Console.SetOut(output);

            Simulator.ProcessCommand("PLACE 2, 2, NORTH");
            Simulator.ProcessCommand("REPORT");

            var outputString = output.ToString();

            Assert.Equal("Output : 2 2 NORTH\r\n", outputString);
        }
    }
}
