namespace ParksApi.Models
{
  public class Parkrec
  {
    public int ParkrecId { get; set; }
    public string Name { get; set; }

    public List<Type> Types { get; set; }
  }
}