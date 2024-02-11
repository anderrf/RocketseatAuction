using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Exceptions;
using RocketseatAuction.API.Services;

namespace RocketseatAuction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IOfferRepository _offerRepository;
    private readonly IItemRepository _itemRepository;

    public CreateOfferUseCase(ILoggedUser loggedUser, IOfferRepository offerRepository, IItemRepository itemRepository)
    {
        _loggedUser = loggedUser;
        _offerRepository = offerRepository;
        _itemRepository = itemRepository;
    }

    public int Execute(int itemId, RequestCreateOfferJson request)
    {
        
        var user = _loggedUser.User();
        if(user is null){
            throw new InvalidUserException();
        }
        var itemExists = _itemRepository.ExistsItemWithId(itemId);
        if(!itemExists){
            throw new ResourceNotFoundException();
        }
        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id,
        };
        _offerRepository.Add(offer);
        return offer.Id;
    }
}
