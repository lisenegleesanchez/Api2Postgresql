using Api2Postgresql.Models;
using Api2Postgresql.Repository;
using Microsoft.AspNetCore.Mvc;


// controlador manual
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api2Postgresql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutosController (AutosInterface autosInterface) : ControllerBase
    {
        // GET: api/<AutosController>
        [HttpGet("get")]
        // read all
        public async Task <IActionResult> GetAutos()
        {
            var autos = await autosInterface.GetAllAsync();
            if(!autos.Any())
                return NotFound();
            else
                return Ok(autos);          

        }

        // GET api/<AutosController>/5
        [HttpGet("get-single{id:int}")]
        // read single
        public async Task<IActionResult> GetAutos(int id)
        {
            var autos = await autosInterface.GetByAsync(id);
            if (autos is null)
                return NotFound();
            else
                return Ok(autos);
        }

        // POST api/<AutosController>
        [HttpPost("add")]
        // create
        public async Task <IActionResult> Create(Autos autos)
        {
            var result = await autosInterface.CreateAsync(autos);
            if (result)
            return CreatedAtAction(nameof(Create), new { id = autos.Id }, autos);
            else
            return BadRequest();

        }

        // PUT api/<AutosController>/5
        [HttpPut("update")]
        //actualizar
        public async Task<IActionResult> UpdateAsync(Autos autos)
        {
            var result = await autosInterface.UpdateAsync(autos);
            if (result)
                return Ok();
            else
                return NotFound();

        }

        // DELETE api/<AutosController>/5
        [HttpDelete("delete /{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await autosInterface.DeleteAsync(id);
            if(result)
                return NoContent();
            else
                return NotFound();
        }
    }
}
