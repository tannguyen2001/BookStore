using BookSale.Managment.DataAccess.DataAccess;
using BookSale.Managment.Domain.Abtracts;
using BookSale.Managment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Managment.DataAccess.Repository
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(BookStoreDbContext bookStoreDbContext) : base(bookStoreDbContext)
        {

        }

        public async Task<List<Genre>> GetAllGenres()
        {
            return await base.GetAllAsync(x => x.IsActive);
        }
    }
}
