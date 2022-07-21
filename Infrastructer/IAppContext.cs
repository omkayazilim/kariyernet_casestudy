
using Advert.Domain.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Advert.Infrastructer
{
    public interface IAppDbContext
    {
        DbSet<Companys> Companys { get; set; }
        DbSet<Adverts> Adverts { get; set; }
        DbSet<KeyWordBlackList> KeyWordBlackList { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
