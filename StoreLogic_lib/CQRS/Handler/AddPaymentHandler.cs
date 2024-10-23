using MediatR;
using StoreLogic_lib.CQRS.Command;
using StoreLogic_lib.Data.Database;
using StoreLogic_lib.Data.DTOs;
using StoreLogic_lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLogic_lib.CQRS.Handler
{
    public class AddPaymentHandler : IRequestHandler<AddPaymentCommand, PaymentDTOs>
    {
        private readonly StoreDbContext _db;
        public AddPaymentHandler(StoreDbContext db)
        {
            _db = db;
        }
        public async Task<PaymentDTOs> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
        {
            Payment New= new() { 
              OrderId = request.DTOs.OrderId,   
              PaymentDate = request.DTOs.PaymentDate,
              PaymentMethod = request.DTOs.PaymentMethod,   
              Amount = request.DTOs.Amount, 
            
            
            };
             _db.Payments.Add(New);
            _db.SaveChangesAsync();

            PaymentDTOs  dtos = new()
            {
                
                OrderId = request.DTOs.OrderId,
                PaymentDate = request.DTOs.PaymentDate,
                PaymentMethod = request.DTOs.PaymentMethod,
                Amount = request.DTOs.Amount,


            };
            return await Task.FromResult(dtos);    

        }
    }
}
