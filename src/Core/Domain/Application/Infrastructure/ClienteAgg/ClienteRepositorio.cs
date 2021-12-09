using unifesopoo.Api.Core.Domain.ClienteAgg.Repositories;

namespace unifesopoo.Api.Core.Infrastructure.ClienteAgg.Repositories{

    public class ClienteRepositorio : IClienteRepositorio
    {
        private  List<Cliente> _cliente = new List<Cliente>();
        public void Adicionar(Cliente cliente)
        {
            _cliente.Add(cliente);
        }
        public ICollection<Cliente> ChecarNome(string nome)
        {
            throw new System.NotImplementedException();
        }
        public ICollection<Cliente> ChecarNome(string nome)
        {
            return _clientes.Where(cliente => cliente.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase));
        }

    }





}