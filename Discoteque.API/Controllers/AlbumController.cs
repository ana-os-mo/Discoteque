namespace Discoteque.API;

using System.ComponentModel.DataAnnotations;
using Discoteque.Business;
using Discoteque.Data.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AlbumController : ControllerBase
{
  private readonly IAlbumService _albumService;

  public AlbumController(IAlbumService albumService)
  {
    _albumService = albumService;
  }

  [HttpGet]
  [Route("GetAllAlbums")]
  public async Task<IActionResult> GetAllAlbums(bool areReferencesLoaded = false)
  {
    var albums = await _albumService.GetAlbumsAsync(areReferencesLoaded);
    return Ok(albums);
  }

  [HttpGet]
  [Route("GetAlbumById/{id:int}")]
  public async Task<IActionResult> GetAlbumByIdAsync([Required] int id)
  {
    var album = await _albumService.GetAlbumById(id);
    return Ok(album);
  }

  [HttpGet]
  [Route("GetAlbumsByYear/{year:int}")]
  public async Task<IActionResult> GetAlbumsByYearAsync([Required] int year)
  {
    if (year > DateTime.Now.Year)
    {
      return BadRequest("The year of the release cannot be in the future");
    }

    var albums = await _albumService.GetAlbumsByYear(year);
    return albums.Any() ? Ok(albums)
    : StatusCode(StatusCodes.Status404NotFound, "There were no albums for the specified year");
  }

  [HttpGet]
  [Route("GetAlbumsByYearRange")]
  public async Task<IActionResult> GetAlbumsByYearRangeAsync([Required] int startYear, int? endYear = null)
  {
    if (!endYear.HasValue)
    {
      endYear = DateTime.Now.Year;
    }

    if (endYear > DateTime.Now.Year)
    {
      return BadRequest("The end year cannot be in the future");
    }

    var albums = await _albumService.GetAlbumsByYearRange(startYear, endYear.Value);
    return albums.Any() ? Ok(albums)
    : StatusCode(StatusCodes.Status404NotFound, "There were no albums for the specified year range");
  }

  [HttpGet]
  [Route("GetAlbumsByGenre")]
  public async Task<IActionResult> GetAlbumsByGenreAsync(Genres genre)
  {
    var albums = await _albumService.GetAlbumsByGenre(genre);
    return albums.Any() ? Ok(albums)
    : StatusCode(StatusCodes.Status404NotFound, "There were no albums for this genre");
  }

  [HttpGet]
  [Route("GetAlbumsByArtist")]
  public async Task<IActionResult> GetAlbumsByArtistAsync(string artist)
  {
    var albums = await _albumService.GetAlbumsByArtist(artist);
    return albums.Any() ? Ok(albums) : StatusCode(StatusCodes.Status404NotFound, "There were for this artist");
  }

  [HttpPost]
  [Route("CreateAlbum")]
  public async Task<IActionResult> CreateAlbumsAsync(Album album)
  {
    var result = await _albumService.CreateAlbum(album);
    return Ok(result);
  }
}
