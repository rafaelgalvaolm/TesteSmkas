using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Smkas.Data.Extensions
{
    public static class DbContextExtensions
    {
        public static async Task UpdateEntryAsync<TEntity>(this DbContext dbContext, int key, object modifiedFields) where TEntity : class
        {
            var entity = await dbContext.Set<TEntity>().FindAsync(key);
            dbContext.Attach(entity);
            dbContext.Entry(entity).CurrentValues.SetValues(modifiedFields);
        }
    }
}