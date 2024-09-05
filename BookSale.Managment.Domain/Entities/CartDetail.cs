using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Managment.Domain.Entities
{
    public class CartDetail : BaseEntity
    {
        [Required]
        public int CardId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [StringLength(500)]
        public string Note { get; set; }

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; }

        [ForeignKey(nameof(CardId))]
        public Cart Cart { get; set; }


    }
}
