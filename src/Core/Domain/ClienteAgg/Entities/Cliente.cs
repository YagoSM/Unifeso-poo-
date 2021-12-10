namespace unifesopoo.Api.Core.Domain.ClienteAgg.Entities{

    public class Cliente
    {
       
       private Cliente(){}
       
        private string nome;
        private int cpf;
        private int numeroConta;

        public Cliente(string nome, int cpf, int numeroConta) : this()
        {
            nome = nome;
            cpf = cpf;
            numeroConta = numeroConta;
        }

        public string Nome {get; private set;}
        public int Cpf {get; private set;}
        public int Preco {get; private set;}


    }

    



}