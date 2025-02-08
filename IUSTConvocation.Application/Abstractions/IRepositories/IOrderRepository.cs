using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Domain.Entities;

namespace IUSTConvocation.Application.Abstractions.IRepository
{
    public interface IOrderRepository: IBaseRepository
    {
        Task<int> SaveOrder(AppOrder model);


        Task<int> GetAppointments(AppOrder model);
    }
}
