namespace Discoteque.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Artist : BaseEntity<int>
{
  /// <summary>
  /// Name of the artist.
  /// </summary>
  [Required(ErrorMessage = "The name of the artist is required")]
  public string Name { get; set; } = "";

  /// <summary>
  /// Name of the record company.
  /// </summary>
  [Required(ErrorMessage = "The company representing the artist is required")]
  public string Label { get; set; } = "";

  /// <summary>
  /// Indicates if the artist is on tour.
  /// </summary>
  public bool IsOnTour { get; set; } = false;
}
