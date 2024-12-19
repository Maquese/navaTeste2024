namespace Domain.Entities;

public class Rota : EntityBase
{
    public Rota(string origem, string destino, uint valor)
    {
        Origem = origem;
        Destino = destino;
        Valor = valor;
    }

    public string Origem { get; set; }
    public string Destino { get; set; }
    public uint Valor { get; set; }

    public void AtualizarRota(string origem, string destino, uint valor)
    {
        Origem = origem;
        Destino = destino;
        Valor = valor;
    }
}
