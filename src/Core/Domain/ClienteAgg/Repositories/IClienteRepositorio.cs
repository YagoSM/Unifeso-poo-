namespace unifesopoo.Api.Core.Domain.ClienteAgg.Repositories{

    public class Cliente{
        public interface IClienteRepositorio
        {
            void Adicionar(Cliente cliente); 
            ICollection<Cliente> ChecarNome(string nome);
        }
    }





}