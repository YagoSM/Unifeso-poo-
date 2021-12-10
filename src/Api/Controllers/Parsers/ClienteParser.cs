using unifesopoo.Api.Core.Application.ClienteAgg.Parsers;
using unifesopoo.Api.Core.Application.ClienteAgg.Contracts;
using unifesopoo.Api.Controllers.Contracts;
using unifesopoo.Api.Core.Domain.ClienteAgg.Entities;

namespace unifesopoo.Api.Core.Application.ClienteAgg.Parsers{

public class ClienteReportParser : IParser<Cliente,ICliente>
{
    public IClienteView Parse(Cliente cliente)
    {
        return new ClienteDto
        {
            Nome        = cliente.Nome,
            Cpf         = cliente.Cpf,
            NumeroConta = cliente.NumeroConta,
            Status      = cliente.Status
        };
    }
}
}