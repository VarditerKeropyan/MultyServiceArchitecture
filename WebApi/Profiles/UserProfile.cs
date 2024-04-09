using AutoMapper;
using Common.Models;
using Entities;

namespace SoftwareEngineering.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    { 
        CreateMap<User, UserDto>()
            .ConstructUsing(p => new UserDto() { FullName = $"{p.FirstName} {p.LastName}", Balance = p.Balance });

        CreateMap<User, UserEntityDto>();
    }
}
