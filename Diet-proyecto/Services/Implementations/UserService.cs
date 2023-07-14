using AutoMapper;
using Diet_proyecto.Data;
using Diet_proyecto.API.Services.Interfaces;
using Diet_proyecto.Models;


namespace Diet_proyecto.API.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public ICollection<ProductDto> GetProductByUser(int userId)
        {
            var product = _userRepository.GetUserProduct(userId);

            return _mapper.Map<ICollection<ProductDto>>(product);
        }
    }
}