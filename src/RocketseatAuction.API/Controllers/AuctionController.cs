using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;
using RocketseatAuction.API.Communication.Responses;

namespace RocketseatAuction.API.Controllers
{
    public class AuctionController : RocketseatAuctionBaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(ResponseGetCurrentAuctionJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetCurrentAuction([FromServices] GetCurrentAuctionUseCase useCase)
        {
            var result = useCase.Execute();
            if (result is null)
                return NoContent();
            return Ok(new ResponseGetCurrentAuctionJson { Auction = result });
        }
    }
}
