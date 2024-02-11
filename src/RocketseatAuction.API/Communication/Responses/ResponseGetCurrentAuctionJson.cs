using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Communication.Responses
{

    public class ResponseGetCurrentAuctionJson
    {
        public Auction Auction { get; set; }
    }
}
