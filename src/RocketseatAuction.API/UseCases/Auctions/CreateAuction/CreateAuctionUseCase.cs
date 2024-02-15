using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Exceptions;

namespace RocketseatAuction.API.UseCases.Auctions.CreateAuction
{
    public class CreateAuctionUseCase
    {
        private readonly IAuctionRepository _repository;

        public CreateAuctionUseCase(IAuctionRepository repository) => _repository = repository;

        public Auction Execute(RequestCreateAuctionJson request)
        {
            var auction = new Auction
            {
                Name = request.Name,
                Starts = request.Starts,
                Ends = request.Ends
            };
            if(auction.Ends <= auction.Starts)
            {
                throw new InvalidDateRangeException();
            }
            if(auction.Ends <= DateTime.Now)
            {
                throw new InvalidDateRangeException();
            }
            _repository.Add(auction);
            return auction;
        }
    }
}
