using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Managment.Domain.Entities
{
    public class UserAdress : BaseEntity
    {
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        [Required]
        [StringLength(250)]
        public string Fullname { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
    }
}
