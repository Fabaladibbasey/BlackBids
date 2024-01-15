namespace AuctionService.Entities;

public class Product
{

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public string ImageUrl { get; set; }
    public string Type { get; set; }
    public string Brand { get; set; }
    public string Condition { get; set; }
    // public string PublicId { get; set; }

    public Auction Auction { get; set; }
    public Guid AuctionId { get; set; }
}
