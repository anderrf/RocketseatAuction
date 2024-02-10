using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Communication.Responses;
using RocketseatAuction.API.Filters;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;

namespace RocketseatAuction.API.Controllers
{
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public class OfferController : RocketseatAuctionBaseController
    {

        [HttpPost]
        [Route("{itemId}")]
        [ProducesResponseType(typeof(ResponseCreateOfferJson), StatusCodes.Status201created)]
        public IActionResult CreateOffer([FromRoute] int itemId, [FromBody] RequestCreateOfferJson request, [FromServices] CreateOfferUseCase useCase)
        {
            var offerId = useCase.Execute(itemId, request);
            return Created(string.Empty, new ResponseCreateOfferJson { OfferId = offerId });
        }
    }
}
