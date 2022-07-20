
using Advert.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Domain.Entityes
{
    public abstract class EntityBase : IEntitiesBase
    {

        [Key]
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        [StringLength(20)]
        public string CreatedUser { get; set; } = "SYS";
        [StringLength(20)]
        public string? UpdatedUser { get; set; }
        public bool IsActive { get; set; } = true;
   

    }

}
