using Contracts;
using Entities;
using Entities.DTO;
using Entities.Models;

namespace Repository
{
    public class LoginRepository : RepositoryBase<Login>, ILoginRepository
    {
        readonly RepositoryContext _loginContext;
        public LoginRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
            _loginContext = repositoryContext;
        }

        public LoginDto GetLoginDto(Login credential)
        {
            using (var context = new RepositoryContext())
            {
                var login = context.Login?.SingleOrDefault(l => l.Username.Equals(credential.Username) && l.Password.Equals(credential.Password));

                return LoginDtoMapper.MapToDto(login);
            }            
        }
    }
}
