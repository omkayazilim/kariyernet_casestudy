using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Domain
{
   
    public class InputType : Attribute
    {
      

    
    }

    public class Trans : Attribute
    {
         private string DefText = "";
        public Trans(string? _defText=null)
        {
            this.DefText = _defText??"";    
        }

        public string GetDefText() { return DefText; }
    }


}
