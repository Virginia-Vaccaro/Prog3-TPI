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

        
        public UserDto GetUserById(int? id)
        {
            var user = _userRepository.GetUserById(id);
            return _mapper.Map<UserDto>(user);
        }

        public User CreateUser(CreateUpdateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
             _userRepository.CreateUser(user); 
            return user;
        }

        public CreateUpdateUserDto UpdateUser(int id, CreateUpdateUserDto createUpdateUserDto)
        {
            var user = _mapper.Map<User>(createUpdateUserDto);
            var updatedUser = _userRepository.UpdateUser(id, user);
            return _mapper.Map<CreateUpdateUserDto>(updatedUser);
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }




    }
}