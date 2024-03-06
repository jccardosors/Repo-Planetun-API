using ProjPlantunTest.Models;

namespace ProjPlantunTest.Controllers.Outputs
{
    public class TabuadaResponse
    {
        public IEnumerable<Tabuada> TabuadaLista { get; set; } = new List<Tabuada>();
    }
}
