namespace TrackMyKid.Common.Models
{
    public class RegisterModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int OrganizationId { get; set; }
        public int PrimaryContactNum { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int Otp { get; set; }
    }
}
