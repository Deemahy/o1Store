using MediatR;
using StoreLogic_lib.CQRS.Command;
using StoreLogic_lib.Data.Database;
using StoreLogic_lib.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLogic_lib.CQRS.Handler
{
    public class UpDateUserHandler : IRequestHandler<UpDateUserCommand, UserDTOs>
    {
        private readonly StoreDbContext _db;
        public UpDateUserHandler(StoreDbContext db)
        {
            _db = db;
        }
        public async Task<UserDTOs> Handle(UpDateUserCommand request, CancellationToken cancellationToken)
        {
            var result =  _db.Users.FirstOrDefault(x=>x.UserId== request.DTOs.UserId);
           if (result == null) {
                return await Task.FromResult<UserDTOs>(null);
            }
            result.UserName = request.DTOs.UserName;
            result.Password = request.DTOs.Password;    
            result.Email = request.DTOs.Email;  
            result.Phone = request.DTOs.Phone;
            result.UserType = request.DTOs.UserType;    
            result.ProfilePictureUrl = request.DTOs.ProfilePictureUrl;  
          
            UserDTOs userDTOs = new() {
            UserName = request.DTOs.UserName,
            Password = request.DTOs.Password,
            Email = request.DTOs.Email,
            Phone = request.DTOs.Phone,
            UserType = request.DTOs.UserType,
            ProfilePictureUrl = request.DTOs.ProfilePictureUrl,

             };

            _db.SaveChanges();  
            return await Task.FromResult(userDTOs); 
        }
    }
}
