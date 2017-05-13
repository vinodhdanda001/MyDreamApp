using TrackMyKid.Common.Models;
namespace TrackMyKid.DataLayer.Interfaces
{
    public interface IRegisterDataService
    {
        void Register(RegisterModel registerModel);

        bool IsRegistered(RegisterModel registerModel);
    }
}
