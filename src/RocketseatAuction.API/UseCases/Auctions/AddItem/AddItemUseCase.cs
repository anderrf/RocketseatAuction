using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Exceptions;

namespace RocketseatAuction.API.UseCases.Auctions.AddItem
{
    public class AddItemUseCase
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IItemRepository _itemRepository;

        public AddItemUseCase(IAuctionRepository auctionRepository, IItemRepository itemRepository) {
            _auctionRepository = auctionRepository;
            _itemRepository = itemRepository;
        }

        public Item Execute(RequestAddItemJson request, int auctionId)
        {
            var existsActiveAuction = _auctionRepository.ExistsActiveAuctionWithId(auctionId);
            if(!existsActiveAuction)
            {
                throw new ResourceNotFoundException();
            }
            var item = new Item
            {
                Name = request.Name,
                Brand = request.Brand,
                BasePrice = request.BasePrice,
                AuctionId = auctionId
            };
            if(item.BasePrice <= 0)
            {
                throw new InvalidDateRangeException();
            }
            _itemRepository.Add(item);
            return item;
        }
    }
}
