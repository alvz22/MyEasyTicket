using MyEasyTicket.Domain.Validations.Entities;

namespace MyEasyTicket.Domain.Entities
{
    public class Poster : BaseEntity
    {
        public string ImgUrl { get; private set; }
        public string Description { get; private set; }
                

        public Poster(string imgUrl, string description)
        {
            this.ImgUrl = imgUrl;
            this.Description = description;

            Validate(this, new PosterValidation());
        }
    }
}
