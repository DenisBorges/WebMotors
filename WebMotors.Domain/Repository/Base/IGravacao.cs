using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMotors.Domain.Repository
{
    public interface IGravacao<T>
    {
        Task Salvar(T objeto);

        Task Atualizar(T objeto);

        Task Apagar(int id);
    }
}
