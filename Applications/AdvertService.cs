using Advert.Domain.Dtos;
using Advert.Domain.Entityes;
using Advert.Domain.Interfaces;
using Advert.Domain.ViewModels;
using Advert.Infrastructer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advert.Applications
{
    public interface IAdvertService : IScopedDependency
    {
        Task<AdvertViewModel> GetAdvertsViewModel();
        Task<AdvertListDto> GetAdvertsById(long id);
        Task<OperationResultDto> Create(AdvertListDto dto);
        Task<OperationResultDto> Edit(AdvertListDto dto);
        Task<OperationResultDto> Delete(long id);
    }
    public class AdvertService : ServicesBase, IAdvertService
    {
        private readonly IRedisService _redis;
        public AdvertService(IRedisService redis,IAppDbContext context, IHttpContextAccessor? httpContextAccessor) : base(context, httpContextAccessor)
        {
            _redis = redis; 

            
        }

        public async Task<OperationResultDto> Delete(long id)
        {
            var adv = await _context.Adverts.SingleAsync(x => x.Id == id);
            _context.Adverts.Remove(adv);
            await _context.SaveChangesAsync();
            return new OperationResultDto(true, "İlan Silindi");

        }

        public async Task<AdvertListDto> GetAdvertsById(long id)
        {
            var advert = await _context.Adverts.Include(c => c.Company).SingleAsync(x => x.Id == id);
            return new AdvertListDto
            {
                Benefits = advert.Benefits,
                CompanyId = advert.CompanyId,
                Id = advert.Id,
                IsOnline = advert.IsOnline,
                JobType = advert.JobType,
                PositionDesc = advert.PositionDesc,
                PositionTitle = advert.PositionTitle,
                Rate = advert.AdvertQualityRate,
                StartDate = advert.CreatedDate,
                EndDate = advert.CreatedDate.AddDays(advert.AdvertDayLimit),
                Wage = advert.Wage,

            };
        }

        public async Task<AdvertViewModel> GetAdvertsViewModel()
        {
            var res = new AdvertViewModel();
            var company = await _context.Companys.Include(a => a.Adverts).AsNoTracking().SingleAsync(x => x.Phone.Equals(User.Phone));
            res.CompanyInfo = company;
            res.AdvertList = company.Adverts.Select(x => new AdvertListDto
            {
                Benefits = x.Benefits,
                CompanyId = x.CompanyId,
                Id = x.Id,
                IsOnline = x.IsOnline,
                JobType = x.JobType,
                PositionDesc = x.PositionDesc,
                PositionTitle = x.PositionTitle,
                Rate = x.AdvertQualityRate,
                StartDate = x.CreatedDate,
                EndDate = x.CreatedDate.AddDays(x.AdvertDayLimit),
                Wage = x.Wage,
                IsOnlineText = x.IsOnline ? "Yayında" : "Yayında Değil"
            }).ToList();
            return res;

        }

        public async Task<OperationResultDto> Create(AdvertListDto dto)
        {
            var company = await _context.Companys.Include(a => a.Adverts).AsNoTracking().SingleAsync(x => x.Phone.Equals(User.Phone));
            if (company.Adverts.Count(x => x.IsOnline) >= company.AdvertsLimit)
                return new OperationResultDto(false, $"İlan Yayınlanamadı !  {company.AdvertsLimit} Adet İlan Yayınlayabilirsiniz!");

            _context.Adverts.Add(new Adverts
            {
                AdvertDayLimit = 15,
                Benefits = dto.Benefits,
                CompanyId = company.Id,
                AdvertQualityRate = await CalcAdvertQualityRate(dto),
                IsOnline = dto.IsOnline ?? false,
                JobType = dto.JobType,
                PositionDesc = dto.PositionDesc,
                PositionTitle = dto.PositionTitle,
                Wage = dto.Wage,

            });
            await _context.SaveChangesAsync();
            return new OperationResultDto(true, "Kayıt Başarılı Ve ilan Yayınlandı");
        }
        public async Task<OperationResultDto> Edit(AdvertListDto dto)
        {
            var adv = await _context.Adverts.SingleAsync(x => x.Id == dto.Id);
            adv.Benefits = dto.Benefits;
            adv.CompanyId = dto.CompanyId;
            adv.AdvertQualityRate = await CalcAdvertQualityRate(dto);
            adv.IsOnline = dto.IsOnline ?? false;
            adv.JobType = dto.JobType;
            adv.PositionDesc = dto.PositionDesc;
            adv.PositionTitle = dto.PositionTitle;
            adv.Wage = dto.Wage;

            _context.Adverts.Update(adv);
            await _context.SaveChangesAsync();
            return new OperationResultDto(true, "Kayıt Başarılı Ve ilan Yayınlandı");
        }

        public  void CheckLimit(ref AdvertListDto entity) 
        {
            long id=entity.Id; ;
            var company =  _context.Companys.Include(a => a.Adverts).AsNoTracking().SingleAsync(x => x.Id==id).GetAwaiter().GetResult();
            if (company.Adverts.Count(x => x.IsOnline) >= company.AdvertsLimit)
            
                entity.IsOnline = false;
            

        }

        public async Task<int> CalcAdvertQualityRate(AdvertListDto dto) 
        {
            int res = 0;
            if (!string.IsNullOrEmpty(dto.JobType))
                 res ++;
            if (!string.IsNullOrEmpty(dto.Wage))
                res ++;
            if (!string.IsNullOrEmpty(dto.Benefits))
                res++;
          
            if(await CheckKeywords(dto))
                res=res+2;
            return res;

        }

        public async Task<bool> CheckKeywords(AdvertListDto dto) 
        {
          var keywords=  await _context.KeyWordBlackList.AsNoTracking().Select(x=>x.KeyWord.ToLower()).ToListAsync();

            foreach (var item in keywords)
            {
                if (dto.PositionTitle.ToLower().Contains(item))
                    return false;

                if (dto.PositionDesc.ToLower().Contains(item))
                    return false;
            }
        
            return true;    
          
        
        }
    }
}
