using System.Globalization;
using System;
using RugbyUnion.API.Persistence.Contexts;

namespace RugbyUnion.API.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
