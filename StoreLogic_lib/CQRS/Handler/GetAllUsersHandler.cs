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
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserDTOs>>
    {
        private readonly StoreDbContext _db;
        public GetAllUsersHandler(StoreDbContext db)
        {
            _db = db;
        }

        public async Task<List<UserDTOs>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = _db.Users.ToList();
            if (result == null)
                return await Task.FromResult<List<UserDTOs>>(null);
            List<UserDTOs> userDTOs = new List<UserDTOs>();
            foreach (var item in result) {
                UserDTOs userDTO = new() {
                    UserId = item.UserId,
                    Password = item.Password,
                    Email = item.Email,
                    Phone = item.Phone,
                    UserType = item.UserType,
                    ProfilePictureUrl = item.ProfilePictureUrl,
                    Status = item.Status,
                    UserName = item.UserName,
                };

                userDTOs.Add(userDTO);
            };
            return await Task.FromResult(userDTOs);

        }
    }
}   

