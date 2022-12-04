using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleQuotes.Data;
using VehicleQuotes.Models;

namespace VehicleQuotes.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuoteRulesController : ControllerBase
{
    private readonly VehicleQuotesContext _context;

    public QuoteRulesController(VehicleQuotesContext context)
    {
        _context = context;
    }

    // GET: api/QuoteRules/FeatureTypes
    [HttpGet("FeatureTypes")]
    public ActionResult<IEnumerable<string>> GetFeatureTypes()
    {
        return QuoteRule.FeatureTypes.All;
    }

    // GET: api/QuoteRules
    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuoteRule>>> GetQuoteRules()
    {
        return await _context.QuoteRules.ToListAsync();
    }

    // GET: api/QuoteRules/5
    [HttpGet("{id}")]
    public async Task<ActionResult<QuoteRule>> GetQuoteRule(int id)
    {
        QuoteRule? quoteRule = await _context.QuoteRules.FindAsync(id);

        return quoteRule ?? (ActionResult<QuoteRule>)NotFound();
    }

    // PUT: api/QuoteRules/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutQuoteRule(int id, QuoteRule quoteRule)
    {
        if (id != quoteRule.ID)
        {
            return BadRequest();
        }

        _context.Entry(quoteRule).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!QuoteRuleExists(id))
        {
            return NotFound();
        }
        catch (DbUpdateException)
        {
            return Conflict();
        }

        return NoContent();
    }

    // POST: api/QuoteRules
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<QuoteRule>> PostQuoteRule(QuoteRule quoteRule)
    {
        _context.QuoteRules.Add(quoteRule);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            return Conflict();
        }

        return CreatedAtAction("GetQuoteRule", new { id = quoteRule.ID }, quoteRule);
    }

    // DELETE: api/QuoteRules/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuoteRule(int id)
    {
        QuoteRule? quoteRule = await _context.QuoteRules.FindAsync(id);
        if (quoteRule == null)
        {
            return NotFound();
        }

        _context.QuoteRules.Remove(quoteRule);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool QuoteRuleExists(int id)
    {
        return _context.QuoteRules.Any(e => e.ID == id);
    }
}
