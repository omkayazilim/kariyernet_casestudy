using Advert.Domain.Dtos;
using Advert.Domain.Entityes;
using Advert.Domain.Interfaces;
using Advert.Domain.ViewModels;
using Advert.Infrastructer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Applications
{
    public interface IUserService : IScopedDependency
    {
        Task<OperationResultDto<Companys>> LoginProcess(LoginPostDto user);
        Task<OperationResultDto<string>> RegisterProcess(RegisterDto user);
    }
    public class UserService : ServicesBase, IUserService
    {
        public UserService(IAppDbContext context) : base(context)
        {

        }

        public async Task<OperationResultDto<Companys>> LoginProcess(LoginPostDto user)
        {
            var result = await _context.Companys.Where(x => x.Phone.Equals(user.UserName) && x.Password.Equals(user.Password)).ToListAsync();
            if (!result.Any())
                return new OperationResultDto<Companys>(status: false, message: "Kullanıcı Adı Veya Şifre Hatalı", result: null);

            return new OperationResultDto<Companys>(status: true, message: "Sistem Girişi Başarılı", result: result.SingleOrDefault());
        }

        public async Task<OperationResultDto> RegisterProcess(RegisterDto input)
        {
            if (await _context.Companys.AnyAsync(c => c.Phone.Equals(input.Phone)))
                return new OperationResultDto(status: false, message: " Company is Exist");

            var result = _context.Companys.Add(
                new Companys 
                {
                  Password=input.Password, 
                  CompanyName=input.Adress,
                  Adress=input.Adress,  
                  Phone=input.Phone,   
                  
                });
            await _context.SaveChangesAsync();
            return new OperationResultDto(true,"Success");
        }
    }
}
