namespace RocketseatAuction.API.Communication.Requests
{

    public class RequestCreateAuctionJson
    {
        public string Name { get; set; }
        public DateTime Starts { get; set; }
        public DateTime Ends { get; set; }
    }
}
