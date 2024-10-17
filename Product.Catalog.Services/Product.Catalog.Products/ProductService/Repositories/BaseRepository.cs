using Microsoft.EntityFrameworkCore;
using ProductService.Data;

namespace ProductService.Repositories;

public abstract class BaseRepository<T>(AppDbContext ctx) : IRepository<T> where T : class
{
    private readonly DbSet<T> _entitySet = ctx.Set<T>();

    public async Task Delete(int? id)
    {
        if (await Exist(id))
        {
            var entity = await Find(id);
            ctx.Remove(entity);
            await ctx.SaveChangesAsync();
        }
    }
    public async Task<bool> Exist(int? id)
    {
        var entity = await _entitySet.FindAsync(id);
        return entity != null;
    }
    public async Task<T> Find(int? id)
    {
        var entity = await _entitySet.FindAsync(id);
        return entity;
    }
    public async Task<IEnumerable<T>> FindAll()
    {
        return await _entitySet.ToListAsync();
    }
    public async Task<int> Count()
    {
        return await _entitySet.CountAsync();
    }
    public virtual async Task Save(T t)
    {
        if (t != null)
        {
            await _entitySet.AddAsync(t);
            await ctx.SaveChangesAsync();
        }
    }
    public async Task Update(T t)
    {
        if (t != null)
        {
            ctx.Update(t);
            await ctx.SaveChangesAsync();
        }
    }
    public async Task AddRange(object[] t)
    {
        await ctx.AddRangeAsync(t);
        await ctx.SaveChangesAsync();
    }
}