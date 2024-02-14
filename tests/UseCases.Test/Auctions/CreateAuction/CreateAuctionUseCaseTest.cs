using FluentAssertions;
using Moq;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RocketseatAuction.API.Entities;
using Xunit;
using Bogus;
using RocketseatAuction.API.Enums;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;
using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Services;
using RocketseatAuction.API.UseCases.Users.CreateUser;
using RocketseatAuction.API.UseCases.Auctions.CreateAuction;

namespace UseCases.Test.Auctions.CreateAuction
{
    public class CreateAuctionUseCaseTest
    {
        [Fact]
        public void Success()
        {
            //Arrange
            var request = new Faker<RequestCreateAuctionJson>()
                .RuleFor(request => request.Name, f => f.Name.FullName())
                .RuleFor(request => request.Starts, f => f.Date.Past())
                .RuleFor(request => request.Ends, f => f.Date.Future())
                .Generate();
            var auctionRepository = new Mock<IAuctionRepository>();
            var useCase = new CreateAuctionUseCase(auctionRepository.Object);

            //Act
            var act = () => useCase.Execute(request);

            //Assert
            act.Should().NotThrow();
        }
    }
}