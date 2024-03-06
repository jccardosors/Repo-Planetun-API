using Microsoft.AspNetCore.Mvc;
using ProjPlantunTest.Controllers.Inputs;
using ProjPlantunTest.Controllers.Outputs;
using ProjPlantunTest.Services.Interfaces;

namespace ProjPlantunTest.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TabuadaController : ControllerBase
    {
        private readonly ITabuadaService _tabuadaService;
        public TabuadaController(ITabuadaService tabuadaService)
        {
            _tabuadaService = tabuadaService;
        }

        [HttpPost(Name = "CalcularTabuada")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(TabuadaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CalcularTabuada(TabuadaRequest tabuadaRequest)
        {
            var resposta = await _tabuadaService.CalcularTabuada(tabuadaRequest);

            if (!resposta.StatusOk)
            {
                return BadRequest(resposta);
            }

            return Ok(resposta.Result);

        }
    }
}
