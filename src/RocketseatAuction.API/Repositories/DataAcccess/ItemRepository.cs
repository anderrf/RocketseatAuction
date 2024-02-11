using RocketseatAuction.API.Contracts;

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
    }
}
