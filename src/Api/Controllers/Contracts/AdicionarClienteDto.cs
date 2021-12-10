using unifesopoo.Api.Core.Application.ClienteAgg.Contracts;


namespace unifesopoo.Api.Controllers.Contracts{
    public class AdicionarCliente : IAdicionarCliente
    {
        public string Nome{get;set;}
        public int Cpf{get;set;}
        public int NumeroConta{get;set;}
    }
}