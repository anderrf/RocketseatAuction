using RocketseatAuction.API.Enums;

namespace RocketseatAuction.API.Communication.Requests
{

    public class RequestAddItemJson
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public Condition Condition { get; set; }
        public decimal BasePrice { get; set; }
    }
}
