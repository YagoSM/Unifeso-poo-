namespace unifesopoo.Api.Controllers.Contracts{
public class ClienteDto: ICliente
{
    public string Nome {get;set;}
    public int Cpf {get;set;}
    public int NumeroConta {get;set;}
}

}