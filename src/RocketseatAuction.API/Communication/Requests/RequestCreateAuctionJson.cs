namespace RocketseatAuction.API.Communication.Requests
{

    public class RequestCreateAuctionJson
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Starts { get; set; }
        public DateTime Ends { get; set; }
    }
}
