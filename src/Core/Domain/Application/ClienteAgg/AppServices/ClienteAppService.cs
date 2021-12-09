using unifesopoo.Api.Core.Application.ClienteAgg.AppServices;

    public class ClienteAppService
    {
        private readonly IClienteRepositorio _repositorio;
        public ClienteAppService(IClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public void Adicionar(AdicionarCliente adicionarCliente)
        {
            var cliente = new Client(adicionarCliente.Nome,adicionarCliente.Cpf,adicionarCliente.NumeroConta);
            _repositorio.Adicionar(cliente);
            return cliente;
        }

        public ICollection<Cliente> ChecarNome(string nome)
        {
            return _repositorio.ChecarNome(nome);
        }
    }
