using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using therapist_api;
using therapist_api.Models;
using Newtonsoft.Json;

namespace dotnet_sdg_template.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TherapistController : ControllerBase
  {
    private readonly DatabaseContext _context;

    public TherapistController(DatabaseContext context)
    {
      _context = context;
    }

    // GET: api/Therapist
    [HttpGet]
    public async Task<ActionResult<IEnumerable<therapist>>> GetTherapists()
    {
      return await _context.Therapists.ToListAsync();
    }

    // GET: api/Therapist/5
    [HttpGet("{id}")]
    public async Task<ActionResult<therapist>> Gettherapist(int id)
    {
      var therapist = await _context.Therapists.FindAsync(id);

      if (therapist == null)
      {
        return NotFound();
      }

      return therapist;
    }
    // [HttpGet("therapist/{state}")]
    // public async Task<ActionResult<List<therapist>>> GetTherapistByState([FromRoute]string state)
    // {
    //   var therapistsInState = await _context.Therapists.Where(w => w.State == state).ToListAsync();

    //   if (therapistsInState == null)
    //   {
    //     return NotFound();
    //   }

    //   return therapistsInState;
    // }
    public class DataList
    {
      public string Code { get; set; }
      public string City { get; set; }
      public string State { get; set; }
      public double Latitude { get; set; }
      public double Longitude { get; set; }
      public string County { get; set; }
      public double? Distance { get; set; }
    }

    public class ZipCodeResponses
    {
      public List<DataList> DataList { get; set; }
    }

    [HttpGet("search/{zipCode}")]
    public async Task<ActionResult<List<therapist>>> GetTherapistByCode([FromRoute]string zipCode)
    {
      var zipCodes = new List<string>();
      var API_KEY = "8XGDVIDXM9HTGHVM64W7";
      var API = $"https://api.zip-codes.com/ZipCodesAPI.svc/1.0/FindZipCodesInRadius?zipcode={zipCode}&minimumradius=0&maximumradius=50&key={API_KEY}";

      // ... Use HttpClient.
      using (HttpClient client = new HttpClient())
      using (HttpResponseMessage response = await client.GetAsync(API))
      using (HttpContent content = response.Content)
      {
        // ... Read the string.
        string result = await content.ReadAsStringAsync();
        var results = JsonConvert.DeserializeObject<ZipCodeResponses>(result);
        zipCodes = results.DataList.Select(s => s.Code).ToList();
      }
      // searching your context for the Therapist based on the zips from the APi call above
      var therapistsInZip = _context.Therapists.Where(w => zipCodes.Contains(w.PostalCode));
      return await therapistsInZip.ToListAsync();
    }




    // PUT: api/Therapist/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Puttherapist(int id, therapist therapist)
    {
      if (id != therapist.Id)
      {
        return BadRequest();
      }

      _context.Entry(therapist).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!therapistExists(id))
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

    // POST: api/Therapist
    [HttpPost]
    public async Task<ActionResult<therapist>> Posttherapist(therapist therapist)
    {
      _context.Therapists.Add(therapist);
      await _context.SaveChangesAsync();

      return CreatedAtAction("Gettherapist", new { id = therapist.Id }, therapist);
    }

    // DELETE: api/Therapist/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<therapist>> Deletetherapist(int id)
    {
      var therapist = await _context.Therapists.FindAsync(id);
      if (therapist == null)
      {
        return NotFound();
      }

      _context.Therapists.Remove(therapist);
      await _context.SaveChangesAsync();

      return therapist;
    }

    private bool therapistExists(int id)
    {
      return _context.Therapists.Any(e => e.Id == id);
    }
  }
}
