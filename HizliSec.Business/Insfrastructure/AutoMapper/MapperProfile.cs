using HizliSec.Entities.Concrete.Dtos.CategoryDtos;
using HizliSec.Entities.Concrete.Dtos.MessageDtos;
using HizliSec.Entities.Concrete.Dtos.UserDtos;
using HizliSec.Entities.Concrete;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;

namespace HizliSec.Business.Insfrastructure.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryAddDto>().ReverseMap();
            CreateMap<AppUser, SellerRegisterDto>().ReverseMap();
            CreateMap<AppUser, CustomerRegisterDto>().ReverseMap();
            CreateMap<Seller, SellerRegisterDto>().ReverseMap();
            CreateMap<Seller, SellerDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerRegisterDto>().ReverseMap();
            CreateMap<AppUser, Customer>().ReverseMap();
            CreateMap<AppUser, Seller>().ReverseMap();
            CreateMap<Message, MessageAddDto>().ReverseMap();


        }
    }
}
