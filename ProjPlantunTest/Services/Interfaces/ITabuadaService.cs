using ProjPlantunTest.Controllers.Inputs;
using ProjPlantunTest.Controllers.Outputs;

namespace ProjPlantunTest.Services.Interfaces
{
    public interface ITabuadaService
    {
        Task<ServiceResponse<TabuadaResponse>> CalcularTabuada(TabuadaRequest tabuadaRequest);
    }
}
