using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext context;
        private DbSet<T> entities;
        public Repository()
        {
            this.context = new ApplicationContext();
            entities = context.Set<T>();
        }
        public void Add(T Entity)
        {
            if (Entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            entities.Add(Entity);
            context.SaveChanges();
        }

        public void Remove(T Entity)
        {
            if (Entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            entities.Remove(Entity);
            context.SaveChanges();
        }
        public void Delete(T Entity)
        {
            if (Entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            entities.Remove(Entity);
            context.SaveChanges();
        }

        public T Get(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void SaveChanges()
        {
           context.SaveChanges();
        }

        public void Update(T Entity)
        {
            if (Entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            context.SaveChanges();
        }
    }
}
