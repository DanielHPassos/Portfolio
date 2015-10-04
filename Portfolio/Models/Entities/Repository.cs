using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Models.Context;
using Portfolio.Models.Interfaces;

namespace Portfolio.Models.Entities
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected Contexto ctx = new Contexto();
        public void Add(TEntity obj)
        {
            ctx.Set<TEntity>().Add(obj);
            ctx.SaveChanges();
        }

        public IEnumerable<TEntity> Listar()
        {
            return ctx.Set<TEntity>().ToList();

        }

        public TEntity Buscar(int id)
        {
            return ctx.Set<TEntity>().Find(id);
        }

        public void Update(TEntity obj)
        {
            ctx.Entry(obj).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(TEntity obj)
        {
            ctx.Set<TEntity>().Remove(obj);
            ctx.SaveChanges();
        }
    }
}
