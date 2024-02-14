# Rocketseat Auction

![Badge](https://img.shields.io/static/v1?label=&message=DOTNET+V8.0&color=purple&style=for-the-badge&logo=DOTNET)
![Badge](https://img.shields.io/static/v1?label=&message=CSHARP&color=purple&style=for-the-badge&logo=CSHARP)

## API project for auctions

### API

#### Requests
```
RequestCreateAuctionJson
{
    string Name
    DateTime Starts
    DateTime Ends
}

RequestAddItemJson
{
    string Name
    string Brand
    Condition Condition
    decimal BasePrice
}

RequestCreateUserJson
{
    string Name
    string Email
}

RequestCreateOfferJson
{
    decimal Price
}
```

#### Responses
```
ResponseCreateAuctionJson
{
    int AuctionId
}

ResponseGetCurrentAuctionJson
{
    public Auction Auction
}

ResponseAddItemJson
{
    int ItemId
}

ResponseCreateOfferJson
{
    int OfferId
}
```

#### Routes
- Auction
    - POST `/Auction`
        - Receives `RequestCreateAuctionJson`;
        - Returns `ResponseCreateAuctionJson`;
        - Creates `Auction`, return its id on success;
        - Requires user to be authenticated for access;
        - `Ends` body property should be later than both `Starts` property and current date.
    - GET `/Auction`
        - Returns `ResponseGetCurrentAuctionJson`;
        - Fetches for an active `Auction` object, returning it on success;
        - An `Auction` is active when current date is between the `Starts` and `Ends` fields.
    - POST `/Auction/{auctionId}/add-item`
        - Receives `RequestAddItemJson` on body, and `auctionId` int parameter on route;
        - Returns `ResponseAddItemJson`;
        - Creates item on specified auction, then returns its id on success;
        - Requires user to be authenticated for access;
        - An `Item` can only be registered for an active `Auction`;
        - The `BasePrice` body property should be a positive decimal number.

- User
    - POST `/User`
        - Receives `RequestCreateUserJson` on body;
        - Creates an `User`;
        - Requires user to be authenticated for access;
        - The `Email` body property should not be an e-mail that's already registered on database.

- Offer
    - POST `/Offer/{itemId}`
        - Receives `RequestCreateOfferJson` on body, and `itemId` int parameter on query;
        - Returns `ResponseCreateOfferJson` on success;
        - Creates an `Offer` for a valid `Item`, referenced by parameter `itemId`;
        - Requires user to be authenticated for access;
        - The `Price` body property should be a positive decimal number, and it should also be larger than its specified `Item`'s `BasePrice` property.

### Credits
Application development made on Rocketseat's Next Level Week Expert event. Project based on instructor Welisson Arley's C# Course.