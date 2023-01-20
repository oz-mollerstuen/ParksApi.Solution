using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace ParksApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class ParkrecController : ControllerBase
  {
    private readonly ParksApiContext _db;

    public ParkrecController(ParksApiContext db)
    {
      _db = db;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Parkrec>> GetParkrec(int id)
    {
      Parkrec parkrec = await _db.Parkrecs.FindAsync(id);

      if (parkrec == null)
      {
        return NotFound();
      }
      return parkrec;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Parkrec>>> Get(string name)
    {
      IQueryable<Parkrec> query = _db.Parkrecs.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      return await query.Include(tipe => tipe.Tipes).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Parkrec>> Post(Parkrec parkrec)
    {
      _db.Parkrecs.Add(parkrec);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetParkrec), new { id = parkrec.ParkrecId }, parkrec);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Parkrec parkrec)
    {
      if (id != parkrec.ParkrecId)
      {
        return BadRequest();
      }
      _db.Parkrecs.Update(parkrec);


      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkrecExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    private bool ParkrecExists(int id)
    {
      return _db.Parkrecs.Any(e => e.ParkrecId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteParkrec(int id)
    {
      Parkrec parkrec = await _db.Parkrecs.FindAsync(id);
      if (parkrec == null)
      {
        return NotFound();
      }

      _db.Parkrecs.Remove(parkrec);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}