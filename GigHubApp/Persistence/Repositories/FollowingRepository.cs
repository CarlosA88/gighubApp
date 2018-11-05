using GigHubApp.Core.Models;
using GigHubApp.Core.Persistence;
using GigHubApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHubApp.Persistence.Repositories
{
    public class FollowingRepository: IFollowingRepository
    {
        private ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Following GetFollowings(string FollowerId, string followeeId)
        {
            return _context.Followings
                    .SingleOrDefault(f => f.FolloweeId == followeeId && f.FollowerId == FollowerId);
        }


    }
}