using Advert.Domain;
using Advert.Domain.Entityes;
using Advert.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Advert.Infrastructer
{
    public static class DataSeeding
    {
        public static async Task Seed(IAppDbContext app)
        {
            if (app.KeyWordBlackList.Count() == 0)
            {
                app.KeyWordBlackList.Add(new KeyWordBlackList { KeyWord="Kötü"  });
                app.KeyWordBlackList.Add(new KeyWordBlackList { KeyWord = "Çirkin" });
                app.KeyWordBlackList.Add(new KeyWordBlackList { KeyWord = "yanlış" });
              
                await app.SaveChangesAsync();
            }


        }


       
    }
}
