using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API2.Controller
{
    [Route("api/Imovel")]
    [ApiController]
    public class ImovelController : ControllerBase
    {

        // GET: ImovelController/Details/5
        [HttpGet]
        public IActionResult Details(double metrosQuadrados)
        {

            if (metrosQuadrados < 10 || metrosQuadrados > 10000)
            {
                return BadRequest("A quantidade de metros quadrados deve estar entre 10 e 10.000");               
            }
            else
            {
                using (HttpClient httpClient = new HttpClient() { BaseAddress = new Uri("https://api1-gmanzini.herokuapp.com/") })
                {
                    double result = double.Parse(httpClient.GetAsync("api/PrecificacaoController").Result.Content.ReadAsStringAsync().Result, CultureInfo.InvariantCulture);
                    return Ok(result * metrosQuadrados);
                }
            }
        }

    
    }
}
