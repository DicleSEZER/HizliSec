

using HizliSec.Core.Entities;

namespace HizliSec.Entities.Concrete.Dtos.PictureDtos
{
    public class PictureDto:IDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public string Image { get; set; }

    }
}
