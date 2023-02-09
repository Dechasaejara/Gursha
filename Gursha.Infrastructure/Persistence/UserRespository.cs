// 

using Gursha.Application.Common.Interfaces.Persistence;
using Gursha.Domain.Entities;

namespace Gursha.Infrastructure.Persistence;

public class UserRespository : IUserRespository
{
    private static readonly List<UserEntity> _user = new();
    // 
    public void Add(UserEntity user)
    {
        _user.Add(user);
    }
    // 
    public UserEntity? GetUserByEmail(string email)
    {
        return _user.SingleOrDefault(u => u.Email == email);
    }
}