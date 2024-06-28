using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class LogEntryController : ControllerBase
{
    private readonly ControlSystemContext _context;

    public LogEntryController(ControlSystemContext context)
    {
        _context = context;
    }

    [HttpGet("{buildingId}")]
    public async Task<ActionResult<IEnumerable<LogEntry>>> GetLogEntries(int buildingId)
    {
        return await _context.LogEntries.Where(le => le.BuildingID == buildingId).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<LogEntry>> PostLogEntry(LogEntry logEntry)
    {
        _context.LogEntries.Add(logEntry);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetLogEntries), new { buildingId = logEntry.BuildingID }, logEntry);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutLogEntry(int id, LogEntry logEntry)
    {
        if (id != logEntry.ID)
        {
            return BadRequest();
        }
        _context.Entry(logEntry).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LogEntryExists(id))
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
    public async Task<IActionResult> DeleteLogEntry(int id)
    {
        var logEntry = await _context.LogEntries.FindAsync(id);
        if (logEntry == null)
        {
            return NotFound();
        }
        _context.LogEntries.Remove(logEntry);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool LogEntryExists(int id)
    {
        return _context.LogEntries.Any(e => e.ID == id);
    }
}
