using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using SearchService.Models;
using SearchService.RequestHelpers;

namespace SearchService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Product>>> SearchProductsAsync([FromQuery] SearchParams searchParams)
    {
        var query = DB.PagedSearch<Product, Product>();

        if (!string.IsNullOrEmpty(searchParams.SearchTerm))
        {
            query = query.Match(Search.Full, searchParams.SearchTerm);
        }

        query = searchParams.OrderBy switch
        {
            "brand" => query.Sort(p => p.Ascending(p => p.Brand)),
            "new" => query.Sort(p => p.Descending(p => p.CreatedAt)),
            _ => query.Sort(p => p.Ascending(p => p.AuctionEnd))
        };

        query = searchParams.FilterBy switch
        {
            "finished" => query.Match(p => p.Status == Status.Finished.ToString()),
            "endingSoon" => query.Match(p => p.AuctionEnd < DateTime.UtcNow.AddHours(6) && p.Status == Status.Live.ToString()),
            _ => query.Match(p => p.Status == Status.Live.ToString())
        };

        if (!string.IsNullOrEmpty(searchParams.Seller))
        {
            query = query.Match(p => p.Seller == searchParams.Seller);
        }

        if (!string.IsNullOrEmpty(searchParams.Winner))
        {
            query = query.Match(p => p.Winner == searchParams.Winner);
        }

        query.PageNumber(searchParams.PageNumber);
        query.PageSize(searchParams.PageSize);

        var result = await query.ExecuteAsync();

        return Ok(new
        {
            result = result.Results,
            pageCount = result.PageCount,
            totalCount = result.TotalCount
        });
    }
}
