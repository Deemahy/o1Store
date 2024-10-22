using MediatR;
using StoreLogic_lib.CQRS.Command;
using StoreLogic_lib.Data.Database;
using StoreLogic_lib.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace StoreLogic_lib.CQRS.Handler
{
    public class UpDateAddressHandler : IRequestHandler<UpDateAddressCommand, AddressDTOs>
    {
        private readonly StoreDbContext _db;
        public UpDateAddressHandler(StoreDbContext db)
        {
            _db = db;
        }

        public async Task<AddressDTOs> Handle(UpDateAddressCommand request, CancellationToken cancellationToken)
        {
            var result = _db.Addresses.FirstOrDefault(x => x.AddressId == request.DTOs.AddressId);
            if (result == null) {
                return await Task.FromResult<AddressDTOs>(null);
            }
            result.StreetAddress = request.DTOs.StreetAddress; 
            result.City = request.DTOs.City;
            result.Country = request.DTOs.Country;  
            result.State = request.DTOs.State;
            result.Apartment = request.DTOs.Apartment;  
            result.ZipCode = request.DTOs.ZipCode;
             _db.SaveChanges();
             AddressDTOs resultDTO = new() {
            StreetAddress = request.DTOs.StreetAddress,
            City = request.DTOs.City,
            Country = request.DTOs.Country,
            State = request.DTOs.State,
            Apartment = request.DTOs.Apartment,
            ZipCode = request.DTOs.ZipCode
        };
            return await Task.FromResult( resultDTO);   
        }
    }
}
