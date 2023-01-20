namespace ParksApi.Models
{
  public class Type 
  {
    public int TypeId { get; set; }
    public string Summary { get; set; }
    public int Rating { get; set; }

    public int ParkrecId { get; set; }
  }
}