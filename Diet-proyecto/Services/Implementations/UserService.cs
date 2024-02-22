using AutoMapper;
using Diet_proyecto.Data;
using Diet_proyecto.Services.Interfaces;
using Diet_proyecto.Models;
using Diet_proyecto.Mappers;
using Diet_proyecto.Entities;


namespace Diet_proyecto.Services.Implementations
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

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        
        public UserDto GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            return _mapper.Map<UserDto>(user);
        }

        public UserDto CreateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var createdUser = _userRepository.CreateUser(user); // ??
            return _mapper.Map<UserDto>(createdUser);
        }

        public UserDto UpdateUser(int id, UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var updatedUser = _userRepository.UpdateUser(id, user); //??
            return _mapper.Map<UserDto>(updatedUser);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }
        //public ICollection<ProductDto> GetProductByUser(int userId)
        //{
        //    var product = _userRepository.GetUserProduct(userId);

        //    return _mapper.Map<ICollection<ProductDto>>(product);
        //}




    }
}