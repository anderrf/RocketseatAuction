using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories.DataAcccess
{
    public class ItemRepository : IItemRepository
    {
        private readonly RocketseatAuctionDbContext _dbContext;

        public ItemRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;

        public bool ExistsItemWithId(int id)
        {
            return _dbContext.Items.Any(item => item.Id == id);
        }

        public Item? GetById(int id){
            return _dbContext.Items.FirstOrDefault(item => item.Id == id);
        }
    }
}
