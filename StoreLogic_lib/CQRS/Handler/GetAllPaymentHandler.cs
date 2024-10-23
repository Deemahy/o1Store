using MediatR;
using StoreLogic_lib.CQRS.Query;
using StoreLogic_lib.Data.Database;
using StoreLogic_lib.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLogic_lib.CQRS.Handler
{
    public class GetAllPaymentHandler : IRequestHandler<GetAllPaymentQuery, List<PaymentDTOs>>
    {
        private readonly StoreDbContext _db;
        public GetAllPaymentHandler(StoreDbContext db)
        {
            _db = db;
        }

        public async Task<List<PaymentDTOs>> Handle(GetAllPaymentQuery request, CancellationToken cancellationToken)
        {
            var result = _db.Payments.ToList();
            if (result.Any())
            {
                List<PaymentDTOs> DTOs = new List<PaymentDTOs>();
                foreach (var item in result)
                {
                    PaymentDTOs dtos = new()
                    {
                        PaymentId = item.PaymentId,
                        OrderId = item.OrderId,
                        PaymentMethod = item.PaymentMethod,
                        Amount = item.Amount
                    };
                    DTOs.Add(dtos);
                }
                return await Task.FromResult(DTOs); 
            }
            return await Task.FromResult<List<PaymentDTOs>>(null);

        }
    }
}
