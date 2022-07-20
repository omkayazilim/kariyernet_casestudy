using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Domain.Entityes
{
    [Table("T_Adverts")]
    public class Adverts:EntityBase
    {
        public string PositionTitle { get; set; }
        public string PositionDesc { get; set; }
        public int AdvertDayLimit { get; set; }
        public int AdvertQualityRate { get; set; }
        public string? Benefits { get; set; }
        public string? JobType { get; set; }
        public decimal? Wage { get; set; }
        public long CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Companys Company { get; set; }
    }
}
