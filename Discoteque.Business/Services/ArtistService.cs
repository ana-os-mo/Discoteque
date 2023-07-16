namespace Discoteque.Business.Services;

using Discoteque.Business.IServices;
using Discoteque.Data.Models;

public class ArtistService : IArtistService
{
  public Task<Artist> CreateArtist(Artist artist)
  {
    throw new NotImplementedException();
  }

  public Task<Artist> GetArtistById(int id)
  {
    throw new NotImplementedException();
  }

  public async Task<IEnumerable<Artist>> GetArtists()
  {
    // Temporary: remove when using the database
    await Task.CompletedTask;

    return new List<Artist>
    {
      new()
      {
        Id = 1,
        Name = "Interpol",
        Label = "Matador Records",
        IsOnTour = true
      },
      new()
      {
        Id = 2,
        Name = "Arctic Monkeys",
        Label = "Domino Recording Company",
        IsOnTour = true
      },
      new()
      {
        Id = 3,
        Name = "Lana Del Rey",
        Label = "Interscope Records",
        IsOnTour = false
      },
      new()
      {
        Id = 4,
        Name = "Tame Impala",
        Label = "Interscope Records",
        IsOnTour = true
      },
      new()
      {
        Id = 5,
        Name = "Radiohead",
        Label = "XL Recordings",
        IsOnTour = false
      }
    };
  }

  public Task<Artist> UpdateArtist(Artist artist)
  {
    throw new NotImplementedException();
  }
}
