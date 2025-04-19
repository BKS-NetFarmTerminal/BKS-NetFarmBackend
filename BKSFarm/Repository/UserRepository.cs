using BKSFarm.api.Data;
using BKSFarm.api.Entities;
using BKSFarm.api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BKSFarm.api.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly DataContext _ctx;
        public UserRepository(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Guid?> FindUserByTocken(string userTocken)
        {
            var user = await _ctx.Users
                .FirstOrDefaultAsync(u => u.Token == userTocken);
            if (user == null)
            {
                return null; 
            }
            return user.UserId; 
        }
        public async Task<string> CreateUserWithTocken(string Tockne)
        {
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Token = Tockne,   
                Login = "123"
            };
            await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();
            return user.Token;
        }
        public async Task<string> CreateUserWithoutTocken()
        {
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Token = Guid.NewGuid().ToString(),
                Login = "123"
            };
            await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();
            return user.Token;
        }

        public async Task<bool> AddEggToUser(string userTocken, Guid eggId)
        {
            Guid? userId = await FindUserByTocken(userTocken);

            if (!userId.HasValue)
            {
                return false; 
            }

            var user = await _ctx.Users
                .Include(u => u.Eggs)
                .FirstOrDefaultAsync(u => u.UserId == userId.Value);

            var egg = await _ctx.Eggs.FindAsync(eggId);

            if (user == null || egg == null)
            {
                return false; 
            }
            var userEgg = new UserEgg
            {
                Id = Guid.NewGuid(),
                UserId = userId.Value,
                EggId = eggId,
                Type = egg.Type  

            };

            user.Eggs.Add(userEgg);

            await _ctx.SaveChangesAsync();

            return true; 
        }
       
    }
}
