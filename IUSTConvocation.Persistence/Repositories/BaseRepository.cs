using System.Data;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Dapper;
using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Domain.Interfaces;
using IUSTConvocation.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace IUSTConvocation.Persistence.Repositories;

public class BaseRepository : IBaseRepository
{
    private readonly ConvocationDbContext context;
    public BaseRepository(ConvocationDbContext context)
    {
        this.context = context;
    }




    #region async methods

    public async Task<int> DeleteAsync<T>(T model) where T : class, IBaseModal, new()
    {
        await Task.Run(() => context.Set<T>().Remove(model));
        return await context.SaveChangesAsync();
    }


    public async Task<IQueryable<T>> FindByAsync<T>(Expression<Func<T, bool>> expression) where T : class, IBaseModal
    {
        return await Task.Run(() => context.Set<T>().Where(expression));
    }


    public async Task<IQueryable<T>> GetAllAsync<T>() where T : class, IBaseModal
    {
        return await Task.Run(() => context.Set<T>());
    }


    public async Task<T?> GetByIdAsync<T>(Guid id) where T : class, IBaseModal
    {
        return await context.Set<T>().FindAsync(id);
    }


    public async Task<int> InsertAsync<T>(T model) where T : class, IBaseModal
    {
        await context.AddAsync<T>(model);
        return await context.SaveChangesAsync();
    }

    public async Task<int> InsertRangeAsync<T>(List<T> model) where T : class, IBaseModal
    {
        await context.AddRangeAsync(model);
        return await context.SaveChangesAsync();
    }


    public async Task<int> UpdateAsync<T>(T model) where T : class, IBaseModal
    {
        await Task.Run(() => context.Update<T>(model));
        return await context.SaveChangesAsync();
    }


    public async Task<T?> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> expression) where T : class, IBaseModal
    {
        return await context.Set<T>().FirstOrDefaultAsync<T>(expression);
    }

    #endregion



    #region sync methods


    int IBaseRepository.Delete<T>(T model)
    {
        throw new NotImplementedException();
    }

    IQueryable<T> IBaseRepository.FindBy<T>(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    IQueryable<T> IBaseRepository.GetAll<T>()
    {
        throw new NotImplementedException();
    }

    T IBaseRepository.GetById<T>(Guid id)
    {
        throw new NotImplementedException();
    }

    int IBaseRepository.Insert<T>(T model)
    {
        throw new NotImplementedException();
    }

    int IBaseRepository.Update<T>(T model)
    {
        throw new NotImplementedException();
    }

    #endregion



    #region dapper methods

    public async Task<int> ExecuteAsync<T>(string sql, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
    {
        return await context.ExecuteAsyncExtentionMethod<T>(sql, param, commandType, transaction);
    }


    public async Task<T?> FirstOrDefaultAsync<T>(string sql, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
    {
        return await context.FirstOrDefaultAsyncDapperExtentionMethod<T>(sql, param, commandType, transaction);
    }


    public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
    {
        return await context.QueryAsyncDapperExtentionMethod<T>(sql, param, commandType, transaction);
    }


    public Task<T?> SingleOrDefaultAsync<T>(string sql, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
    {
        return context.SingleOrDefaultAsyncDapperExtentionMethod<T>(sql, param, commandType, transaction);
    }

    #endregion

}

#region dapper extention methods
public static class EfCoreExtentions
{



    public static async Task<IEnumerable<T>> QueryAsyncDapperExtentionMethod<T>(this DbContext context, string sql, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
    {
        try
        {

            SqlConnection connection = new(context.Database.GetConnectionString());
            return await connection.QueryAsync<T>(sql, param, transaction, null, commandType);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }



    }


    public static async Task<int> ExecuteAsyncExtentionMethod<T>(this DbContext context, string sql, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
    {

        try
        {
            SqlConnection connection = new(context.Database.GetConnectionString());
            return await connection.ExecuteAsync(sql, param, transaction, null, commandType);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

    }


    public static async Task<T?> SingleOrDefaultAsyncDapperExtentionMethod<T>(this DbContext context, string sql, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
    {

        try
        {
            SqlConnection connection = new(context.Database.GetConnectionString());
            return await connection.QuerySingleOrDefaultAsync<T>(sql, param, transaction, null, commandType);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

    }


    public static async Task<T?> FirstOrDefaultAsyncDapperExtentionMethod<T>(this DbContext context, string sql, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
    {

        try
        {
            SqlConnection connection = new(context.Database.GetConnectionString());
            return await connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction, null, commandType);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }

    }



}
#endregion