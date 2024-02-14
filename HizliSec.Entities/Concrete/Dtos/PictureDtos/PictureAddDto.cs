

using HizliSec.Core.Entities;

namespace HizliSec.Entities.Concrete.Dtos.PictureDtos
{
    public class PictureAddDto : IDto
    {
        public int ProductId { get; set; }
        public int SellerId { get; set; }
        public string Image { get; set; }
    }
}
