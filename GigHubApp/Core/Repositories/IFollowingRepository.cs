using GigHubApp.Core.Models;

namespace GigHubApp.Core.Persistence
{
    public interface IFollowingRepository
    {

       Following GetFollowings(string FollowerId, string followeeId);

    }
}