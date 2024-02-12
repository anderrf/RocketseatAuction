using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Contracts
{

    public interface IItemRepository
    {
        bool ExistsItemWithId(int id);
        Item? GetById(int id);
    }
}
