using BookSale.Managment.Application.DTOs;

namespace BookSale.Managment.Application.IService
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDTO>> GetGenreList();
    }
}