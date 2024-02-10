﻿using FluentAssertions;
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

namespace UseCases.Test.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCaseTest
    {
        [Fact]
        public void Success()
        {
            //Arrange
            var entity = new Faker<Auction>()
                .RuleFor(auction => auction.Id, f => f.Random.Number(1, 10))
                .RuleFor(auction => auction.Name, f => f.Lorem.Word())
                .RuleFor(auction => auction.Starts, f => f.Date.Past())
                .RuleFor(auction => auction.Ends, f => f.Date.Future())
                .RuleFor(auction => auction.Items, (f, auction) => new List<Item>
                {
                new Item{
                    Id =  f.Random.Number(1, 10),
                    Name =  f.Commerce.ProductName(),
                    Brand =  f.Commerce.Department(),
                    BasePrice =  f.Random.Decimal(50, 1000),
                    Condition =  f.PickRandom<Condition>(),
                    AuctionId =  auction.Id
                }
                }).Generate();
            var mock = new Mock<IAuctionRepository>();
            mock.Setup(i => i.GetCurrent()).Returns(entity);
            var useCase = new GetCurrentAuctionUseCase(mock.Object);

            //Act
            var result = useCase.Execute();
            var auction = result.Auction;

            //Assert
            auction.Should().NotBeNull();
            auction.Id.Should().Be(entity.Id);
            auction.Name.Should().Be(entity.Name);
        }
    }
}