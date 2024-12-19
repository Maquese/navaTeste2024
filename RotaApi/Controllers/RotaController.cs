using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RotaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotaController : ControllerBase
    {

        [HttpPost("Adicionar")]
        public async Task<IActionResult> Add([FromServices] RotaService rotaService, [FromBody] RotaModel rotaModel)
        {
            try
            {
                await rotaService.Adicionar(rotaModel);
                return Ok(rotaModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost("Atualizar")]
        public async Task<IActionResult> Atualizar([FromServices] RotaService rotaService, [FromBody] RotaModel rotaModel)
        {
            try
            {
                await rotaService.Update(rotaModel);
                return Ok(rotaModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarTudo")]
        public async Task<IActionResult> ListarTudo([FromServices] RotaService rotaService)
        {
            try
            {
                return Ok(await rotaService.ListarTudo());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Encontrar")]
        public async Task<IActionResult> Encontrar([FromServices] RotaService rotaService, [FromQuery] int id)
        {
            try
            {
                RotaModel rota = await rotaService.Encontrar(id);

                if (rota != null)
                    return Ok(rota);
                else
                    return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Remover")]
        public async Task<IActionResult> Remover([FromServices] RotaService rotaService, [FromQuery] int id)
        {
            try
            {
                await rotaService.Deletar(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("CalcularRota")]
        public async Task<IActionResult> CalcularRota([FromServices] RotaService rotaService, [FromQuery] string origem, string destino)
        {
            try
            {
                return Ok(await rotaService.CalcularRotaMaisBarata(origem, destino));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
