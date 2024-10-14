using System.Security.Claims;

namespace apief
{
    public interface IPassService
    {
        Task<List<PasswordResponsDto>> GetAllPasswordsForUserAsync(Guid userId);
        Task<PasswordDto> CreateAsync(PasswordDto passwordDto, Guid userId);
        Task<User> GetUserByTokenAsync(ClaimsPrincipal userClaims);
        Task<PasswordDto> UpdatePassword(Guid id, Guid passwordId, PasswordDto userInput);
        Task DeletePasswordAsync(Guid passwordId, Guid userId);
    }
}