using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Communication.Responses;
using RocketseatAuction.API.Exceptions;
using RocketseatAuction.API.Filters;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;
using RocketseatAuction.API.UseCases.Users.CreateUser;

namespace RocketseatAuction.API.Controllers
{
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public class UserController : RocketseatAuctionBaseController
    {

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateUser([FromBody] RequestCreateUserJson request, [FromServices] CreateUserUseCase useCase)
        {
            try{
                useCase.Execute(request);
                return Created(string.Empty, null);
            }
            catch(Exception ex){
                if(ex is UserAlreadyExistsException)
                {
                    return Conflict();
                }
                return BadRequest();
            }
        }
    }
}
