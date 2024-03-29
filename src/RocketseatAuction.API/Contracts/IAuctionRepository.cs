﻿using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Contracts
{

    public interface IAuctionRepository
    {
        Auction? GetCurrent();
        void Add(Auction auction);
        bool ExistsActiveAuctionWithId(int id);
    }
}
