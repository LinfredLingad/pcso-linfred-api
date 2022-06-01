using PCSO_Linfred_API.Data;
using PCSO_Linfred_API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace PCSO_Linfred_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficesController : ControllerBase
    {
        private readonly DataContext _context;
        public OfficesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Office>>> GetOffices()
        {
            return await _context.Offices.ToListAsync();
        }


        [HttpGet("Officer/{officeId}")]
        public async Task<ActionResult<IEnumerable<Office>>> GetOfficesByOfficeID(int officeId)
        {
            return await _context.Offices.Where(s=> s.officeId == officeId).ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Office>> GetOffices(int id)
        {
            var officeList = await _context.Offices.FindAsync(id);
            if (officeList == null)
            {
                return NotFound();
            }
            return officeList;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffices(int id, Office offices)
        {
            
            offices.id = id;
            _context.Entry(offices).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!officeListExists(id))
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
        
        [HttpPost]
        public async Task<ActionResult<Office>> PostOffice(Office office)
        {
            _context.Offices.Add(office);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetOffice", new { id = office.id }, office);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffice(int id)
        {
            var officeList = await _context.Offices.FindAsync(id);
            if (officeList == null)
            {
                return NotFound();
            }
            _context.Offices.Remove(officeList);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool officeListExists(int id)
        {
            return _context.Offices.Any(e => e.id == id);
        }
    }
}