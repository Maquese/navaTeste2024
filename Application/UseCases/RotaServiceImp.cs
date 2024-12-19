using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.DijkstraAlgoritimo;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class RotaServiceImp : RotaService
    {
        private readonly RotaRepository _rotaRepository;
        private readonly IMapper _mapper;

        public RotaServiceImp(RotaRepository rotaRepository, IMapper mapper)
        {
            _rotaRepository = rotaRepository;
            _mapper = mapper;
        }

        public  async Task<RotaModel> Adicionar(RotaModel rotaModel)
        {
            if (rotaModel == null)
                throw new ArgumentException("A rota deve ser cadastrada corretamente");

            if (String.IsNullOrEmpty(rotaModel.Origem))
                throw new ArgumentException("Origem deve ser preenchida");


            if (String.IsNullOrEmpty(rotaModel.Destino))
                throw new ArgumentException("Destino deve ser preenchida");


            if (rotaModel.Valor == 0)
                throw new ArgumentException("Valor deve ser maior que 0");


            if (rotaModel.Origem == rotaModel.Destino)
                throw new ArgumentOutOfRangeException("Origem e Destino n podem ser os mesmos");

            Rota rota = new Rota(rotaModel.Origem, rotaModel.Destino, rotaModel.Valor);

            await _rotaRepository.Add(rota);

            rotaModel.Id = rota.Id;

            return rotaModel;
        }

        public async Task<RotaModel> CalcularRotaMaisBarata(string origem, string destino)
        {
            var lista = await _rotaRepository.List();

            return new RotaModel(origem,destino,Grafo.Calcular(lista, origem, destino));
        }

        public async Task Deletar(int id)
        {
            var rota = await _rotaRepository.Read(id);
            if (rota == null)
                throw new ArgumentException($"Rota não identificada com id {id} para remover");
            await _rotaRepository.Delete(rota);
        }

        public async Task<RotaModel> Encontrar(int id)
        {
            Rota rota = await _rotaRepository.Read(id);

            return _mapper.Map<RotaModel>(rota);
        }

        public async Task<List<RotaModel>> ListarTudo()
        {
            return _mapper.Map<List<RotaModel>>( await _rotaRepository.List());
        }

        public async Task Update(RotaModel rotaModel)
        {
            if (rotaModel == null)
                throw new ArgumentException("A rota deve ser cadastrada corretamente");

            if (String.IsNullOrEmpty(rotaModel.Origem))
                throw new ArgumentException("Origem deve ser preenchida");


            if (String.IsNullOrEmpty(rotaModel.Destino))
                throw new ArgumentException("Destino deve ser preenchida");


            if (rotaModel.Valor == 0)
                throw new ArgumentException("Valor deve ser maior que 0");


            if (rotaModel.Origem == rotaModel.Destino)
                throw new ArgumentOutOfRangeException("Origem e Destino n podem ser os mesmos");

            var rota = await _rotaRepository.Read(rotaModel.Id);
            if (rota == null)
                throw new ArgumentException($"Rota não identificada com id {rotaModel.Id} para atualizar");

            rota.AtualizarRota(rotaModel.Origem, rotaModel.Destino, rotaModel.Valor);            

            await _rotaRepository.Update(rota);

        }
    }
}
