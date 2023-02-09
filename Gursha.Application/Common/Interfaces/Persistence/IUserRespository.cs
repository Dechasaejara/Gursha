// 

using Gursha.Domain.Entities;

namespace Gursha.Application.Common.Interfaces.Persistence;
public interface IUserRespository

{
    public UserEntity? GetUserByEmail(string email);
    public void Add(UserEntity user);
}