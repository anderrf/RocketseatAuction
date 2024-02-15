using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories.DataAcccess;

public class AuctionRepository : IAuctionRepository
{
    private readonly RocketseatAuctionDbContext _dbContext;

    public AuctionRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;
    
    public Auction? GetCurrent()
    {
        var today = DateTime.Now;
        return _dbContext
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }

    public void Add(Auction auction)
    {
        _dbContext.Auctions.Add(auction);
        _dbContext.SaveChanges();
    }

    public bool ExistsActiveAuctionWithId(int id)
    {
        var today = DateTime.Now;
        return _dbContext
            .Auctions
            .Any(auction => auction.Id == id && today >= auction.Starts && today <= auction.Ends);
    }
}
