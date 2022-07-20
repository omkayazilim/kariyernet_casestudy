using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Domain.ViewModels
{
    public class RegisterDto
    {
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public string Password { get; set; }
      
    }
}
