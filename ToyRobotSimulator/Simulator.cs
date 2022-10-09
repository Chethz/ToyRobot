using System;
using System.Text.RegularExpressions;
using ToyRobot;
using ToyRobot.Interfaces;

namespace ToyRobotSimulator
{
    public class Simulator
    {
        private ITable _table = new Table(5, 5);
        private IMove _move = new Move();
        private IReport _report = new Report();
        private IRobot _robot;

        public Simulator()
        {
            _robot = new Robot(_table, _move, _report);
        }


        public void ProcessCommand(string input)
        {
            string commands = input.Trim().ToUpper();

            Regex place = new Regex(@"^PLACE ");
            Regex move = new Regex(@"^MOVE$");
            Regex left = new Regex(@"^LEFT$");
            Regex right = new Regex(@"^RIGHT$");
            Regex report = new Regex(@"^REPORT$");


            if (place.IsMatch(commands))
            {
                commands = commands.Substring(5).Trim();
                ParsePlaceCommand(commands);
            }
            else if (move.IsMatch(commands))
            {
                _robot.Move();
            }
            else if (left.IsMatch(commands))
            {
                _robot.TurnRobot(commands);
            }
            else if (right.IsMatch(commands))
            {
                _robot.TurnRobot(commands);
            }
            else if (report.IsMatch(commands))
            {
                _robot.Report();
            }
            else
            {
                throw new Exception("Command is not valid : " + input);
            }
        }


        private void ParsePlaceCommand(string command)
        {
            string[] coordinates = command.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (coordinates.Length == 3)
            {
                int x;
                int y;

                if (int.TryParse(coordinates[0], out x) && int.TryParse(coordinates[1], out y))
                {
                    _robot.PlaceRobot(x, y, coordinates[2]);
                }
                else
                {
                    throw new Exception("Invalid X or Y command.");
                }
            }
            else
            {
                throw new Exception("Invalid place command.");
            }
        }
    }
}
