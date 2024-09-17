using BookSale.Managment.DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Managment.DataAccess.Repository
{
    public class BaseRepository<T> where T : class
    {

        public BookStoreDbContext _bookStoreDbContext { get; set; }

        public BaseRepository(BookStoreDbContext bookStoreDbContext)
        {
            this._bookStoreDbContext = bookStoreDbContext;
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null)
            {
                return await _bookStoreDbContext.Set<T>().ToListAsync();
            }

            return await _bookStoreDbContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> expression = null)
        {
            return await _bookStoreDbContext.Set<T>().SingleOrDefaultAsync(expression);
        }

        public async Task Create(T entity)
        {
            await _bookStoreDbContext.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _bookStoreDbContext.Set<T>().Attach(entity);
            _bookStoreDbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _bookStoreDbContext.Set<T>().Attach(entity);
            _bookStoreDbContext.Entry(entity).State = EntityState.Deleted;
        }

        public async Task SaveChange()
        {
            await _bookStoreDbContext.SaveChangesAsync();
        }


    }
}
