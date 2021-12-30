using MyEasyTicket.Domain.Entities;
using System.Linq;
using Xunit;

namespace MyEasyTicket.Test.Domain.Entities
{
    public class BaseHall 
    {

        public Hall HallTest;

        public BaseHall()
        {
            this.HallTest = new Hall("1 - A", 55);
        }
    }

    [Collection("Valid State Test #1")]
    public class HallTest1 : BaseHall
    {
        [Fact]
        [Trait("Create Hall", "Valid State")]
        public void CreateHall_WithValidParameters_ResultValidState()
        {
            Assert.True(this.HallTest.Valid);
        }
        
        [Theory]
        [Trait("Update Hall", "Valid State")]
        [InlineData("2 - B", 70)]
        public void UpdateHall_WithValidParemeters_ResultValidState(string identification, int seatsNumber)
        {
            this.HallTest.UpdateHall(identification, seatsNumber);

            Assert.True(this.HallTest.Valid);
        }


        [Theory]
        [Trait("Create Dictionary<string, Seat>", "Valid State")]
        [InlineData(70)]
        public void SetSeatsNumber_WithValidParameters_ResulEqualsParameterNumber(int numbers)
        {
            this.HallTest = new Hall("1A", numbers);
            Assert.True(HallTest.Seats.Count() == numbers);
        }

        [Theory]
        [Trait("Create Dictionary<string, Seat>", "Valid State")]
        [InlineData(70)]
        public void SetSeatsNumber_WithValidParameters_ResulContainsKeys(int numbers)
        {
            this.HallTest = new Hall("1A", numbers);
            Assert.True(this.HallTest.Seats.ContainsKey("Seat 1") && this.HallTest.Seats.ContainsKey("Seat 70"));
        }

        [Theory]
        [Trait("Create Dictionary<string, Seat>", "Valid State")]
        [InlineData(70)]
        public void SetSeatsNumber_WithValidParameters_ResulContainsValues(int numbers)
        {
            this.HallTest = new Hall("1A", numbers);

            Assert.True(this.HallTest.Seats.Values.Where(x => x.Number == 1).Any() &&
                this.HallTest.Seats.Values.Where(x => x.Number == 70).Any());
        }

    }

    [Collection("Invalid State Test #2")]
    public class HallTest2 : BaseHall
    {
        [Theory]
        [Trait("Create Hall", "Invalid State")]
        [InlineData("", 70)]
        [InlineData("2 - B", 0)]
        public void CreateHall_WithEmptyParameters_ResultInvalidState(string identification, int seatsNumber)
        {
            var createHall = new Hall(identification, seatsNumber);

            Assert.True(createHall.Invalid);
        }

        [Theory]
        [Trait("Update Hall", "Invalid State")]
        [InlineData("", 70)]
        [InlineData("2 - B", 0)]
        public void UpdateHall_WithEmptyParameters_ResultInvalidState(string identification, int seatsNumber)
        {
            this.HallTest.UpdateHall(identification, seatsNumber);

            Assert.True(this.HallTest.Invalid);
        }

        [Fact]
        [Trait("Update Hall", "Invalid State")]
        public void CreateHall_WithNegativeIntValue_ResultInvalidState()
        {
            var createHall = new Hall("11 - C", -2);

            Assert.True(createHall.Invalid);
        }

        [Theory]
        [Trait("Update Hall", "Invalid State")]
        [InlineData("3 - C", -1)]
        public void UpdateHall_WithNegativeIntValue_ResultInvalidState(string identification, int seatsNumber)
        {
            this.HallTest.UpdateHall(identification, seatsNumber);

            Assert.True(this.HallTest.Invalid);
        }
    }
}
