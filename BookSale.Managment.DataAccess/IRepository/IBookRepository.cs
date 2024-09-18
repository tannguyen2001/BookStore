using BookSale.Managment.Domain.Entities;

namespace BookSale.Managment.DataAccess.IRepository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBook();
    }
}