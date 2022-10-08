using ToyRobot;
using ToyRobot.Enums;
using Xunit;

namespace ToyRobotTests
{
    public class MoveTests
    {
        [Fact]
        public void NextLocation_WhenFaceNorth_NextYSouldBeThree()
        {
            Move move = new Move();
            move.NextX = 2;
            move.NextY = 2;

            move.NextLocation(2, 2, Face.NORTH);

            Assert.True(move.NextY == 3);
        }

        [Fact]
        public void NextLocation_WhenFaceEast_NextXSouldBeThree()
        {
            Move move = new Move();
            move.NextX = 2;
            move.NextY = 2;

            move.NextLocation(2, 2, Face.EAST);

            Assert.True(move.NextX == 3);
        }

        [Fact]
        public void NextLocation_WhenFaceSouth_NextYSouldBeOne()
        {
            Move move = new Move();
            move.NextX = 2;
            move.NextY = 2;

            move.NextLocation(2, 2, Face.SOUTH);

            Assert.True(move.NextY == 1);
        }

        [Fact]
        public void NextLocation_WhenFaceWest_NextXSouldBeOne()
        {
            Move move = new Move();
            move.NextX = 2;
            move.NextY = 2;

            move.NextLocation(2, 2, Face.WEST);

            Assert.True(move.NextX == 1);
        }
    }
}
