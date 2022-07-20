using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Domain.Interfaces
{
    public interface IEntitiesBase
    {

        long Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
        string CreatedUser { get; set; }
        string UpdatedUser { get; set; }
        bool IsActive { get; set; }
    }


 
  
}
