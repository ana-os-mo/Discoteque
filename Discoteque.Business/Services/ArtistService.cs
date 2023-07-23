namespace Discoteque.Business.Services;

using Discoteque.Business.IServices;
using Discoteque.Data;
using Discoteque.Data.Models;

public class ArtistService : IArtistService
{
  private IUnitOfWork _unitOfWork;

  public ArtistService(IUnitOfWork unitOfWork)
  {
    _unitOfWork = unitOfWork;
  }

  public async Task<Artist> CreateArtist(Artist artist)
  {
    await _unitOfWork.ArtistRepository.AddAsync(artist);
    await _unitOfWork.SaveAsync();
    return artist;
  }

  public async Task<Artist> GetArtistById(int id)
  {
    return await _unitOfWork.ArtistRepository.FindAsync(id);
  }

  public async Task<IEnumerable<Artist>> GetArtistsAsync()
  {
    return await _unitOfWork.ArtistRepository.GetAllAsync();
  }

  public async Task<Artist> UpdateArtist(Artist artist)
  {
    await _unitOfWork.ArtistRepository.Update(artist);
    await _unitOfWork.SaveAsync();
    return artist;
  }
}
