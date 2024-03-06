using ProjPlantunTest.Models;

namespace ProjPlantunTest.Util
{
    public class ArquivoUtil
    {
        private readonly IWebHostEnvironment _env;

        public ArquivoUtil(IWebHostEnvironment webHostEnvironment)
        {
            _env = webHostEnvironment;
        }

        public static async Task<bool> GravarArquivo(List<Tabuada> tabuadas, string caminhoRaiz)
        {
            try
            {
                if (File.Exists(caminhoRaiz))
                {
                    File.Delete(caminhoRaiz);
                }

                string text = "Tabuada de Multiplicação" + Environment.NewLine;
                string docPath = caminhoRaiz;

                File.WriteAllText(docPath, text);

                List<string> tabuadaCompleta = new List<string>();

                tabuadas = tabuadas.OrderBy(p => p.TabNumero).ToList();
                int tabNumero = -1;

                foreach (var line in tabuadas)
                {
                    if (tabNumero != line.TabNumero)
                    {
                        tabNumero = line.TabNumero;
                        tabuadaCompleta.Add($"{Environment.NewLine}Tabuada do número: {tabNumero}");
                    }

                    tabuadaCompleta.Add($"{line.TabNumero} X {line.Numero} = {line.Resultado}");
                }

                File.AppendAllLines(docPath, tabuadaCompleta);

            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
