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

namespace UseCases.Test.Users.CreateUser
{
    public class CreateUserUseCaseTest
    {
        [Theory]
        [InlineData("anderson@anderson.com")]
        public void Success(string email)
        {
            //Arrange
            var request = new Faker<RequestCreateUserJson>()
                .RuleFor(request => request.Name, f => f.Name.FullName())
                .RuleFor(request => request.Email, f => f.Internet.Email(email))
                .Generate();
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(i => i.ExistsUserWithEmail(email)).Returns(false);
            var useCase = new CreateUserUseCase(userRepository.Object);

            //Act
            var act = () => useCase.Execute(request);

            //Assert
            act.Should().NotThrow();
        }
    }
}