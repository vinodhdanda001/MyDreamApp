using TrackMyKid.Common.Models;

namespace TrackMyKid.DataLayer.Interfaces
{
    public interface IMemberService
    {
        Member GetMemberDetails(int orgId, string memberId);

        bool IsMemberExists(int orgId, int mobileNum);
    }
}
