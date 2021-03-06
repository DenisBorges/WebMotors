using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMotors.Domain.Repository
{
    public interface IAnuncioWebMotorsRepository : ILeitura<AnuncioWebMotors>,IGravacao<AnuncioWebMotors>
    {
        Task<List<AnuncioWebMotors>> ListByFilter(AnuncioWebMotors filter);
    }
}
