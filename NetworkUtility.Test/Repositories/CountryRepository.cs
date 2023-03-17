using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using LearnAPI.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBooking.Repositories;
using TourBooking.Services;
using Xunit;

namespace NetworkUtility.Test.Repositories
{
    public class CountryRepository
    {
        private async Task<TourDatabaseContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<TourDatabaseContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new TourDatabaseContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Country.CountAsync() <= 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    databaseContext.Country.Add(
                    new Country()
                    {
                        Id = Guid.NewGuid().ToString(), 
                        CountryName = $"TestCountry{i}",
                   
                    });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }
        [Fact]
        public async void CountryRepository_GetCountry_ReturnsCountry()
        {
            //Arrange
            var irepository = A.Fake<IRepository<Country>>();
            var _mapper = A.Fake<IMapper>();
            var countryService = new CountryService(irepository, _mapper);

            //Act
            var result = countryService.GetAll();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Country>();
        }

        //[Fact]
        //public async Task CountryService_GetByIdAsync(string id)
        //{
        //    //Arrange
        //    var irepository = A.Fake<IRepository<Country>>();
        //    var _mapper = A.Fake<IMapper>();
        //    var pokemonRepository = new CountryService(irepository, _mapper);

        //    //Act
        //    //var result = await CountryService.GetAll(c => c.Id == id);

        //    ////Assert
        //    //result.Should().NotBe(0);
        //    //result.Should().BeInRange(1, 10);
        //}
    }
}

