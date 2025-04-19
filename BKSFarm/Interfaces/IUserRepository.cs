namespace BKSFarm.api.Interfaces
{
    public interface IUserRepository
    {
        public Task<bool> AddEggToUser(string UserId, Guid EggId);

        public Task<string> CreateUserWithTocken(string Tockne);

    }
}
