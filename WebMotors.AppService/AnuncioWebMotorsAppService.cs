using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.AppService.Interface;
using WebMotors.AppService.ViewModel;
using WebMotors.Domain;
using WebMotors.Domain.Repository;

namespace WebMotors.AppService
{
    public class AnuncioWebMotorsAppService : IAnuncioWebMotorsAppService
    {
        private readonly IAnuncioWebMotorsRepository _repository;
        private readonly IMapper _map;
        public AnuncioWebMotorsAppService(IAnuncioWebMotorsRepository repository, 
            IMapper map)
        {
            _repository = repository;
            _map = map;
        }
        public async Task AddAnuncio(AnuncioWebMotorsViewModel anuncio)
        {
            await _repository.Salvar(_map.Map<AnuncioWebMotors>(anuncio));
        }

        public async Task ApagarAnuncio(int id)
        {
            await _repository.Apagar(id);
        }

        public async Task AtualizarAnuncio(AnuncioWebMotorsViewModel anuncio)
        {
            await _repository.Atualizar(_map.Map<AnuncioWebMotors>(anuncio));
        }

        public async Task<List<AnuncioWebMotorsViewModel>> GetAllAnuncios()
        {
            return  _map.Map<List<AnuncioWebMotorsViewModel>>(await _repository.GetAll());
        }
    }
}
