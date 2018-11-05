using GigHubApp.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigHubApp.Core
{
    public interface IUnitOfWork
    {
        IGigRepository Gigs { get; }
        IFollowingRepository Followings { get; }
        IGenreRepository Genres { get; }
        IAttendanceRepository Attendances { get; }


        void Complete();

    }
}
