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

namespace UseCases.Test.Auctions.GetCurrent
{
    public class CreateOfferUseCaseTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Success(int itemId)
        {
            //Arrange
            var request = new Faker<RequestCreateOfferJson>()
                .RuleFor(request => request.Price, f => f.Random.Decimal(1, 700))
                .Generate();
            var offerRepository = new Mock<IOfferRepository>();
            var loggedUser = new Mock<ILoggedUser>();
            loggedUser.Setup(i => i.User()).Returns(new User());
            var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

            //Act
            var act = () => useCase.Execute(itemId, request);

            //Assert
            act.Should().NotThrow();
        }
    }
}