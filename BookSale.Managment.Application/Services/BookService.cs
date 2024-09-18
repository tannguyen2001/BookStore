using BookSale.Managment.Application.DTOs;
using BookSale.Managment.Application.IService;
using BookSale.Managment.DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Managment.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BookDTO>> GetGenreList()
        {
            IBookRepository bookRepository = _unitOfWork.bookRepository;
            return (await bookRepository.GetAllBook()).Select(x => new BookDTO
            {
                Title = x.Title,
                Author = x.Author,
                Available = x.Available,
                CreateOn = x.CreateOn,
                Genre = new GenreDTO
                {
                    Id = x.GenreId,
                    Name = x.Genre.Name
                },
                GenreId = x.GenreId,
                IsActive = x.IsActive,
                Price = x.Price,
                Publisher = x.Publisher
            });
        }
    }
}
