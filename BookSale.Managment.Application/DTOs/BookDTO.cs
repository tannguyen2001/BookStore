using BookSale.Managment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Managment.Application.DTOs
{
    public class BookDTO
    { 
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }

        public int Available { get; set; }
        public double Price { get; set; }
        public DateTime CreateOn { get; set; }
        public bool IsActive { get; set; }
        public int GenreId { get; set; }
        public GenreDTO Genre { get; set; }
    }
}
