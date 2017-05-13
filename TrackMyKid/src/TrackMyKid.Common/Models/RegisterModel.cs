namespace TrackMyKid.Common.Models
{
    public class RegisterModel
    {
        public string userName { get; set; }
        public string passWord { get; set; }
        public int organizationId { get; set; }
        public int primaryContactNum { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
