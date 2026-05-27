using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tut7.DTOs;
using tut7.Exceptions;
using tut7.Service;

namespace tut7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PCsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public PCsController(IDbService dbService)
        {
            _dbService = dbService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPCs()
        {

            var result = await _dbService.GetAllPCs();
            return Ok(result);
        }


        [HttpGet("{id}/components")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _dbService.GetPC(id);
                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreatePC(CreatePCDTO dto)
        {
            var result = await _dbService.CreatePC(dto);
            return Created("api/pcs", result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePC(UpdatePCDTO dto, [FromRoute]int id)
        {
            try
            {
                await _dbService.UpdatePC(dto, id);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePC([FromRoute] int id)
        {
            try
            {
                await _dbService.DeletePC(id);
                return NoContent();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
