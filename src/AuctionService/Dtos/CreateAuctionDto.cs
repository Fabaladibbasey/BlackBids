namespace AuctionService.Dtos;

public class CreateAuctionDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public string ImageUrl { get; set; }
    public string Type { get; set; }
    public string Brand { get; set; }
    public string Condition { get; set; }
    public int ReservePrice { get; set; } = 0;
    public DateTime AuctionEnd { get; set; }
}
