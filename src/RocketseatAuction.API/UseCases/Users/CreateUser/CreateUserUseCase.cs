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

    public int Execute(RequestCreateUserJson request)
    {
        var existsUserWithEmail = _userRepository.ExistsUserWithEmail(request.Email);
        if(existsUserWithEmail)
        {
            throw new UserAlreadyExistsException();
        }
        var user = new User
        {
            Name = request.Name,
            Email = request.Email
        };
        _userRepository.Add(user);
        return user.Id;
    }
}
