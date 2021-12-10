using unifesopoo.Api.Core.Application.ClienteAgg.AppServices;
using unifesopoo.Api.Core.Domain.ClienteAgg.Entities;
using unifesopoo.Api.Core.Domain.ClienteAgg.Repositories;

    public class ClienteAppService
    {
        private readonly IClienteRepositorio _repositorio;
        private readonly IParseFactory _parseFactory;
        
        private readonly IUnitOfWork _unitOfWork;

        public ClienteAppService(IClienteRepositorio repositorio,IClienteParseFactory parseFactory,IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _parseFactory = parseFactory;
            _unitOfWork = unitOfWork;
        }
        public IClienteView Adicionar(IAdicionarCliente adicionarCliente)
        {
            var cliente = new Client(adicionarCliente.Nome,adicionarCliente.Cpf,adicionarCliente.NumeroConta);
            _repositorio.Adicionar(cliente);
            _unitOfWork.SaveChanges();
            return _parseFactory.GetClienteParse().Parse(cliente);
        }

        public ICollection<IClienteView> ChecarNome(string nome)
        {
            var clientes = _repositorio.ChecarNome(nome);
            
            /*var clientes =  _repositorio.ChecarNome(nome);
            var result = new List<IprodutoView>();
            for (int i=0; i < clientes.Count; i++)
            {
                var cliente = cliente.ElementAt(i);
                var dto = _parser.Parse(Cliente);
                result.Add(dto);
            }
            return result;
            */
            return clientes.Select(_parseFactory.GetClienteReportParse().Parse).ToImmutableList();
        }
    }
