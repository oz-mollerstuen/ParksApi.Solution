using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksApi.Models;

namespace ParksApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TipeController : ControllerBase
  {
    private readonly ParksApiContext _db;

    public TipeController(ParksApiContext db)
    {
      _db = db;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tipe>> GetTipe(int id)
    {
      Tipe tipe = await _db.Tipe.FindAsync(id);

      if (tipe == null)
      {
        return NotFound();
      }
      return tipe;
    }

    [HttpGet]
    public async Task<List<Tipe>> Get(int rating)
    {
      IQueryable<Tipe> query = _db.Tipes.AsQueryable();

      if (rating > 0 && rating < 6)
      {
        query = query.Where(entry => entry.Rating == rating);
      }

      return await query.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Tipe>> Post(Tipe tipe)
    {
      _db.Tipes.Add(tipe);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetTipe), new { id = tipe.TipeId }, tipe);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Tipe tipe)
    {
      if (id != tipe.TipeId)
      {
        return BadRequest();
      }
      _db.Tipes.Update(tipe);


      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TipeExists(id))
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

    private bool TipeExists(int id)
    {
      return _db.Tipes.Any(e => e.TipeId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTipe(int id)
    {
      Tipe tipe = await _db.Tipes.FindAsync(id);
      if (tipe == null)
      {
        return NotFound();
      }

      _db.Tipes.Remove(tipe);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}