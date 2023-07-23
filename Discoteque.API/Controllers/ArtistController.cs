namespace Discoteque.API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Discoteque.Business.IServices;
using Discoteque.Data.Models;

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
  [Route("GetAllArtists")]
  public async Task<IActionResult> GetAllArtistsAsync()
  {
    var artists = await _artistService.GetArtistsAsync();
    return Ok(artists);
  }

  [HttpPost]
  [Route("CreateArtist")]
  public async Task<IActionResult> CreateArtistAsync(Artist artist)
  {
    var response = await _artistService.CreateArtist(artist);
    return Ok(response);
  }

  [HttpPatch]
  [Route("UpdateArtist")]
  public async Task<IActionResult> UpdateArtistAsync(Artist artist)
  {
    var response = await _artistService.UpdateArtist(artist);
    return Ok(response);
  }
}
