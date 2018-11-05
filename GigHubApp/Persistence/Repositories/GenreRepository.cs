using GigHubApp.Core.Models;
using GigHubApp.Core.Persistence;
using GigHubApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHubApp.Persistence.Repositories
{
    public class GenreRepository: IGenreRepository
    {
        private ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }
    }
}