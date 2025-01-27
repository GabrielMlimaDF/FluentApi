using FluentMappingApi.Data;
using FluentMappingApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FluentMappingApi.Controllers
{
    [ApiController]
    public class TipoController : ControllerBase
    {
        private readonly ContextApp _contextApp;

        public TipoController(ContextApp contextApp)
        {
            _contextApp = contextApp;
        }

        [HttpGet("/v1/tipos")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var tipos = await _contextApp.Tipos.ToListAsync();
                return Ok(tipos);
            }
            catch (Exception)
            {

                return StatusCode(500, "Códido de erro: 02X01 - Erro ao buscar tipos!");
            }

        }
        [HttpGet("/v1/tipos/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                var tipo = await _contextApp.Tipos.FirstOrDefaultAsync(x => x.Id == id);
                if (tipo == null)
                    return NotFound();
                return Ok(tipo);
            }
            catch (Exception)
            {

                return StatusCode(500, "Códido de erro: 02X02 - Erro ao buscar tipos pelo Id!");
            }

        }
        [HttpPost("/v1/tipos")]
        public async Task<IActionResult> PostAsync([FromBody] Tipo model)
        {
            try
            {
                await _contextApp.Tipos.AddAsync(model);
                await _contextApp.SaveChangesAsync();
                return Created($"v1/tipos/{model.Id}", model);
            }
            catch (Exception)
            {
                return StatusCode(500, "Códido de erro: 02X03 - Erro ao salvar tipos!");
            }

        }
        [HttpPut("/v1/tipos/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] Tipo model)
        {
            try
            {

                var tipo = await _contextApp.Tipos.FirstOrDefaultAsync(x => x.Id == id);
                if (tipo! == null)
                    return NotFound();
                tipo.Descricao = model.Descricao;
                _contextApp.Tipos.Update(tipo);
                await _contextApp.SaveChangesAsync();
                return Ok(tipo);
            }
            catch (Exception)
            {

                return StatusCode(500, "Códido de erro: 02X04 - Erro ao editar tipos!");
            }

        }
        [HttpDelete("/v1/tipos/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var tipo = await _contextApp.Tipos.FirstOrDefaultAsync(x => x.Id == id);
                if (tipo == null)
                    return NotFound();
                _contextApp.Tipos.Remove(tipo);
                await _contextApp.SaveChangesAsync();
                return Ok(tipo);
            }
            catch (Exception)
            {

                return StatusCode(500, "Códido de erro: 02X05 - Erro ao tentar excluir tipos!");
            }

        }


    }
}
