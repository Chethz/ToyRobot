using System;
using System.IO;
using ToyRobot;
using ToyRobot.Enums;
using ToyRobot.Interfaces;
using Xunit;

namespace ToyRobotTests
{
    public class ReportTests
    {
        private IReport _report;

        public ReportTests()
        {
            _report = new Report();
        }

        [Fact]
        public void Print()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            _report.Print(2, 2, Face.NORTH);

            var outputString = output.ToString();

            Assert.Equal("Output : 2 2 NORTH\r\n", outputString);
        }
    }
}
