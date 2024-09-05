using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Managment.Domain.Entities
{
    public class Genre : BaseEntity
    {
        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(1500)]
        public string? Description { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
