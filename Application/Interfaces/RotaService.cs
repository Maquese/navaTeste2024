using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface RotaService
    {
        Task<RotaModel> Adicionar(RotaModel rotaModel);

        Task<List<RotaModel>> ListarTudo();

        Task<RotaModel> Encontrar(int id);

        Task Update(RotaModel rotaModel);

        Task Deletar(int id);

        Task<RotaModel> CalcularRotaMaisBarata(string origem, string destino);
    }
}
