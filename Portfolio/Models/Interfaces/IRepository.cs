using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Models.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        IEnumerable<TEntity> Listar();

        TEntity Buscar(int id);

        void Update(TEntity obj);

        void Delete(TEntity obj);
    }
}
