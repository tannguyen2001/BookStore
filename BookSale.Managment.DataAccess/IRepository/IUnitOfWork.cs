using BookSale.Managment.DataAccess.Repository;

namespace BookSale.Managment.DataAccess.IRepository
{
    public interface IUnitOfWork
    {
        IBookRepository bookRepository { get; }
        IGenreRepository genreRepository { get; }

        Task SaveChange();
    }
}