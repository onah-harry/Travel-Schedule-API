using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelSchedule.BackService.Data;
using TravelSchedule.BackService.Models;

namespace TravelSchedule.BackService.Controllers
{
    public class TravelController : ControllerBase
    {
        TravelDbContext _context;
        public TravelController(TravelDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var travels = await _context.Travels.ToListAsync();

                if (travels == null)
                {
                    return NotFound();
                }

                return Ok(travels);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Travel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Travels.Add(value);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut("")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Travel value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (!_context.Travels.Any(t => t.Id == id))
                {
                    return NotFound();
                }

                _context.Travels.Update(value);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                throw ex.Message;
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {

                var travel = _context.Travels.FindAsync(id);
                if (travel == null)
                {
                    return NotFound();
                }

                _context.Travels.Remove(travel);
                await _context.SaveChangesAsync();


                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}