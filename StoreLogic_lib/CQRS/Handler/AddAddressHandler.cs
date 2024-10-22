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
    public class AddAddressHandler : IRequestHandler<AddAddressCommand, AddressDTOs>
    {
        private readonly StoreDbContext _db;
        public AddAddressHandler(StoreDbContext db)
        {
            _db = db;
        }
        public async Task<AddressDTOs> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            var usercheck = _db.Users.FirstOrDefault(x=>x.UserId  == request.DTOs.UserId);
            if (usercheck == null) {
                throw new Exception("User Not found ");
            }

            Address address = new() {

                UserId =request.DTOs.UserId,
               StreetAddress = request.DTOs.StreetAddress,  
               City = request.DTOs.City,    
               State = request.DTOs.State,  
               ZipCode = request.DTOs.ZipCode,  
               Country = request.DTOs.Country,  
            
            }; 
            _db.Addresses.Add(address);
            _db.SaveChanges();  

            AddressDTOs addressDTOs = new() {
                UserId = request.DTOs.UserId,
                StreetAddress = request.DTOs.StreetAddress,
                City = request.DTOs.City,
                State = request.DTOs.State,
                ZipCode = request.DTOs.ZipCode,
                Country = request.DTOs.Country,

            };    


           return await  Task.FromResult(addressDTOs);       
        }
    }
}
