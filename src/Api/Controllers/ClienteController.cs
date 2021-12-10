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
           return cliente.AsResponse(HttpStatusCode.Created);
       }
       [HttpGet]
       public IActionResult Querry(string nome)
       {
           var clientes = _appService.ChecarNome(nome);
           return cliente.AsResponse(HttpStatusCode.OK);
       }

        [HttpGet("{id}")]
        public IActionResult GetByCPF(int cpf)
        {
            var cliente = _appService.ObterPeloCpf(cpf);
            return cliente.AsResponse(HttpStatusCode.OK);
        }
       
       [HttpPut("{id}")]
        public IActionResult Atualizar(int cpf, AtualizarClienteDto atualizarCliente)
        {
            var cliente = _appService.Atualizar(cpf, atualizarCliente);
            return cliente.AsResponse(HttpStatusCode.OK);
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int cpf)
        {
            _appService.Deletar(cpf);
            return NoContent();
        }
       
    }
}
