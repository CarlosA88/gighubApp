using GigHubApp.Core.Models;
using System.Collections;
using System.Collections.Generic;

namespace GigHubApp.Core.Persistence
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
    }
}