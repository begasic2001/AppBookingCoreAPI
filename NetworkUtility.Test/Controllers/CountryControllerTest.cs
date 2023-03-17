using Autofac.Features.OwnedInstances;
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using LearnAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBooking.Controllers;
using TourBooking.Dto;
using TourBooking.Helpers;
using TourBooking.Interfaces;
using Xunit;

namespace NetworkUtility.Test.Controllers
{
    public class PokemonControllerTests
    {
        private readonly ICountryService _countryService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PokemonControllerTests()
        {
            _countryService = A.Fake<ICountryService>();
            _unitOfWork = A.Fake<IUnitOfWork>();

            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void CountryController_GetCountry_ReturnOK()
        {
            //Arrange
            var countrys = A.Fake<ICollection<CountryDto>>();
            var countryLists = A.Fake<List<CountryDto>>();
            A.CallTo(() => _mapper.Map<List<CountryDto>>(countrys)).Returns(countryLists);
            var controller = new CountryController(_countryService, _unitOfWork);

            //Act
            var result = controller.GetAll();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void CountryController_CreateCountry_ReturnOK()
        {
            //Arrange
            var countryCreate = A.Fake<CountryDto>();
            countryCreate.Id = Guid.NewGuid().ToString();
            countryCreate.CountryName = "TestCountry";
            var country = A.Fake<ICollection<CountryDto>>();
            var countryList = A.Fake<IList<CountryDto>>();
            //Act
            A.CallTo(() => _mapper.Map<Country>(countryCreate));
            A.CallTo(() => _countryService.AddAsync(countryCreate));
            //var controller = new CountryController(_countryService, _unitOfWork);
            //var result = controller.Add(countryCreate);
            ////Assert
            //result.Should().NotBeNull();
        }
    }
}
