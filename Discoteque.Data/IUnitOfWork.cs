namespace Discoteque.Data;

using Discoteque.Data.Models;

public interface IUnitOfWork
{
  IRepository<int, Artist> ArtistRepository { get; }
  IRepository<int, Album> AlbumRepository { get; }
  Task SaveAsync();
}
