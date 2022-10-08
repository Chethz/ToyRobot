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
        [Fact]
        public void Print()
        {
            IReport report = new Report();

            var output = new StringWriter();
            Console.SetOut(output);

            report.Print(2, 2, Face.NORTH);

            var outputString = output.ToString();

            Assert.Equal("Output : 2 2 NORTH\r\n", outputString);
        }
    }
}
