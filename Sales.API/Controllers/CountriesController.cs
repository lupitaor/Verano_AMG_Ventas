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
            try 
            {

                _context.Countries.Add(country);

                await _context.SaveChangesAsync();
                return Ok(country);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un país con el mismo nombre");
                }
                return BadRequest("Ya existe un país con el mismo nombre");
               // return BadRequest(dbUpdateException.Message);

            }
            catch(Exception exception)
            {
                return BadRequest(exception.Message);

            }
        }


        //Método Get
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        //Método Get por Id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
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
            try
            {

                _context.Countries.Update(country);

                await _context.SaveChangesAsync();
                return Ok(country);

            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un país con el mismo nombre");
                }
                return BadRequest("Ya existe un país con el mismo nombre");
                // return BadRequest(dbUpdateException.Message);

            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);

            }
        }

        //Método Delete por Id
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
