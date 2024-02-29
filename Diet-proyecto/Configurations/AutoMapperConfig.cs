using AutoMapper;
using Diet_proyecto.Entities;
using Diet_proyecto.Models;

namespace Diet_proyecto.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<User, CreateUpdateUserDto>();
            CreateMap<CreateUpdateUserDto, User>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }

    }
}
