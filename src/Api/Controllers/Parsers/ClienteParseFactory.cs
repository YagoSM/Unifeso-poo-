using unifesopoo.Api.Core.Application.ClienteAgg.Contracts;
using unifesopoo.Api.Core.Application.ClienteAgg.Parsers;
using unifesopoo.Api.Core.Domain.ClienteAgg.Entities;



namespace unifesopoo.Api.Controllers.Parsers
{
    public class ClienteParseFactory : IClienteParseFactory
    {
        public IParser<Cliente,IClienteView> GetClienteParse()
        {
            return new ClienteParser();
        }

        public IParser<ClienteParseFactory IClienteView> GetClienteReportParse()
        {
            return new ClienteReportParser();
        }
    }
}

