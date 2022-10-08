using System;
using ToyRobot;
using ToyRobot.Interfaces;

namespace ToyRobotSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITable table = new Table(5, 5);
            IMove move = new Move();
            IReport report = new Report();
            IRobot robot = new Robot(table, move, report);

            Simulator simulator = new Simulator(table, robot);

            var stopApplication = false;
            Console.WriteLine("Toy Robot Simulator Started");
            Console.WriteLine("Please place robot to start simulator");
            do
            {
                var command = Console.ReadLine();
                if (command == null) continue;

                if (command.Equals("EXIT"))
                    stopApplication = true;
                else
                {
                    try
                    {
                        simulator.ProcessCommand(command);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            } while (!stopApplication);
        }
    }
}
