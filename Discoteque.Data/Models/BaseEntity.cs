namespace Discoteque.Data.Models;

public class BaseEntity<T> where T : struct
{
  public T Id { get; set; } // primary key
}
