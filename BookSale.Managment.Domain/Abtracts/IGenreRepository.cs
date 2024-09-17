using BookSale.Managment.Domain.Entities;

namespace BookSale.Managment.Domain.Abtracts
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetAllGenres();
    }
}