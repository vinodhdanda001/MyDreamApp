using TrackMyKid.Common.Models;

namespace TrackMyKid.DataLayer.Interfaces
{
    public interface ILoginDataService
    {
        UserProfile Login(LoginModel loginModel);
    }
}
