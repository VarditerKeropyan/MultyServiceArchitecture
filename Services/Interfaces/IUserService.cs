using Common.Models;

namespace Services.Interfaces;

public interface IUserService
{
    Task<UserDto> CreateAsync(string firstNamae, string lastName);

    Task DeleteAsync(int userId);

    Task<IEnumerable<UserEntityDto>> GetAllUsersAsync();
}
