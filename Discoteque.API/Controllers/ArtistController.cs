namespace Discoteque.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Discoteque.Business.IServices;

[Route("api/[controller]")]
[ApiController]
public class ArtistsController : ControllerBase
{
  private readonly IArtistService _artistService;

  public ArtistsController(IArtistService artistService)
  {
    _artistService = artistService;
  }

  [HttpGet]
  public async Task<IActionResult> GetArtistsAsync()
  {
    var artists = await _artistService.GetArtists();
    return Ok(artists);
  }
}
