using HizliSec.Core.Entities;
using HizliSec.Entities.Abstract;


namespace HizliSec.Entities.Concrete.Dtos.UserDtos
{
    public class SellerRegisterDto : UserDto, IDto
    {
        public string CompanyName { get; set; }
    }
}
