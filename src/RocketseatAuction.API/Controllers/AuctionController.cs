using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;
using RocketseatAuction.API.Communication.Responses;
using RocketseatAuction.API.UseCases.Auctions.CreateAuction;
using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Exceptions;
using RocketseatAuction.API.Filters;

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
            {
                return NoContent();
            }
            return Ok(new ResponseGetCurrentAuctionJson { Auction = result });
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreateAuctionJson), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ServiceFilter(typeof(AuthenticationUserAttribute))]
        public IActionResult CreateAuction([FromServices] CreateAuctionUseCase useCase, [FromBody] RequestCreateAuctionJson request)
        {
            try
            {
                var result = useCase.Execute(request);
                return Ok(new ResponseCreateAuctionJson { AuctionId = result.Id });
            }
            catch(Exception ex)
            {
                if(ex is InvalidDateRangeException)
                {
                    return BadRequest();
                }
                return BadRequest();
            }
        }
    }
}
