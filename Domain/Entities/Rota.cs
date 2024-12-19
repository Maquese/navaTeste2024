namespace Domain.Entities;

public class Rota : EntityBase
{
    public Rota(string origem, string destino, uint valor)
    {
        if (String.IsNullOrEmpty(origem))
            throw new ArgumentException("Origem deve ser preenchida");


        if (String.IsNullOrEmpty(destino))
            throw new ArgumentException("Destino deve ser preenchida");


        if (valor == 0)
            throw new ArgumentException("Valor deve ser maior que 0");


        if (origem == destino)
            throw new ArgumentOutOfRangeException("Origem e Destino n podem ser os mesmos");

        Origem = origem.Trim();
        Destino = destino.Trim();
        Valor = valor;
    }

    public string Origem { get; set; }
    public string Destino { get; set; }
    public uint Valor { get; set; }

    public void AtualizarRota(string origem, string destino, uint valor)
    {
        if (String.IsNullOrEmpty(origem))
            throw new ArgumentException("Origem deve ser preenchida");


        if (String.IsNullOrEmpty(destino))
            throw new ArgumentException("Destino deve ser preenchida");


        if (valor == 0)
            throw new ArgumentException("Valor deve ser maior que 0");


        if (origem == destino)
            throw new ArgumentOutOfRangeException("Origem e Destino n podem ser os mesmos");

        Origem = origem.Trim();
        Destino = destino.Trim();
        Valor = valor;
    }
}
