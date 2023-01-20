namespace ParksApi.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    public string Name { get; set; }

    public List<Type> Types { get; set; }
  }
}