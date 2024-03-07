using Diet_proyecto.Entities;
using Diet_proyecto.Models;

namespace Diet_proyecto.Mappers
{
    
      public class UserMapper
      {
            public static List<UserDto> Map(IEnumerable<User> users)
            {
                return users
                    .Select(u => Map(u))
                    .ToList();
            }

            public static UserDto Map(User user)
            {
                return new UserDto
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    UserType = user.UserType,
                    UserName = user.UserName,
                };
            }

            public static User Map(UserDto userDto)
            {
                return new User
                {
                    Name = userDto.Name,
                    LastName = userDto.LastName,
                    Email = userDto.Email,
                    PhoneNumber = userDto.PhoneNumber,
                    UserType = userDto.UserType,
                    UserName= userDto.UserName,
                };
            }

            public static User Map1(CreateUpdateUserDto createUpdateUserDto)
            {
                return new User
                {
                    Name = createUpdateUserDto.Name,
                    LastName = createUpdateUserDto.LastName,
                    Email = createUpdateUserDto.Email,
                    Address = createUpdateUserDto.Address,
                    PhoneNumber = createUpdateUserDto.PhoneNumber,
                    DNI = createUpdateUserDto.DNI,
                    UserName = createUpdateUserDto.UserName,
                    UserType = createUpdateUserDto.UserType,
                    Password = createUpdateUserDto.Password,

                };
            }

            public static CreateUpdateUserDto Map1(User user)
            {
                return new CreateUpdateUserDto
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Address = user.Address,
                    PhoneNumber = user.PhoneNumber,
                    DNI = user.DNI,
                    UserName = user.UserName,
                    UserType = user.UserType,
                    Password = user.Password,
                };
            }

      }

    
}
