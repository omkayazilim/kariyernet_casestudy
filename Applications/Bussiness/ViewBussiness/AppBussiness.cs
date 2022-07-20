

using Advert.Applications;
using Advert.Domain.Interfaces;
using Advert.Infrastructer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace advert.Applications.Bussiness
{
    public class AppBussiness : ServicesBase, IAppBussiness
    {
        public AppBussiness(IAppDbContext context, IHttpContextAccessor httpContextAccessor):base(context,httpContextAccessor)
        { }
    }
}
