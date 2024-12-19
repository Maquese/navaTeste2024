using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class RotaModel
    {
        public RotaModel(int id, string origem, string destino, uint valor)
        {
            Id = id;
            Origem = origem;
            Destino = destino;
            Valor = valor;
        }

        public RotaModel()
        {
            
        }

        public RotaModel( string origem, string destino, uint valor)
        {
            Origem = origem;
            Destino = destino;
            Valor = valor;
        }

        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public uint Valor { get; set; }
    }
}
