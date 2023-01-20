namespace ParksApi.Models
{
  public class Parkrec
  {
    public int ParkrecId { get; set; }
    public string Name { get; set; }

    public List<Tipe> Tipes { get; set; }
  }
}