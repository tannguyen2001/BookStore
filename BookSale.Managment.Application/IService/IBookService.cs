using BookSale.Managment.Application.DTOs;

namespace BookSale.Managment.Application.IService
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetGenreList();
    }
}