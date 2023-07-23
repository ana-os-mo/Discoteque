namespace Discoteque.Business.IServices;

using Discoteque.Data.Models;

public interface IArtistService
{
  Task<IEnumerable<Artist>> GetArtistsAsync();
  Task<Artist> GetArtistById(int id);
  Task<Artist> CreateArtist(Artist artist);
  Task<Artist> UpdateArtist(Artist artist);
}
