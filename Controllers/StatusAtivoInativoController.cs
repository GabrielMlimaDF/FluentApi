using FluentMappingApi.Data;
using FluentMappingApi.Models;
using FluentMappingApi.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FluentMappingApi.Controllers
{
    [ApiController]
    public class StatusAtivoInativoController : ControllerBase
    {
        private readonly ContextApp _contextApp;
        public StatusAtivoInativoController(ContextApp contextApp)
        {
            _contextApp = contextApp;
        }

        [HttpGet("v1/statusativoinativo")]
        public async Task<ActionResult> GetAsync()
        {
            try
            {
                var status = await _contextApp.StatusAtivosInativos.ToListAsync();
                if (status == null)
                    return NotFound();
                return Ok(status);
            }
            catch (Exception)
            {

                return StatusCode(500, "Códido de erro: 01X01 - Erro ao tentar buscar os dados!");
            }
        }
        [HttpGet("/v1/statusativoinativo/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
                try
                {
                    var tipo = await _contextApp.StatusAtivosInativos.FirstOrDefaultAsync(x => x.Id == id);
                    if (tipo == null)
                        return NotFound();
                    return Ok(tipo);
                }
                catch (Exception)
                {

                    return StatusCode(500, "Códido de erro: 01X02 - Erro ao tentar buscar os dados pelo Id informado!");
                }

        }
        [HttpPost("/v1/statusativoinativo")]
        public async Task<IActionResult> PostAsync([FromBody] EditoStatusAtivoInativoViewModel model)
        {
            try
            {
                var status = new StatusAtivoInativo();
                status.Descricao = model.Descricao;
                    await _contextApp.StatusAtivosInativos.AddAsync(status);
                await _contextApp.SaveChangesAsync();
                return Created($"v1/statusativoinativo/{status.Id}", status);
            }
            catch (Exception)
            {


                return StatusCode(500, "Códido de erro: 01X03 - Erro ao tentar salvar!");
            }

        }
        [HttpPut("/v1/statusativoinativo/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] EditoStatusAtivoInativoViewModel model)
        {
            try
            {
                var status = await _contextApp.StatusAtivosInativos.FirstOrDefaultAsync(x => x.Id == id);
                if (status == null)
                    return NotFound();
                status.Descricao = model.Descricao;
                _contextApp.StatusAtivosInativos.Update(status);
                await _contextApp.SaveChangesAsync();
                return Ok(status);
            }
            catch (Exception)
            {

                return StatusCode(500, "Códido de erro: 01X04 - Erro ao tentar atualizar!");
            }

        }
        [HttpDelete("/v1/statusativoinativo/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var status = await _contextApp.StatusAtivosInativos.FirstOrDefaultAsync(x => x.Id == id);
                if (status == null)
                    return NotFound();
                _contextApp.StatusAtivosInativos.Remove(status);
                await _contextApp.SaveChangesAsync();

                return Ok(status);
            }
            catch (Exception)
            {

                return StatusCode(500, "Códido de erro: 01X05 - Erro ao tentar deletar");
            }

        }
    }
}
