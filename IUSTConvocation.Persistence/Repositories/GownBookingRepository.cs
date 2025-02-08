using IUSTConvocation.Application.Abstractions.IRepositories;
using IUSTConvocation.Application.RRModels;
using IUSTConvocation.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUSTConvocation.Persistence.Repositories
{
    public class GownBookingRepository : BaseRepository, IGownBookingRepository, IBaseRepository
    {
        private readonly ConvocationDbContext context;
        public GownBookingRepository(ConvocationDbContext context) : base(context)
        {
            this.context = context;
        }

        private readonly string baseQuery = $@"SELECT B.Id, B.GownId, U.Id AS UserId, U.[UserName], P.PaymentMethod, P.Currency, 
	                                            A.TotalAmount, P.Amount AS AmountPaid, P.AppPaymentStatus, GownStatus,
	                                            P.RPOrderId, P.OrderId, P.TransactionId, B.CreatedOn  
                            
                                                FROM GownBookings B
	                                            INNER JOIN AppOrders A
	                                            ON B.Id =A.GownBookingId
	                                            INNER JOIN AppPayments P
	                                            ON A.Id = P.OrderId
	                                            INNER JOIN Users U
	                                            ON U.Id = B.GownId ";

        string whereClause = $@"  WHERE B.GownId =@id AND B.GownStatus={(int)GownStatus.Approved} AND P.AppPaymentStatus={(int)AppPaymentStatus.Captured}
	                        ORDER BY B.CreatedOn DESC ";



        public async Task<GownBookingResponse> GetBookingById(Guid id)
        {
            return await FirstOrDefaultAsync<GownBookingResponse>(baseQuery + @$" WHERE B.Id =@id AND B.GownStatus={(int)GownStatus.Approved} AND P.AppPaymentStatus={(int)AppPaymentStatus.Captured}", new { id });

        }

        public async Task<IEnumerable<GownBookingResponse>> GetBookingsByGownId(Guid id)
        {
            return await QueryAsync<GownBookingResponse>(baseQuery + whereClause, new { id });

        }


        public async Task<StudentBookingGownResponse?> GetMyBookings(Guid id)
        {
            string query = $@"  SELECT G.Id AS GownId, G.Color, G.Quantity, G.Size, G.Charges, P.CreatedOn AS PaymentDate, F.Id AS FileId, F.FilePath,
                                  B.GownStatus, A.UserId, A.Receipt, A.Currency, A.OrderStatus,
                                  P.TransactionId, P.Amount, P.PaymentMethod, P.AppPaymentStatus, C.[Name] AS ConvocationName, C.[Description], 
								  C.ConvocationDate

                                    FROM Convocations C
									INNER JOIN GownBookings B
									ON C.Id = B.ConvocationId
									INNER JOIN	Gowns G 
                                    ON G.Id = B.GownId
	                                INNER JOIN AppOrders A
	                                ON B.Id =A.GownBookingId
	                                INNER JOIN AppPayments P
	                                ON A.Id = P.OrderId
	                                INNER JOIN Users U
	                                ON U.Id = B.EntityId
	                                LEFT JOIN AppFiles F
	                                ON G.Id = F.EntityId 	
                                    WHERE A.UserId =@id  AND B.GownStatus={(int)GownStatus.Approved} AND P.AppPaymentStatus={(int)AppPaymentStatus.Captured} ";
            return await FirstOrDefaultAsync<StudentBookingGownResponse>(query, new { id });
        }


        public async Task<int> TotalSalesAmountByGownId(Guid gownId)
        {
            string query = $@"SELECT SUM(P.Amount) AS TotalAmount 
                                FROM GownBookings B
	                            INNER JOIN AppOrders A
	                            ON B.Id =A.GownBookingId
	                            INNER JOIN AppPayments P
	                            ON A.Id = P.OrderId
	                            INNER JOIN Users U
	                            ON U.Id = B.GownId
			                    WHERE B.GownId =@id AND B.GownStatus={(int)GownStatus.Approved} 
                                AND P.AppPaymentStatus={(int)AppPaymentStatus.Captured}
	                            GROUP BY P.AMOUNT ";
            return await FirstOrDefaultAsync<int>(query, new { id = gownId });
        }

        public async Task<IEnumerable<StudentGownBookingsResponse>> GetGownBookings(Guid convocationId)
        {
            string query = $@"  SELECT  G.Id AS GownId, G.Color, G.Quantity, G.Size, G.Charges, P.CreatedOn AS PaymentDate, F.Id AS FileId, F.FilePath, B.ConvocationId,
                                  B.GownStatus, A.UserId, A.Receipt, A.Currency, A.OrderStatus,
                                  P.TransactionId, P.Amount, P.PaymentMethod, P.AppPaymentStatus, S.[Name], U.ContactNo, U.Email, S.Batch, S.Course,
								  S.Position, S.RegNumber, S.Parentage

                                    FROM Convocations C
                                    INNER JOIN GownBookings B
									ON C.Id = B.ConvocationId
									INNER JOIN Gowns G
                                    ON G.Id = B.GownId
	                                INNER JOIN AppOrders A
	                                ON B.Id =A.GownBookingId
	                                INNER JOIN AppPayments P
	                                ON A.Id = P.OrderId
	                                INNER JOIN Users U
	                                ON U.Id = B.EntityId
									INNER JOIN Students S
									ON S.Id = U.Id
	                                LEFT JOIN AppFiles F
	                                ON G.Id = F.EntityId 	
                                    WHERE C.Id=@convocationId  AND B.GownStatus={(int)GownStatus.Approved} AND P.AppPaymentStatus={(int)AppPaymentStatus.Captured} ";

            return await QueryAsync<StudentGownBookingsResponse>(query , new { convocationId });
        }
    }
}
