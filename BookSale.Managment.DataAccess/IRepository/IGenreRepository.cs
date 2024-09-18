using BookSale.Managment.Domain.Entities;

namespace BookSale.Managment.DataAccess.IRepository
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllGenres();
    }
}