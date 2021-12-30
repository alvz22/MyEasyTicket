using MyEasyTicket.Domain.ValueObject;
using Xunit;

namespace MyEasyTicket.Test.Domain.ValueObjects
{
    public class BaseAddress
    {

        public Address AddressTest;

        public BaseAddress()
        {
            this.AddressTest = new Address("Rua dos Testes, Centro correto", "1010", "São Paulo", "SP");
        }
    }

    [Collection("Valid State Test #1")]
    public class AddressTest1 : BaseAddress
    {

        [Fact]
        [Trait("Create Address", "Valid State")]
        public void CreateAddress_WithValidParameters_ResultValidState()
        {
            Assert.True(this.AddressTest.Valid);
        }

        [Theory]
        [Trait("Update Address", "Valid State")]
        [InlineData("Av. São José, Zona norte", "7777", "São Paulo", "São Paulo")]
        public void UpdateAddress_WithValidParameters_ResultValidState(string address, string number, string city, string state)
        {
            this.AddressTest.UpdateAddress(address, number, city, state);

            Assert.True(this.AddressTest.Valid);
        }
    }

    [Collection("Invalid State Test #2")]
    public class AddressTest2 : BaseAddress
    {

        [Theory]
        [Trait("Create Address", "Invalid State")]
        [InlineData("", "7777", "São Paulo", "São Paulo")]
        [InlineData("Av. São José, Zona norte", "", "São Paulo", "São Paulo")]
        [InlineData("Av. São José, Zona norte", "7777", "", "São Paulo")]
        [InlineData("Av. São José, Zona norte", "7777", "São Paulo", "")]
        public void CreateAddress_WithEmptyParameters_ResultInvalidState(string address, string number, string city, string state)
        {
            var createAddress = new Address(address, number, city, state);

            Assert.True(createAddress.Invalid);
        }

        [Theory]
        [Trait("Update Address", "Invalid State")]
        [InlineData("", "7777", "São Paulo", "São Paulo")]
        [InlineData("Av. São José, Zona norte", "", "São Paulo", "São Paulo")]
        [InlineData("Av. São José, Zona norte", "7777", "", "São Paulo")]
        [InlineData("Av. São José, Zona norte", "7777", "São Paulo", "")]
        public void UpdateAddress_WithEmptyParameters_ResultInvalidState(string address, string number, string city, string state)
        {
            this.AddressTest.UpdateAddress(address, number, city, state);

            Assert.True(this.AddressTest.Invalid);
        }

    }

    [Collection("Invalid State Test #3")]
    public class AddressTest3 : BaseAddress
    {
        [Theory]
        [Trait("Create Address", "Invalid State")]
        [InlineData("av", "7777", "São Paulo", "São Paulo")]
        [InlineData("Av. São José, Zona norte", "7777", "Sp", "São Paulo")]
        [InlineData("Av. São José, Zona norte", "7777", "São Paulo", "S")]
        public void CreateAddress_WithLengthInvalid_ResultInvalidState(string address, string number, string city, string state)
        {
            var createAddress = new Address(address, number, city, state);

            Assert.True(createAddress.Invalid);
        }

        [Theory]
        [Trait("Create Address", "Invalid State")]
        [InlineData("av", "7777", "São Paulo", "São Paulo")]
        [InlineData("Av. São José, Zona norte", "7777", "Sp", "São Paulo")]
        [InlineData("Av. São José, Zona norte", "7777", "São Paulo", "S")]
        public void UpdateAddress_WithLengthInvalid_ResultInvalidState(string address, string number, string city, string state)
        {
            this.AddressTest.UpdateAddress(address, number, city, state);

            Assert.True(this.AddressTest.Invalid);
        }
    }
}
