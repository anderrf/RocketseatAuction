using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Communication.Responses;
using RocketseatAuction.API.Exceptions;
using RocketseatAuction.API.Filters;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;

namespace RocketseatAuction.API.Controllers
{
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public class OfferController : RocketseatAuctionBaseController
    {

        [HttpPost]
        [Route("{itemId}")]
        [ProducesResponseType(typeof(ResponseCreateOfferJson), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateOffer([FromRoute] int itemId, [FromBody] RequestCreateOfferJson request, [FromServices] CreateOfferUseCase useCase)
        {
            int offerId;
            try{
                offerId = useCase.Execute(itemId, request);
                return Created(string.Empty, new ResponseCreateOfferJson { OfferId = offerId });
            }
            catch(Exception ex){
                if(ex is InvalidUserException){
                    return Unauthorized();
                }
                if(ex is ResourceNotFoundException){
                    return NotFound();
                }
                if(ex is InsufficientOfferPriceException){
                    return BadRequest();
                }
                return BadRequest();
            }
        }
    }
}
