using MyEasyTicket.Domain.ValueObject;
using Xunit;

namespace MyEasyTicket.Test.Domain.ValueObjects
{
    public class BaseSeat
    {
        public Seat SeatTest;

        public BaseSeat()
        {
            this.SeatTest = new Seat(1);
        }
    }

    [Collection("Valid State Test #1")]
    public class SeatTest1 : BaseSeat
    {

        [Theory]
        [Trait("Create Seat", "Valid State")]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(100)]
        public void CreateSeat_WithValidParameters_ResultValidState(int number)
        {
            this.SeatTest = new Seat(number);

            Assert.True(this.SeatTest.Valid);
        }
    }

    [Collection("Invalid State Test #2")]
    public class SeatTest2 : BaseSeat
    {

        [Theory]
        [Trait("Create Seat", "Invalid State")]
        [InlineData(0)]
        [InlineData(-1)]
        public void CreateSeat_WithZeroOrNegativeNumber_ResultInvalidState(int number)
        {
            this.SeatTest = new Seat(number);

            Assert.True(this.SeatTest.Invalid);
        }
    }
}
