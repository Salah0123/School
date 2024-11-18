namespace School.Api.Contracts.Authentication
{
    public class AuthResponse
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Token { get; set; }
        public string? Role { get; set; }
        public int ExpirsIn { get; set; }
    }
}