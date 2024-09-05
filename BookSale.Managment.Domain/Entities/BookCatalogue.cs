using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Managment.Domain.Entities
{
    public class BookCatalogue : BaseEntity
    {
        [Required]
        public int BookId { get; set; }

        [Required]
        public int CalalogueId { get; set; }

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }

        [ForeignKey(nameof(CalalogueId))]
        public Catalogue Catalogue { get; set; }
    }
}
