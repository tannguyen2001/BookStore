using BookSale.Managment.DataAccess.DataAccess;
using BookSale.Managment.DataAccess.IRepository;
using BookSale.Managment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Managment.DataAccess.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(BookStoreDbContext bookStoreDbContext) : base(bookStoreDbContext)
        {

        }

        public async Task<IEnumerable<Book>> GetAllBook()
        {
            return await base.GetAllAsync();
        }
    }
}
