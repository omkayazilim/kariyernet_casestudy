using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Domain.Dtos
{
    public class AdvertListDto
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string PositionTitle { get; set; }
        public string PositionDesc { get; set; }
        public string? Benefits { get; set; }
        public string? JobType { get; set; }
        public string? Wage { get; set; }
        public bool? IsOnline { get; set; }
        public string? IsOnlineText { get; set; }
        public int? Rate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
