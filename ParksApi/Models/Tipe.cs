namespace ParksApi.Models
{
  public class Tipe 
  {
    public int TipeId { get; set; }
    public string Summary { get; set; }
    public int Rating { get; set; }

    public int ParkrecId { get; set; }
  }
}