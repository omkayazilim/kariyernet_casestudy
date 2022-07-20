using Advert.Domain.Interfaces;
using App.Applications.Helpers;

using Microsoft.AspNetCore.Mvc;


namespace Advert.View.Models
{
    public class ControllerBase<T> : Controller
    {
        public readonly IAppBussiness bussiness;  
       
        public ControllerBase( IAppBussiness _bussiness)
        {
            bussiness = _bussiness;
         

        }




    }
}
