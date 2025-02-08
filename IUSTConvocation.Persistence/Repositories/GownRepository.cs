using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUSTConvocation.Persistence.Repositories
{
    public class GownRepository : BaseRepository, IGownRepository, IBaseRepository
    {
        private readonly ConvocationDbContext context;
        public GownRepository(ConvocationDbContext context) : base(context)
        {
            this.context = context;
        }
        private readonly string baseQuery = $@"SELECT   
				                                G.Id, G.Color, G.Quantity, G.Size, G.Charges, G.CreatedOn, F.Id AS FileId, F.FilePath 
                                                FROM Gowns G 
                                                LEFT JOIN AppFiles F
				                                ON G.Id = F.EntityId ";
       
        public async Task<IEnumerable<GownResponse>> GetAllGowns()
        {
            return await QueryAsync<GownResponse>(baseQuery + "WHERE G.IsDeleted = 0 ORDER BY Color", null);
        }

        public async Task<GownResponse> GetGownById(Guid id)
        {
            return await FirstOrDefaultAsync<GownResponse>(baseQuery + "WHERE G.Id = @id AND G.IsDeleted = 0", new { id=id});
        }
    }
}
