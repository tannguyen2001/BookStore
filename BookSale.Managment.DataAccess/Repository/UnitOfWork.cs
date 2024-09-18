using BookSale.Managment.DataAccess.DataAccess;
using BookSale.Managment.DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Managment.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly BookStoreDbContext _bookStoreDbContext;

        private IGenreRepository? _genreRepository;
        private IBookRepository? _bookRepository;

        public UnitOfWork(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;

        }

        public IGenreRepository genreRepository
        {
            get 
            {
                    return _genreRepository == null ? new GenreRepository(_bookStoreDbContext) : _genreRepository;    
            }
        }

        public IBookRepository bookRepository
        {
            get
            {
                return _bookRepository == null ? new BookRepository(_bookStoreDbContext) : _bookRepository;
            }
        }


        public async Task SaveChange()
        {
            await _bookStoreDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_bookStoreDbContext != null)
            {
                _bookStoreDbContext.Dispose();
            }
        }
    }
}
