using unifesopoo.Api.Core.Domain.ClienteAgg.Repositories;

namespace unifesopoo.Api.Core.Infrastructure.ClienteAgg.Repositories{

    public class ClienteRepositorio : IClienteRepositorio
    {
        
        public ClienteRepositorio(ClienteDbContext context)
        {
            _context = context;
        }
        
        private  List<Cliente> _cliente = new List<Cliente>();
        public void Adicionar(Cliente cliente)
        {
            _context.Set<Cliente>().Add(Cliente);
        }
        public ICollection<Cliente> ChecarNome(string nome)
        {
            throw new System.NotImplementedException();
        }
        public ICollection<Cliente> ChecarNome(string nome)
        {
            if(string.IsNullOrWhiteSpace(nome)) 
            {
                return _context.Set<Cliente>().ToImmutableList();
            }
            
            return _context.Set<Cliente>().Where(cliente => cliente.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase))
            
                .ToImmutableList();
            
            
        }

    }





}