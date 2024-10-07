namespace apief
{
    public interface IAuthService
    {
        Task CheckUserExistsAsync(userForRegistration userForRegistration);
        Task CheckEmailAsync(userForRegistration userForLogin);
        Task<string> GenerateTokenAsync(userForRegistration userForRegistration);
        Task CheckPasswordAsync(userForRegistration userForLogin);
        Task ValidateRegistrationDataAsync(userForRegistration userForRegistration);
        public string GenerateTokenForLogin(userForRegistration userAuthDto);
    }
}