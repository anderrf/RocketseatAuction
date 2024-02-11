# Rocketseat Auction

![Badge](https://img.shields.io/static/v1?label=&message=DOTNET+V8.0&color=purple&style=for-the-badge&logo=DOTNET)
![Badge](https://img.shields.io/static/v1?label=&message=CSHARP&color=purple&style=for-the-badge&logo=CSHARP)

## API project for auctions

### API

#### Requests
```
RequestCreateOfferJson
{
    decimal Price
}
```

#### Responses


#### Routes
- Auction
    - GET `/Auction`

        - Fetches for an active `Auction` object, returning it on success;
        - An `Auction` is active when current date is between the `Starts` and `Ends` fields.

- Offer
    - POST `/Offer/{itemId}`
        - Receives `RequestCreateOfferJson` on body, and `itemId` int parameter on query;
        - Creates an `Offer` for a valid `Item`, referenced by parameter `itemId`;
        - Requires user to be authenticated for access.
        - Returns id of created `Offer` on success.

### Credits
Application development made on Rocketseat's Next Level Week Expert event. Project based on instructor Welisson Arley's C# Course.