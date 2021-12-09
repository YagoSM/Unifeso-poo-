using unifesopoo.Api.Core.Domain.ClienteAgg.Repositories;

namespace unifesopoo.Api.Core.Infrastructure.ClienteAgg.Repositories{

    public class ClienteRepositorio : IClienteRepositorio
    {
        private static list<Cliente> _cliente = new list<Cliente>();
        public void Adicionar(Cliente cliente)
        {
            _cliente.Add(cliente);
        }
        public ICollection<Cliente> ChecarNome(string nome)
        {
            throw new System.NotImplementedException();
        }


    }





}