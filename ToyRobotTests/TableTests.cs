
using ToyRobot;
using Xunit;

namespace ToyRobotTests
{
    public class TableTests
    {
        [Fact]
        public void IsValidPlace_WhenValidPlace_ReturnTrue()
        {
            Table table = new Table(5, 5);
            var result = table.IsValidPlace(3, 3);

            Assert.True(result);
        }

        [Fact]
        public void IsValidPlace_WhenXIsInValidPlace_ReturnFalse()
        {
            Table table = new Table(5, 5);
            var result = table.IsValidPlace(6, 3);

            Assert.False(result);
        }

        [Fact]
        public void IsValidPlace_WhenYIsInValidPlace_ReturnFalse()
        {
            Table table = new Table(5, 5);
            var result = table.IsValidPlace(3, 6);

            Assert.False(result);
        }

        [Fact]
        public void IsValidPlace_WhenBothAreInValidPlaces_ReturnFalse()
        {
            Table table = new Table(5, 5);
            var result = table.IsValidPlace(6, 6);

            Assert.False(result);
        }

        [Fact]
        public void IsValidPlace_WhenValuesAreLessThanZero_ReturnFalse()
        {
            Table table = new Table(5, 5);
            var result = table.IsValidPlace(-1, -6);

            Assert.False(result);
        }

        [Fact]
        public void IsValidPlace_WhenValuesAreZero_ReturnTrue()
        {
            Table table = new Table(5, 5);
            var result = table.IsValidPlace(0, 0);

            Assert.True(result);
        }
    }
}
