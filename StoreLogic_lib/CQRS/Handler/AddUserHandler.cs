using MediatR;
using Microsoft.Identity.Client;
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
    public class AddUserHandler : IRequestHandler<AddUserCommand, UserDTOs>
    {
        private readonly StoreDbContext _db;
        public AddUserHandler(StoreDbContext db)
        {
            _db = db;
        }


        public async Task<UserDTOs> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            User user = new() { 
               UserName = request.DTOs.UserName,    
               Password = request.DTOs.Password,    
               Email = request.DTOs.Email,  
               Phone = request.DTOs.Phone,  
               UserType = request.DTOs.UserType,    
               ProfilePictureUrl = request.DTOs.ProfilePictureUrl,  
               Status = request.DTOs.Status,
               DateCreated = request.DTOs.DateCreated,  
               LastLoginDate = request.DTOs.LastLoginDate,  
            };
            _db.Users.Add(user);    
            _db.SaveChanges();
             UserDTOs userDTOs = new() {
                 UserId= request.DTOs.UserId,
                 UserName = request.DTOs.UserName,
                 Password = request.DTOs.Password,
                 Email = request.DTOs.Email,
                 Phone = request.DTOs.Phone,
                 UserType = request.DTOs.UserType,
                 ProfilePictureUrl = request.DTOs.ProfilePictureUrl,
                 Status = request.DTOs.Status,
                 DateCreated = request.DTOs.DateCreated,
                 LastLoginDate = request.DTOs.LastLoginDate,

             };
            return await Task.FromResult(userDTOs);
        }
    }
}
