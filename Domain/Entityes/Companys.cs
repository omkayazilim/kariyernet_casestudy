using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Domain.Entityes
{
    [Table("T_Companys")]
    public class Companys:EntityBase
    {
        [StringLength(160)]
        public string CompanyName { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(500)]
        public string Adress { get; set; }

        [StringLength(20)]
        public string Password { get; set; }
        public int AdvertsLimit { get; set; }
        public ICollection<Adverts> Adverts { get; set; }   
    }
}
