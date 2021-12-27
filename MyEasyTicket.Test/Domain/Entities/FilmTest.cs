using MyEasyTicket.Domain.Entities;
using Xunit;

namespace MyEasyTicket.Test.Domain.Entities
{
    public class FilmTest
    {

        [Fact]
        public void CreateFilm_WithValidParameters_ResultValidState()
        {
            var create = new Film("Jummanji", "Ação e comédia", "2:45Hs", 33.55m);

            Assert.True(create.Valid);
        }

        [Theory]
        [InlineData("", "Ação e comédia", "2:45Hs", 33.55)]
        [InlineData("Jummanji", "", "2:45Hs", 33.55)]
        [InlineData("Jummanji", "Ação e comédia", "", 33.55)]
        [InlineData("Jummanji", "Ação e comédia", "2:45Hs", -33.55)]
        public void CreateFilm_WithInvalidParametersNull_ResultInvalidState(string name, string description, string duration, decimal value)
        {
            var create = new Film(name, description, duration, value);

            Assert.True(create.Invalid);
        }

    }
}
