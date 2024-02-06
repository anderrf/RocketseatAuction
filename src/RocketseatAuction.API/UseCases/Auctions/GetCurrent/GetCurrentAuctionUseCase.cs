using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    public Auction Execute()
    {
        return new Auction
        {
            Id = 1,
            Ends = DateTime.Now,
            Starts = DateTime.Now,
            Name = "Test"
        };
    }
}
