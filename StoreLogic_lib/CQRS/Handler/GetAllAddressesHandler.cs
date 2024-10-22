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
    public class GetAllAddressesHandler : IRequestHandler<GetAllAddressesQuery, List<AddressDTOs>>
    {
        private readonly StoreDbContext _db;
        public GetAllAddressesHandler(StoreDbContext db)
        {
            _db = db;
        }
        public async Task<List<AddressDTOs>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
        {
            var result =  _db.Addresses.ToList();
            List<AddressDTOs> DTOs = new List<AddressDTOs>();
            if (result.Any()) {
                foreach (var dtos in result) { 
                       AddressDTOs address = new() { 
                           AddressId = dtos.AddressId,  
                           UserId = dtos.UserId ,
                            StreetAddress = dtos.StreetAddress ,    
                            City = dtos.City ,  
                            State = dtos.State ,
                            ZipCode = dtos.ZipCode ,    
                            Country = dtos.Country                        
                       };
                    DTOs.Add(address);  

                }
                return await Task.FromResult(DTOs);
            }
            return await  Task.FromResult<List<AddressDTOs>>(null);
           
        }
    }
}
