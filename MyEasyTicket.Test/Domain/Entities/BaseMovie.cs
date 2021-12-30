using MyEasyTicket.Domain.Entities;
using MyEasyTicket.Domain.ValueObject;
using Xunit;

namespace MyEasyTicket.Test.Domain.Entities
{
    public class BaseMovie
    {
        public Movie MovieTest;
        public Address AddressTest;

        public BaseMovie()
        {
            this.AddressTest = new Address("Av. Paulista, Centro", "1111", "São Paulo", "SP");
            this.MovieTest = new Movie("Cine Seven", AddressTest);
        }
    }

    [Collection("Valid State Test #1")]
    public class MovieTest1 : BaseMovie
    {

        [Fact]
        [Trait("Create Movie", "Valid State")]
        public void CreateMovie_WithValidParameters_ResultValidState()
        {
            Assert.True(this.MovieTest.Valid);
        }


        [Theory]
        [Trait("Update Movie", "Valid State")]
        [InlineData("Cine 777")]
        [InlineData("Max Cine Prime")]
        public void UpdateMovie_WithValidParameters_ResultValidState(string name)
        {
            this.MovieTest.UpdateMovie(name, this.AddressTest);

            Assert.True(this.MovieTest.Valid);
        }
    }

    [Collection("Invalid State Test #2")]
    public class MovieTest2 : BaseMovie
    {

        [Theory]
        [Trait("Create Movie", "Invalid State")]
        [InlineData("")]
        [InlineData("V8")]
        public void CreateMovie_WithLengthParameterInvalidOrEmpty_ResultInvalidState(string name)
        {
            var movie = new Movie(name, this.AddressTest);

            Assert.True(movie.Invalid);
        }


        [Theory]
        [Trait("Update Movie", "Invalid State")]
        [InlineData("")]
        [InlineData("V8")]
        public void UpdateMovie_WithLengthParameterInvalidOrEmpty_ResultInvalidState(string name)
        {
            this.MovieTest.UpdateMovie(name, this.AddressTest);

            Assert.True(this.MovieTest.Invalid);
        }

    }
}
