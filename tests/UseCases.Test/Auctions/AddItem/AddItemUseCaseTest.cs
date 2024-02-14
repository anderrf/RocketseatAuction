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
using RocketseatAuction.API.UseCases.Auctions.AddItem;

namespace UseCases.Test.Auctions.AddItem
{
    public class AddItemUseCaseTest
    {
        [Theory]
        [InlineData(2)]
        public void Success(int auctionId)
        {
            //Arrange
            var request = new Faker<RequestAddItemJson>()
                .RuleFor(request => request.Name, f => f.Commerce.ProductName())
                .RuleFor(request => request.Brand, f => f.Commerce.Department())
                .RuleFor(request => request.BasePrice, f => f.Random.Decimal(50, 1000))
                .RuleFor(request => request.Condition, f => f.PickRandom<Condition>())
                .Generate();
            var auctionRepository = new Mock<IAuctionRepository>();
            auctionRepository.Setup(i => i.ExistsActiveAuctionWithId(auctionId)).Returns(true);
            var itemRepository = new Mock<IItemRepository>();
            var useCase = new AddItemUseCase(auctionRepository.Object, itemRepository.Object);

            //Act
            var act = () => useCase.Execute(request, auctionId);

            //Assert
            act.Should().NotThrow();
        }
    }
}