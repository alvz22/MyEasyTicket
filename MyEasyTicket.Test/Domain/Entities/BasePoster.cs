using MyEasyTicket.Domain.Entities;
using Xunit;

namespace MyEasyTicket.Test.Domain.Entities
{
    public class BasePoster
    {
        public Poster PosterTest;

        public BasePoster()
        {
            this.PosterTest = new Poster("PosterImg.jpg", "descrever as informações neste campo");
        }
    }

    [Collection("Valid State Test #1")]
    public class PosterTest1 : BasePoster
    {

        [Fact]
        [Trait("Create Poster", "Valid State")]
        public void CreatePoster_WithValidParameters_ResultValidoState()
        {
            Assert.True(this.PosterTest.Valid);
        }

        [Theory]
        [Trait("Update Poster", "Valid State")]
        [InlineData("ImgTest.pge", "informações sobre o filme em cartaz")]
        public void UpdatePoster_WithValidParameters_ResultValidState(string img, string description)
        {
            this.PosterTest.UpdatePoster(img, description);

            Assert.True(this.PosterTest.Valid);
        }
    }

    [Collection("Invalid State Test #2")]
    public class PosterTest2 : BasePoster
    {

        [Theory]
        [Trait("Create Poster", "Invalid State")]
        [InlineData("", "informações sobre o filme em cartaz")]
        [InlineData("ImgTest.pge", "")]
        public void CreatePoster_WithEmptyParameters_ResultInvalidState(string img, string description)
        {
            this.PosterTest = new Poster(img, description);

            Assert.True(this.PosterTest.Invalid);
        }

        [Theory]
        [Trait("Update Poster", "Invalid State")]
        [InlineData("", "informações sobre o filme em cartaz")]
        [InlineData("ImgTest.pge", "")]
        public void UpdatePoster_WithEmptyParameters_ResultInvalidState(string img, string description)
        {
            this.PosterTest.UpdatePoster(img, description);

            Assert.True(this.PosterTest.Invalid);
        }

        [Theory]
        [Trait("Create Poster", "Invalid State")]
        [InlineData("av", "informações sobre o filme em cartaz")]
        [InlineData("Im", "informações sobre o filme em cartaz")]
        public void CreatePoster_WithLengthInvalid_ResultInvalidState(string img, string description)
        {
            this.PosterTest = new Poster(img, description);

            Assert.True(this.PosterTest.Invalid);
        }

        [Theory]
        [Trait("Update Poster", "Invalid State")]
        [InlineData("av", "informações sobre o filme em cartaz")]
        [InlineData("Im", "informações sobre o filme em cartaz")]
        public void UpdatePoster_WithLengthInvalid_ResultInvalidState(string img, string description)
        {
            this.PosterTest = new Poster(img, description);

            Assert.True(this.PosterTest.Invalid);
        }

    }
}
