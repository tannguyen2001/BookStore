using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Managment.Domain.Entities
{
    public class Cart : BaseEntity
    {
        [StringLength(1000)]
        public string Note { get; set; }

        [StringLength(250)]
        public string Code { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
    }
}
