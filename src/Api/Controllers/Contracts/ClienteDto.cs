namespace unifesopoo.Api.Controllers.Contracts{
public class ClienteDto: IClienteView
{
    public string Nome {get;set;}
    public int Cpf {get;set;}
    public int NumeroConta {get;set;}
    public string Status {get;set;}
}

}