using GigHubApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigHubApp.Core.Persistence
{
    public interface IGigRepository
    {
        Gig GetGigsDetails(int gigId);
        IEnumerable<Gig> GetUpcomingGigsByArtist(string artistId);
        Gig GetGigWithAttendees(int gigId);
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        IEnumerable<Gig> GetUpcomingGigs(string searchTerm = null);
        void Add(Gig gig);

    }
}
