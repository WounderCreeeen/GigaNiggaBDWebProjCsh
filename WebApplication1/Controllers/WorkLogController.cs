using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class WorkLogController : ControllerBase
{
    private readonly ControlSystemContext _context;

    public WorkLogController(ControlSystemContext context)
    {
        _context = context;
    }

    [HttpGet("{buildingId}")]
    public async Task<ActionResult<IEnumerable<WorkLog>>> GetWorkLogs(int buildingId)
    {
        return await _context.WorkLogs.Where(wl => wl.BuildingID == buildingId).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<WorkLog>> PostWorkLog(WorkLog workLog)
    {
        _context.WorkLogs.Add(workLog);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetWorkLogs), new { buildingId = workLog.BuildingID }, workLog);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutWorkLog(int id, WorkLog workLog)
    {
        if (id != workLog.ID)
        {
            return BadRequest();
        }
        _context.Entry(workLog).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!WorkLogExists(id))
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
    public async Task<IActionResult> DeleteWorkLog(int id)
    {
        var workLog = await _context.WorkLogs.FindAsync(id);
        if (workLog == null)
        {
            return NotFound();
        }
        _context.WorkLogs.Remove(workLog);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool WorkLogExists(int id)
    {
        return _context.WorkLogs.Any(e => e.ID == id);
    }
}
