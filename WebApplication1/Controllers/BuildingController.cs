using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BuildingController : ControllerBase
{
    private readonly ControlSystemContext _context;

    public BuildingController(ControlSystemContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Building>>> GetBuildings()
    {
        return await _context.Buildings.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Building>> GetBuilding(int id)
    {
        var building = await _context.Buildings.FindAsync(id);
        if (building == null)
        {
            return NotFound();
        }
        return building;
    }

    [HttpPost]
    public async Task<ActionResult<Building>> PostBuilding(Building building)
    {
        _context.Buildings.Add(building);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBuilding), new { id = building.ID }, building);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutBuilding(int id, Building building)
    {
        if (id != building.ID)
        {
            return BadRequest();
        }
        _context.Entry(building).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BuildingExists(id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBuilding(int id)
    {
        var building = await _context.Buildings.FindAsync(id);
        if (building == null)
        {
            return NotFound();
        }
        _context.Buildings.Remove(building);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool BuildingExists(int id)
    {
        return _context.Buildings.Any(e => e.ID == id);
    }
}
