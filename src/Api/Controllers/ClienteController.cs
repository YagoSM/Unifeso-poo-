using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using unifesopoo.Api.Core.Application.ClienteAgg.AppServices;
using unifesopoo.Api.Controllers.Contracts;



namespace Av2.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
       private readonly ClienteAppService _appService;

       public ClienteController()
       {
           _appService = appService;
       }
       
       
       [HttpPost]
       public IActionResult Add(AdicionarClienteDto adicionarClienteDto)
       {
           var cliente =_appService.Adicionar(adicionarClienteDto);
           return Created(Request.Path, cliente);
       }
       [HttpGet]
       public IActionResult Querry(string nome)
       {
           var clientes = _appService.ChecarNome(nome);
           return Ok(clientes);
       }

       

       
    }
}
