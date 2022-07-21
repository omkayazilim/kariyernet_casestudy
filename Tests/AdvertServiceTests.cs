
using Advert.Applications;
using Advert.Domain.Entityes;
using Advert.Infrastructer;
using AutoFixture;
using Microsoft.AspNetCore.Http;
using Moq;

using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.TestHelpers;
using Xunit;


namespace Tests
{
    public class AdvertServiceTests
    {
        private readonly Fixture _fixture;
        private Mock<IAppDbContext> _dbMock;
        private Mock<IRedisService> _redisMock;   
        private Mock<IHttpContextAccessor> _accessorMock;
        private IAdvertService _advertService;
       
        public AdvertServiceTests()
        {
             _fixture = new Fixture();
             _dbMock = new Mock<IAppDbContext>();  
            _redisMock = new Mock<IRedisService>(); 
            _accessorMock = new Mock<IHttpContextAccessor>();

               
        }

        [Fact]
        public async Task GetAppDinemsions_test() 
        {

            var AdvertssData = _fixture.Build<Adverts>()
                .With(x=>x.CompanyId,1)
                .With(x=>x.Company,new Companys {Id=1 })

                .CreateMany(3).ToList();
            AdvertssData.Add(_fixture.Build<Adverts>()
                .With(x => x.CompanyId, 1)
                .With(x => x.Company, new Companys { Id = 1 })
                .With(x=>x.Id,1)
                .Create());
            var dbset = DbMockHelper.CreateMockDbSet<Adverts>(AdvertssData);
            _dbMock.Setup(x=>x.Adverts).Returns(dbset);
            _advertService = new AdvertService(_redisMock.Object, _dbMock.Object,_accessorMock.Object);
            var result= await _advertService.GetAdvertsById(1);

            /// Assert
            result.ShouldNotBeNull();
            


        }

    }
}
