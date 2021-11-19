
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Domain;
using WebMotors.Domain.Repository;

namespace WebMotors.Infra.DataAccess
{
    public class AnuncioWebMotorsRepository : IAnuncioWebMotorsRepository
    {
        private readonly Conexao _context;
        public readonly DbSet<AnuncioWebMotors> _repository;
        public AnuncioWebMotorsRepository(Conexao context)
        {
            _context = context;
            _repository = _context.Anuncio;
        }
        public async  Task Apagar(int id)
        {
            var obj = await this.GetById(id);
            _repository.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(AnuncioWebMotors objeto)
        {
            _context.Entry(objeto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<AnuncioWebMotors>> GetAll()
        {
            return await _repository.AsNoTracking().ToListAsync();
        }

        public async Task<AnuncioWebMotors> GetById(int id)
        {
            var obj = await _repository.FirstAsync(x => x.ID == id);

            return obj;
        }

        public async Task Salvar(AnuncioWebMotors objeto)
        {
            _repository.Add(objeto);
            await _context.SaveChangesAsync();
        }
    }
}
