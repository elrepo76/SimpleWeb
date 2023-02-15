namespace Contracts
{
    public interface IRepositoryWrapper
    {
        ILoginRepository Login { get; }
        IUserRepository User { get; }
        void Save();
    }
}
