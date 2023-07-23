namespace Discoteque.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Album : BaseEntity<int>
{
  /// <summary>
  /// Name of the Album.
  /// </summary>
  [Required(ErrorMessage = "Album name is required")]
  public string Name { get; set; } = ""; // default value if no value is assigned

  /// <summary>
  /// Year of album release.
  /// </summary>
  [Range(1900, 2025, ErrorMessage = "Invalid release year. Must be between 1900 and 2025")]
  public int Year { get; set; }

  /// <summary>
  /// <see cref="Genres" /> to which the album belongs.
  /// </summary>
  public Genres Genre { get; set; } = Genres.Unknown;

  /// <summary>
  /// The <see cref="Artist"/> id this Album belongs to.
  /// </summary>
  [ForeignKey("Id")]
  public int ArtistId { get; set; }

  /// <summary>
  /// The <see cref="Artist"/> Entity this album is refering to.
  /// </summary> <summary>
  public virtual Artist? Artist { get; set; }
}

/// <summary>
/// A collection of musical genres
/// </summary> <summary>
public enum Genres
{
  Rock,
  Metal,
  Salsa,
  Merengue,
  Urban,
  Folk,
  Indie,
  Techno,
  Vallenato,
  Pop,
  Unknown
}
