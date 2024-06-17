using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Sales.API.Data;
using Sales.Shared.Entities;

namespace Sales.API.Controllers
{

    [ApiController]
    [Route("api/countries")] 
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;


        public CountriesController(DataContext context)
        {
            
            this._context = context;
            
        }
        //Método Post
        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country)
        {
            _context.Countries.Add(country);

            await _context.SaveChangesAsync();
            return Ok(country);
        }
        //Método Get
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        //Método Get por Id
        [HttpGet("id:int") ]
        public async Task<ActionResult> GetAsync(int id)
        {
            var country =await _context.Countries.FirstOrDefaultAsync(x => x.Id == id );

            if(country == null)
            {
                return NotFound();
            }           

            return Ok(country);
        }

        //Método PUT
        [HttpPut]
        public async Task<ActionResult> PutAsync(Country country)
        {
            _context.Countries.Update(country);

            await _context.SaveChangesAsync();
            return Ok(country);
        }

        //Método Delete
        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);

            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();


           return NoContent();
        }


    }
}
