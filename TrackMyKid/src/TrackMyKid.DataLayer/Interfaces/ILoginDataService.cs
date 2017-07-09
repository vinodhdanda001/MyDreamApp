using TrackMyKid.Common.Models;

namespace TrackMyKid.DataLayer.Interfaces
{
    public interface ILoginDataService
    {
        UserProfile Login(LoginModel loginModel);

        bool ValidateLogin(string username, string password);
    }
}
