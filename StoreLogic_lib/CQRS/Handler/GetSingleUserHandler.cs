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
    public class GetSingleUserHandler : IRequestHandler<GetSingleUserQuery, UserDTOs>
    {
        private readonly StoreDbContext _db;
        public GetSingleUserHandler(StoreDbContext db)
        {
            _db = db;
        }
        public async Task<UserDTOs> Handle(GetSingleUserQuery request, CancellationToken cancellationToken)
        {
            var result = _db.Users.FirstOrDefault(x=>x.UserId == request.id);
            if (result == null) {
                return await Task.FromResult<UserDTOs>(null);
            }
            UserDTOs user = new() {
              UserId = result.UserId,  
              Password= result.Password,
              Email = result.Email,
              Phone = result.Phone,
              UserType = result.UserType,   
              ProfilePictureUrl = result.ProfilePictureUrl, 
               Status =result.Status,
            };
            return await Task.FromResult(user); 
        }
        
    }
}
