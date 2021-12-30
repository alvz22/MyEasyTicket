using MyEasyTicket.Domain.Entities;
using Xunit;

namespace MyEasyTicket.Test.Domain.Entities
{
    public class BaseTicket
    {
        public Ticket TicketTest;

        public BaseTicket()
        {
            this.TicketTest = new Ticket("Avengers", "sala 1 A", 60.33m);
        }
    }

    [Collection("Valid State Test #1")]
    public class TicketTest1 : BaseTicket
    {

        [Fact]
        [Trait("Create Ticket", "Valid State")]
        public void CreateTicket_WithValidParameters_ResultValidState()
        {
            Assert.True(this.TicketTest.Valid);
        }

        [Theory]
        [Trait("Update Ticket", "Valid State")]
        [InlineData("Transformers III", "sala 8 C", 55.80)]
        public void UpdateTicket_WithValidParameters_ResultValidState(string name, string information, decimal price)
        {
            this.TicketTest.UpdateTicket(name, information, price);

            Assert.True(this.TicketTest.Valid);
        }
    }

    [Collection("Invalid State Test #2")]
    public class TicketTest2 : BaseTicket
    {

        [Theory]
        [Trait("Create Ticket", "Invalid State")]
        [InlineData("", "sala 8 C", 55.80)]
        [InlineData("Transformers III", "", 55.80)]
        [InlineData("Transformers III", "sala 8 C", 0.0)]
        public void CreateTicket_WithEmptyParameters_ResultInvalidState(string name, string information, decimal price)
        {
            this.TicketTest = new Ticket(name, information, price);

            Assert.True(this.TicketTest.Invalid);
        }

        [Theory]
        [Trait("Update Ticket", "Invalid State")]
        [InlineData("", "sala 8 C", 55.80)]
        [InlineData("Transformers III", "", 55.80)]
        [InlineData("Transformers III", "sala 8 C", 0.0)]
        public void updateTicket_WithEmptyParameters_ResultInvalidState(string name, string information, decimal price)
        {
            this.TicketTest = new Ticket(name, information, price);

            Assert.True(this.TicketTest.Invalid);
        }

        [Theory]
        [Trait("Create Ticket", "Invalid State")]
        [InlineData("V", "sala 8 C", 55.80)]
        [InlineData("Transformers III", "1A", 55.80)]
        public void CreateTicket_WithLengthInvalid_ResultInvalidState(string name, string information, decimal price)
        {
            this.TicketTest = new Ticket(name, information, price);

            Assert.True(this.TicketTest.Invalid);
        }

        [Theory]
        [Trait("Update Ticket", "Invalid State")]
        [InlineData("V", "sala 8 C", 55.80)]
        [InlineData("Transformers III", "1A", 55.80)]
        public void UpdateTicket_WithLengthInvalid_ResultInvalidState(string name, string information, decimal price)
        {
            this.TicketTest.UpdateTicket(name, information, price);

            Assert.True(this.TicketTest.Invalid);
        }

        [Theory]
        [Trait("Create Ticket", "Invalid State")]
        [InlineData("Super Heros", "sala 8 C", -30.50)]
        [InlineData("Transformers III", "sala 1 A", -0.10)]
        [InlineData("Transformers III", "sala 1 A", 0.0)]
        public void CreateTicket_WithZeroOrNegativeValue_ResultInvalidState(string name, string information, decimal price)
        {
            this.TicketTest = new Ticket(name, information, price);

            Assert.True(this.TicketTest.Invalid);
        }
    }
}
