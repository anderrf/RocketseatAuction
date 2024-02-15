using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories.DataAcccess;

public class UserRepository : IUserRepository
{
    private readonly RocketseatAuctionDbContext _dbContext;

    public UserRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;

    public bool ExistsUserWithEmail(string email)
    {
        return _dbContext.Users.Any(user => user.Email.Equals(email));
    }

    public User? GetUserByEmail(string email) => _dbContext.Users.FirstOrDefault(user => user.Email.Equals(email));

    public void Add(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }
}
