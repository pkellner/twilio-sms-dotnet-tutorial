using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : Controller
    {
        private readonly SmsDbContext _context;

        public SmsController(SmsDbContext context)
        {
            _context = context;
        }

        // GET: api/Sms
        [HttpGet]
        public IEnumerable<TwilioSmsModel> GetTwilioSmsModels()
        {
            if (_context.TwilioSmsModels.Count() == 0)
            {
                _context.AddRange(new List<TwilioSmsModel>()
                {
                    new TwilioSmsModel {SmsSid="0001"},
                    new TwilioSmsModel {SmsSid="0002"}
                });
                _context.SaveChanges();
            }

            return _context.TwilioSmsModels;
        }

        // GET: api/Sms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTwilioSmsModel([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var twilioSmsModel = await _context.TwilioSmsModels.FindAsync(id);

            if (twilioSmsModel == null)
            {
                return NotFound();
            }

            return Ok(twilioSmsModel);
        }

        // PUT: api/Sms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTwilioSmsModel(
            [FromRoute] string id, [FromBody] TwilioSmsModel twilioSmsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != twilioSmsModel.SmsSid)
            {
                return BadRequest();
            }

            _context.Entry(twilioSmsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TwilioSmsModelExists(id))
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

        // POST: api/Sms
        [HttpPost]
        public async Task<IActionResult> 
            Post([FromForm] TwilioSmsModel twilioSmsModel)
        {
            //var twilioSmsModel = new TwilioSmsModel();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TwilioSmsModels.Add(twilioSmsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTwilioSmsModel", 
                new { id = twilioSmsModel.SmsSid }, twilioSmsModel);
        }

        // DELETE: api/Sms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTwilioSmsModel([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var twilioSmsModel = await _context.TwilioSmsModels.FindAsync(id);
            if (twilioSmsModel == null)
            {
                return NotFound();
            }

            _context.TwilioSmsModels.Remove(twilioSmsModel);
            await _context.SaveChangesAsync();

            return Ok(twilioSmsModel);
        }

        private bool TwilioSmsModelExists(string id)
        {
            return _context.TwilioSmsModels.Any(e => e.SmsSid == id);
        }
    }
}