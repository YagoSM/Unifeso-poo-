using unifesopoo.Api.Core.Application.ClienteAgg.Contracts;
using unifesopoo.Api.Core.Domain.ClienteAgg.Entities;

namespace unifesopoo.Api.Core.Application.ClienteAgg.Parsers;

public interface IParser<Tfrom,TTo>
{
    TTo Parse(Tfrom from);
}

public interface IClienteParseFactory
{
    IParser<Cliente,IClienteView> GetClienteParse();
    IParser<Cliente,IClienteView> GetClienteReportParse();
}