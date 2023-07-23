namespace Discoteque.Data.Models;

using System.ComponentModel.DataAnnotations;

public class BaseEntity<T> where T : struct
{
  [Key]
  public T Id { get; set; } // primary key
}
