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
public class SizesController : ControllerBase
{
    private readonly VehicleQuotesContext _context;

    public SizesController(VehicleQuotesContext context)
    {
        _context = context;
    }

    // GET: api/Sizes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Size>>> GetSizes()
    {
        if (_context.Sizes == null)
        {
            return NotFound();
        }
        return await _context.Sizes.ToListAsync();
    }

    // GET: api/Sizes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Size>> GetSize(int id)
    {
        if (_context.Sizes == null)
        {
            return NotFound();
        }
        Size? size = await _context.Sizes.FindAsync(id);

        return size ?? (ActionResult<Size>)NotFound();
    }
}
