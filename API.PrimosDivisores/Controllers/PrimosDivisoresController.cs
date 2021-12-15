using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.PrimosDivisores.Estruturas;

namespace API.PrimosDivisores.Controllers
{
    [ApiController]
    [Route("PrimosDivisores")]
    public class PrimosDivisoresController : ControllerBase
    {

        private readonly ILogger<PrimosDivisoresController> _logger;

        public PrimosDivisoresController(ILogger<PrimosDivisoresController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int numeroEntrada)
        {
            List<int> aux = new List<int>();
            List<int> aux2 = new List<int>();
            SaidaPrimosDivisores saida = new SaidaPrimosDivisores();

            saida.Entrada = numeroEntrada;

            for (int i = numeroEntrada; i > 0; i--)
            {
                bool primo = true;
                for (int j = i-1; j > 1; j--)
                {
                    if (i % j == 0)
                    {
                        primo = false;
                    }
                }
                if (primo && numeroEntrada % i == 0)
                {
                    aux2.Add(i);
                }
                if (numeroEntrada % i == 0)
                {
                    aux.Add(i);
                }
            }
            saida.Divisores = aux.OrderBy(x => x).ToArray();
            saida.DivisoresPrimos = aux2.OrderBy(x => x).ToArray();

            return Ok(saida);
        }
    }
}
