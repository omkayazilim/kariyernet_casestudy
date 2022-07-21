using Advert.Domain.Dtos;
using Advert.Domain.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Domain.ViewModels
{
    public class AdvertViewModel
    {
        public Companys CompanyInfo { get; set; }
        public List<AdvertListDto> AdvertList { get; set; }
    }
}
