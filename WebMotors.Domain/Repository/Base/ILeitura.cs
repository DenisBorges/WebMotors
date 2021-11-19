using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMotors.Domain.Repository
{
    public interface ILeitura<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
    }
}
