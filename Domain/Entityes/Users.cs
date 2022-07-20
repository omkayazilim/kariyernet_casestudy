
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Domain.Entityes
{
    [Table("T_Users")]
    public class Users: EntityBase
    {

        [Key]
        public long  Id { get; set; } 
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }
        [StringLength(50)]
        public string Role { get; set; }
    }
}
