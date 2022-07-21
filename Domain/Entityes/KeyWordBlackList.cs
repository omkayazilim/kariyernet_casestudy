using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Domain.Entityes
{
    [Table("T_KeyWordBlackList")]
    public class KeyWordBlackList:EntityBase
    {
        public string KeyWord { get; set; } 
    }
}
