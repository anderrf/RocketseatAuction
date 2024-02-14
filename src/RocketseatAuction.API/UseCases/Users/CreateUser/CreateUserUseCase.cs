using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Exceptions;
using RocketseatAuction.API.Services;

namespace RocketseatAuction.API.UseCases.Users.CreateUser;

public class CreateUserUseCase
{
    private readonly IUserRepository _userRepository;

    public CreateUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void Execute(RequestCreateUserJson request)
    {
        var user = new User
        {
            Name = request.Name,
            Email = request.Email
        };
        _userRepository.Add(user);
    }
}
