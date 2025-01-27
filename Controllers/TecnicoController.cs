using FluentMappingApi.Models.ViewModels;
using FluentMappingApi.Models;
using Microsoft.AspNetCore.Mvc;
using FluentMappingApi.Data;
using Microsoft.EntityFrameworkCore;

namespace FluentMappingApi.Controllers
{
    public class TecnicoController : ControllerBase
    {
        private readonly ContextApp _contextApp;

        public TecnicoController(ContextApp contextApp)
        {
            _contextApp = contextApp;
        }

        [HttpGet("/v1/tecnicos")]
        public async Task<ActionResult> GetAsync()
        {
            try
            {
                var tecnicos = await _contextApp.Tecnicos.ToListAsync();
                if (tecnicos == null)
                    return NotFound();
                return Ok(tecnicos);
            }
            catch (Exception)
            {

                return StatusCode(500, "Códido de erro: 03X01 - Erro ao tentar buscar os dados!");
            }
        }

        [HttpGet("/v1/tecnicos/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                var tecnicos = await _contextApp.Tecnicos.FirstOrDefaultAsync(x => x.Id == id);
                if (tecnicos == null)
                    return NotFound();
                return Ok(tecnicos);
            }
            catch (Exception)
            {

                return StatusCode(500, "Códido de erro: 03X02 - Erro ao tentar buscar os dados pelo Id informado!");
            }
        }

        [HttpPost("/v1/tecnicos")]
        public async Task<IActionResult> PostAsync([FromBody] Tecnico tecnicos)
        {
            try
            {
                await _contextApp.Tecnicos.AddAsync(tecnicos);
                await _contextApp.SaveChangesAsync();
                return Created($"v1/tecnicos/{tecnicos.Id}", tecnicos);
            }
            catch (Exception)
            {


                return StatusCode(500, "Códido de erro: 03X03 - Erro ao tentar salvar!");
            }
        }

        [HttpPut("/v1/tecnicos/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] EditoTecnicoViewModel model)
        {
            try
            {
                var tecnicos = await _contextApp.Tecnicos.FirstOrDefaultAsync(x => x.Id == id);
                if (tecnicos == null)
                    return NotFound();
                tecnicos.Nome = model.Nome;
                tecnicos.Email = model.Email;
                tecnicos.Telefone = model.Telefone;
                tecnicos.StatusAtivoInativoId = model.StatusAtivoInativoId;
                _contextApp.Tecnicos.Update(tecnicos);
                await _contextApp.SaveChangesAsync();
                return Ok(tecnicos);
            }
            catch (Exception)
            {

                return StatusCode(500, "Códido de erro: 03X04 - Erro ao tentar atualizar!");
            }
        }

        [HttpDelete("/v1/tecnicos/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var tecnicos = await _contextApp.Tecnicos.FirstOrDefaultAsync(x => x.Id == id);
                if (tecnicos == null)
                    return NotFound();
                _contextApp.Tecnicos.Remove(tecnicos);
                await _contextApp.SaveChangesAsync();

                return Ok(tecnicos);
            }
            catch (Exception)
            {

                return StatusCode(500, "Códido de erro: 01X05 - Erro ao tentar deletar");
            }
        }

    }
}
