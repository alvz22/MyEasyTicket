using MyEasyTicket.Domain.Entities;
using Xunit;

namespace MyEasyTicket.Test.Domain.Entities
{


    public class BaseFilm 
    {
        public Film FilmTest;

        public BaseFilm()
        {
            this.FilmTest = new Film("Jummanji", "Ação e comédia", "2:45Hs", 33.55m);
        }
    }

    [Collection("Valid State Test #1")]
    public class FilmTest1 : BaseFilm
    {
        [Fact]
        [Trait("Create Film", "Valid State")]
        public void CreateFilm_WithValidParameters_ResultValidState()
        {
            Assert.True(this.FilmTest.Valid);
        }

        [Theory]
        [Trait("Update Film", "Valid State")]
        [InlineData("Avengers", "Ação e aventura", "3:50Hs", 40.90)]
        [InlineData("Avengers", "Ação e aventura", "3:50Hs", 0.01)]
        public void UpdateFilm_WithValidParameters_ResultValidState(string name, string description, string duration, decimal value)
        {
            this.FilmTest.UpdateFilm(name, description, duration, value);

            Assert.True(this.FilmTest.Valid);
        }
    }

    [Collection("Invalid State Test #2")]
    public class FilmTest2 : BaseFilm
    {

        [Theory]
        [Trait("Create Film", "Invalid State")]
        [InlineData("", "Ação e comédia", "2:45Hs", 33.55)]
        [InlineData("Jummanji", "", "2:45Hs", 33.55)]
        [InlineData("Jummanji", "Ação e comédia", "", 33.55)]
        [InlineData("Avengers", "Ação e aventura", "3:50Hs", 0.00)]
        public void CreateFilm_WithEmptyParameters_ResultInvalidState(string name, string description, string duration, decimal value)
        {
            var createFilme = new Film(name, description, duration, value);

            Assert.True(createFilme.Invalid);
        }

        [Theory]
        [Trait("Create Film", "Invalid State")]
        [InlineData("Jummanji", "Ação e comédia", "2:45Hs", -33.55)]
        public void CreateFilm_WithNegativeDecimalValue_ResultInvalidState(string name, string description, string duration, decimal value)
        {
            var createFilme = new Film(name, description, duration, value);

            Assert.True(createFilme.Invalid);
        }

        [Theory]
        [Trait("Update Film", "Invalid State")]
        [InlineData("", "Ação e aventura", "3:50", 40.55)]
        [InlineData("Avengers", "", "3:50", 40.55)]
        [InlineData("Avegers", "Ação e aventura", "", 40.55)]
        [InlineData("Avengers", "Ação e aventura", "3:50Hs", 0.00)]
        public void UpdateFilm_WithEmptyParameters_ResultInvalidState(string name, string description, string duration, decimal value)
        {
            this.FilmTest.UpdateFilm(name, description, duration, value);

            Assert.True(this.FilmTest.Invalid);
        }

        [Theory]
        [Trait("Update Film", "Invalid State")]
        [InlineData("Avegers", "Ação e aventura", "3:50", -40.55)]
        [InlineData("Avegers", "Ação e aventura", "3:50", -00.55)]
        public void UpdateFilm_WithNegativeDecimalValue_RsultInvalidState(string name, string description, string duration, decimal value)
        {
            this.FilmTest.UpdateFilm(name, description, duration, value);

            Assert.True(this.FilmTest.Invalid);
        }
    }

    [Collection("Invalid State Test #3")]
    public class FilmTest3 : BaseFilm
    {
        [Theory]
        [Trait("Create Film", "Invalid State")]
        [InlineData("Ab", "Ação e aventura", "3:50", 40.55)]
        [InlineData("Avegers", "Aç", "3:50", 40.55)]
        [InlineData("Avegers", "Ação e aventura", "3:", 40.55)]
        public void CreateFilm_WithLengthInvalid_ResultInvalidState(string name, string description, string duration, decimal value)
        {
            var createFilme = new Film(name, description, duration, value);

            Assert.True(createFilme.Invalid);
        }

        [Theory]
        [Trait("Update Film", "Invalid State")]
        [InlineData("Ab", "Ação e aventura", "3:50", 40.55)]
        [InlineData("Avegers", "Aç", "3:50", 40.55)]
        [InlineData("Avegers", "Ação e aventura", "3:", 40.55)]
        public void UpdateFilm_WithLengthInvalid_ResultInvalidState(string name, string description, string duration, decimal value)
        {
            this.FilmTest.UpdateFilm(name, description, duration, value);

            Assert.True(this.FilmTest.Invalid);
        }
    }
}
