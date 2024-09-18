using BookSale.Managment.Application.DTOs;
using BookSale.Managment.Application.IService;
using BookSale.Managment.DataAccess.IRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Managment.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GenreDTO>> GetGenreList()
        {
            IGenreRepository genreRepository = _unitOfWork.genreRepository;
            return (await genreRepository.GetAllGenres()).Select(x => new GenreDTO
            {
                Id = x.Id,
                Name = x.Name,
            });
        }
    }
}
