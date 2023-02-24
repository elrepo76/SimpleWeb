using Entities.DTO;
using Entities.Models;

namespace Contracts
{
    public interface ILoginRepository : IRepositoryBase<Login>
    {
        LoginDto GetLoginDto(Login credential);
    }
}
