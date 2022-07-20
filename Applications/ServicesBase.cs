using Advert.Infrastructer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Applications
{
    public class ServicesBase
    {

     
        protected readonly IAppDbContext _context;
        public ServicesBase(IAppDbContext context, IHttpContextAccessor? httpContextAccessor = null)
        {
            _context = context;
        }
    }

}

