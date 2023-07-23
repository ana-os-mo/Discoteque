namespace Discoteque.Business;

using Discoteque.Data;
using Discoteque.Data.Models;

/// <summary>
/// This is an Album service implementation of <see cref="IAlbumService"/>
/// </summary>
public class AlbumService : IAlbumService
{
  private readonly IUnitOfWork _unitOfWork;

  public AlbumService(IUnitOfWork unitOfWork)
  {
    _unitOfWork = unitOfWork;
  }

  public async Task<Album> CreateAlbum(Album album)
  {
    var newAlbum = new Album
    {
      Name = album.Name,
      ArtistId = album.ArtistId,
      Genre = album.Genre,
      Year = album.Year
    };

    await _unitOfWork.AlbumRepository.AddAsync(newAlbum);
    await _unitOfWork.SaveAsync();

    return newAlbum;
  }

  public async Task<Album> GetAlbumById(int id)
  {
    var album = await _unitOfWork.AlbumRepository.FindAsync(id);
    return album;
  }

  public async Task<IEnumerable<Album>> GetAlbumsAsync(bool areReferencesLoaded)
  {
    IEnumerable<Album> albums = areReferencesLoaded
      ? await _unitOfWork.AlbumRepository.GetAllAsync(null, x => x.OrderBy(x => x.Id), new Artist().GetType().Name)
      : await _unitOfWork.AlbumRepository.GetAllAsync();
    return albums;
  }

  public async Task<IEnumerable<Album>> GetAlbumsByArtist(string artist)
  {
    IEnumerable<Album> albums = await _unitOfWork.AlbumRepository.GetAllAsync(
      x => x.Artist.Name.Equals(artist),
      x => x.OrderBy(x => x.Id),
      new Artist().GetType().Name);

    return albums;
  }

  public async Task<IEnumerable<Album>> GetAlbumsByGenre(Genres genre)
  {
    IEnumerable<Album> albums;
    albums = await _unitOfWork.AlbumRepository.GetAllAsync(
      x => x.Genre.Equals(genre),
      x => x.OrderBy(x => x.Id),
      new Artist().GetType().Name);

    return albums;
  }

  public async Task<IEnumerable<Album>> GetAlbumsByYear(int year)
  {
    IEnumerable<Album> albums;
    albums = await _unitOfWork.AlbumRepository.GetAllAsync(
      x => x.Year == year,
      x => x.OrderBy(x => x.Id),
      new Artist().GetType().Name);

    return albums;
  }

  public async Task<IEnumerable<Album>> GetAlbumsByYearRange(int startYear, int endYear)
  {
    IEnumerable<Album> albums;
    albums = await _unitOfWork.AlbumRepository.GetAllAsync(
      x => x.Year >= startYear && x.Year <= endYear,
      x => x.OrderBy(x => x.Id),
      new Artist().GetType().Name
    );

    return albums;
  }

  public async Task<Album> UpdateAlbum(Album album)
  {
    await _unitOfWork.AlbumRepository.Update(album);
    await _unitOfWork.SaveAsync();
    return album;
  }
}
