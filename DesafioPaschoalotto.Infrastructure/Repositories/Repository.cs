using DesafioPaschoalotto.Domain.Repositories;
using DesafioPaschoalotto.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPaschoalotto.Infrastructure.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        protected AppDbContext _ctx;

        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IList<TEntity>> GetAll()
        {
            return await _ctx.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(TKey id)
        {
            return await _ctx.Set<TEntity>().FindAsync(id);
        }

        public async Task Save(TEntity entity)
        {
            await _ctx.Set<TEntity>().AddAsync(entity);
            
            
        }

        public async Task Update(TEntity entity)
        {
            _ctx.Set<TEntity>().Update(entity);
           
        }

    }
}
