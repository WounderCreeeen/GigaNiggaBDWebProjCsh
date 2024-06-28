using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ViolationLogController : ControllerBase
{
    private readonly ControlSystemContext _context;

    public ViolationLogController(ControlSystemContext context)
    {
        _context = context;
    }

    [HttpGet("{buildingId}")]
    public async Task<ActionResult<IEnumerable<ViolationLog>>> GetViolationLogs(int buildingId)
    {
        return await _context.ViolationLogs.Where(vl => vl.BuildingID == buildingId).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<ViolationLog>> PostViolationLog(ViolationLog violationLog)
    {
        _context.ViolationLogs.Add(violationLog);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetViolationLogs), new { buildingId = violationLog.BuildingID }, violationLog);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutViolationLog(int id, ViolationLog violationLog)
    {
        if (id != violationLog.ID)
        {
            return BadRequest();
        }
        _context.Entry(violationLog).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ViolationLogExists(id))
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
    public async Task<IActionResult> DeleteViolationLog(int id)
    {
        var violationLog = await _context.ViolationLogs.FindAsync(id);
        if (violationLog == null)
        {
            return NotFound();
        }
        _context.ViolationLogs.Remove(violationLog);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool ViolationLogExists(int id)
    {
        return _context.ViolationLogs.Any(e => e.ID == id);
    }
}
