using Advert.Domain.Dtos;
using Advert.Infrastructer;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Applications
{
    public class ServicesBase
    {
        
        protected readonly IAppDbContext _context;
        public UserClaimDto User;
        public ServicesBase(IAppDbContext context, IHttpContextAccessor? httpContextAccessor = null)
        {
            _context = context;
            var claims = httpContextAccessor?.HttpContext?.User?.Claims?.ToList() ;
            var phone = claims?.Single(x => x.Type.Equals(ClaimTypes.Email))?.Value;
            var name = claims?.Single(x => x.Type.Equals(ClaimTypes.Name))?.Value;
            User = new UserClaimDto { Name=name, Phone=phone };

        }
    }

}

