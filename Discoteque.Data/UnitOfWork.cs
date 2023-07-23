namespace Discoteque.Data;

using Discoteque.Data.Models;
using Microsoft.EntityFrameworkCore;

public class UnitOfWork : IUnitOfWork, IDisposable
{
  private readonly DiscotequeContext _context;
  private bool _disposed = false;
  private IRepository<int, Artist> _artistsRepository;
  private IRepository<int, Album> _albumsRepository;

  public UnitOfWork(DiscotequeContext context)
  {
    _context = context;
  }

  public IRepository<int, Artist> ArtistRepository
  {
    get
    {
      _artistsRepository ??= new Repository<int, Artist>(_context);
      return _artistsRepository;
    }
  }

  public IRepository<int, Album> AlbumRepository
  {
    get
    {
      _albumsRepository ??= new Repository<int, Album>(_context);
      return _albumsRepository;
    }
  }

  public async Task SaveAsync()
  {
    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException ex)
    {
      ex.Entries.Single().Reload();
    }
  }

  #region IDisposable
  protected virtual void Dispose(bool disposing)
  {
    if (!_disposed && disposing)
    {
      _context.DisposeAsync();
    }
    _disposed = true;
  }

  public void Dispose()
  {
    Dispose(true);
  }
  #endregion
}
