
using ToyRobot;
using ToyRobot.Interfaces;
using Xunit;

namespace ToyRobotTests
{
    public class TableTests
    {
        private ITable _table;

        public TableTests()
        {
            _table = new Table(5, 5);
        }

        [Fact]
        public void IsValidPlace_WhenValidPlace_ReturnTrue()
        {
            var result = _table.IsValidPlace(3, 3);

            Assert.True(result);
        }

        [Fact]
        public void IsValidPlace_WhenXIsInValidPlace_ReturnFalse()
        {
            var result = _table.IsValidPlace(6, 3);

            Assert.False(result);
        }

        [Fact]
        public void IsValidPlace_WhenYIsInValidPlace_ReturnFalse()
        {
            var result = _table.IsValidPlace(3, 6);

            Assert.False(result);
        }

        [Fact]
        public void IsValidPlace_WhenBothAreInValidPlaces_ReturnFalse()
        {
            var result = _table.IsValidPlace(6, 6);

            Assert.False(result);
        }

        [Fact]
        public void IsValidPlace_WhenValuesAreLessThanZero_ReturnFalse()
        {
            var result = _table.IsValidPlace(-1, -6);

            Assert.False(result);
        }

        [Fact]
        public void IsValidPlace_WhenValuesAreZero_ReturnTrue()
        {
            var result = _table.IsValidPlace(0, 0);

            Assert.True(result);
        }
    }
}
