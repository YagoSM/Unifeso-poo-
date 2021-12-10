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

            return clientes.Select(_parseFactory.GetClienteReportParse().Parse).ToImmutableList();
        }

        public IClienteView ObterPeloCPF(int cpf)
        {
            var cliente = _repositorio.ObterPeloCPF(cpf);

            if (cliente == null)
            {
                throw new NotFoundException(nameof(cliente), cpf);
            }
            
            return _parseFactory.GetClienteParse().Parse(cliente);
        }

        public IClienteView Atualizar(int cpf, AtualizarClienteDto atualizarCliente)
        {
            var cliente = _repositorio.ObterPeloCPF(cpf);
            cliente.Atualizar(atualizarCliente);
            _unitOfWork.SaveChanges();
            return _parseFactory.GetClienteParse().Parse(cliente);
        }

        public void Deletar(int cpf)
        {
            var produto = _repositorio.ObterPeloCPF(cpf);
            produto.Deletar();
            _unitOfWork.SaveChanges();
        }
    }
