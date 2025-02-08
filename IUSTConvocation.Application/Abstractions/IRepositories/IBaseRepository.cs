using IUSTConvocation.Domain.Interfaces;
using System.Data;
using System.Linq.Expressions;

namespace IUSTConvocation.Application.Abstractions.IRepositories;

public interface IBaseRepository
{

    #region sync methods
    int Insert<T>(T model) where T : class, IBaseModal;

    int Update<T>(T model) where T : class, IBaseModal;

    int Delete<T>(T model) where T : class, IBaseModal, new();

    IQueryable<T> GetAll<T>() where T : class, IBaseModal;

    IQueryable<T> FindBy<T>(Expression<Func<T, bool>> expression) where T : class, IBaseModal;

    T GetById<T>(Guid id) where T : class, IBaseModal;

    #endregion


    #region async methods
    Task<int> InsertAsync<T>(T model) where T : class, IBaseModal;
    Task<int> InsertRangeAsync<T>(List<T> model) where T : class, IBaseModal;

   Task<int> UpdateAsync<T>(T model) where T : class, IBaseModal;

    Task<int> DeleteAsync<T>(T model) where T : class, IBaseModal, new();

    Task<IQueryable<T>> GetAllAsync<T>() where T : class, IBaseModal;

    Task<IQueryable<T>> FindByAsync<T>(Expression<Func<T, bool>> expression) where T : class, IBaseModal;

    Task<T?> GetByIdAsync<T>(Guid id) where T : class, IBaseModal;

    Task<T?> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> expression) where T : class, IBaseModal;

    #endregion


    #region dapper methods

    Task<int> ExecuteAsync<T>(string sql, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null);


    Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null);


    Task<T?> FirstOrDefaultAsync<T>(string sql, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null);


    Task<T?> SingleOrDefaultAsync<T>(string sql, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null);


    #endregion


}
