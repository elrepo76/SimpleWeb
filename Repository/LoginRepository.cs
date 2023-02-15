using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class LoginRepository : RepositoryBase<Login>, ILoginRepository
    {
        public LoginRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }
    }
}
