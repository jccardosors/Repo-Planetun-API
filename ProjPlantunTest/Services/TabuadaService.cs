using ProjPlantunTest.Controllers.Inputs;
using ProjPlantunTest.Controllers.Outputs;
using ProjPlantunTest.Models;
using ProjPlantunTest.Services.Interfaces;
using ProjPlantunTest.Util;

namespace ProjPlantunTest.Services
{
    public class TabuadaService : ITabuadaService
    {
        private readonly IWebHostEnvironment _env;

        public TabuadaService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<ServiceResponse<TabuadaResponse>> CalcularTabuada(TabuadaRequest tabuadaRequest)
        {
            var response = new ServiceResponse<TabuadaResponse>()
            {
                HttpStatusCode = System.Net.HttpStatusCode.OK,
                Result = new TabuadaResponse() { },
                StatusOk = true
            };

            var tabuadaResultado = new TabuadaResponse();
            try
            {
                var tabuadalista = new List<Tabuada>();
                foreach (var item in tabuadaRequest.NumerosLista)
                {
                    int indice = 0;
                    while (indice < 10)
                    {
                        indice++;
                        tabuadalista.Add(new Tabuada { Numero = indice, TabNumero = item, Resultado = indice * item });
                    }
                }
                tabuadaResultado.TabuadaLista = tabuadalista;
                response.Result = tabuadaResultado;

                string caminho = Path.Combine(@$"{_env.ContentRootPath}\Arquivos\tabuada_de_n.txt");
                await ArquivoUtil.GravarArquivo(tabuadaResultado.TabuadaLista.ToList(), caminho);
            }
            catch (Exception ex)
            {
                response.StatusOk = false;
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.Result = null;
                response.ErrorCode = System.Net.HttpStatusCode.InternalServerError.ToString();
                response.ErrorMessages.Add(ex.GetBaseException().Message);

                return response;
            }

            return response;
        }
    }
}
