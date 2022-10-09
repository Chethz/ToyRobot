using System;
using ToyRobot;
using ToyRobot.Interfaces;

namespace ToyRobotSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Simulator simulator = new Simulator();

            var stopApplication = false;
            Console.WriteLine("Toy Robot Simulator Started");
            Console.WriteLine("Please place the robot to start the simulator. Table size is 5 x 5.");
            Console.WriteLine("Please enter EXIT to exit the simulator");
            Console.WriteLine("----------------------------------------------- \n");
            do
            {
                var command = Console.ReadLine();
                if (command == null) continue;

                if (command.ToUpper().Equals("EXIT"))
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
