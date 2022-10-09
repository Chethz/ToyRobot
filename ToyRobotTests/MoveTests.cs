using ToyRobot;
using ToyRobot.Enums;
using ToyRobot.Interfaces;
using Xunit;

namespace ToyRobotTests
{
    public class MoveTests
    {
        private IMove _move;

        public MoveTests()
        {
            _move = new Move();
        }

        [Fact]
        public void NextLocation_WhenFaceNorth_NextYSouldBeThree()
        {
            _move.NextX = 2;
            _move.NextY = 2;

            _move.NextLocation(2, 2, Face.NORTH);

            Assert.True(_move.NextY == 3);
        }

        [Fact]
        public void NextLocation_WhenFaceEast_NextXSouldBeThree()
        {
            _move.NextX = 2;
            _move.NextY = 2;

            _move.NextLocation(2, 2, Face.EAST);

            Assert.True(_move.NextX == 3);
        }

        [Fact]
        public void NextLocation_WhenFaceSouth_NextYSouldBeOne()
        {
            _move.NextX = 2;
            _move.NextY = 2;

            _move.NextLocation(2, 2, Face.SOUTH);

            Assert.True(_move.NextY == 1);
        }

        [Fact]
        public void NextLocation_WhenFaceWest_NextXSouldBeOne()
        {
            _move.NextX = 2;
            _move.NextY = 2;

            _move.NextLocation(2, 2, Face.WEST);

            Assert.True(_move.NextX == 1);
        }
    }
}
