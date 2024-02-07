namespace RocketseatAuction.API.Entities;

public class Offer
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public decimal Price { get; set; }
    public int itemId { get; set; }
    public int userId { get; set; }
}
