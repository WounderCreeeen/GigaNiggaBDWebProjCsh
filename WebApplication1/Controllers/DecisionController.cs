using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class DecisionController : ControllerBase
{
    private readonly ControlSystemContext _context;

    public DecisionController(ControlSystemContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Decision>>> GetDecisions()
    {
        return await _context.Decisions.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Decision>> PostDecision(Decision decision)
    {
        _context.Decisions.Add(decision);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetDecisions), new { id = decision.ID }, decision);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutDecision(int id, Decision decision)
    {
        if (id != decision.ID)
        {
            return BadRequest();
        }
        _context.Entry(decision).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DecisionExists(id))
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
    public async Task<IActionResult> DeleteDecision(int id)
    {
        var decision = await _context.Decisions.FindAsync(id);
        if (decision == null)
        {
            return NotFound();
        }
        _context.Decisions.Remove(decision);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool DecisionExists(int id)
    {
        return _context.Decisions.Any(e => e.ID == id);
    }
}
