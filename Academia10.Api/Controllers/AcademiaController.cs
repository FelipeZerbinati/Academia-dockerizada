using Academia10.Domain.Interfaces.Services;
using Academia10.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academia10.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcademiaController : ControllerBase
    {
        private readonly IAcademiaService _academiaService;

        public AcademiaController(IAcademiaService academiaService)
        {
            _academiaService = academiaService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAcademia(Academia newAcademia)
        {
            if (newAcademia == null)
            {
                return BadRequest();
            }
            var result = await _academiaService.CreateAcademia(newAcademia);
            if (!result.Success)
            {
                return BadRequest(result.ErrorDescription);
            }
            return Ok(result.Data);
        }

        [HttpGet("{page}/{perPage}")]
        public async Task<IActionResult> GetAcademias(int page, int perPage)
        {
            var result = await _academiaService.GetAcademias(page, perPage);
            if (!result.Success)
            {
                return NotFound();
            }
            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAcademiaById(Guid id)
        {
            var result = await _academiaService.GetAcademiaById(id);
            if (!result.Success)
            {
                return NotFound();
            }

            return Ok(result.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAcademia(Guid id, Academia updatedAcademia)
        {
            var result = await _academiaService.UpdateAcademia(id, updatedAcademia);
            if (id != updatedAcademia.Id)
            {
                return BadRequest("Academia id incompatível");
            }
            if (!result.Success)
            {
                return BadRequest(result.ErrorDescription);
            }
            return Ok(result.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademia(Guid id)
        {
            var result = await _academiaService.DeleteAcademia(id);
            if(!result.Success)
            {
                return NotFound();
            }

            result.Success = true;
            result.Data = true;
            return Accepted();
        }
    }
}
