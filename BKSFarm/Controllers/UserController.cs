using BKSFarm.api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BKSFarm.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userEggRepository;
        public UserController(IUserRepository userEggRepository)
        {
            _userEggRepository = userEggRepository;
        }
        [HttpPost]
        public async Task<bool> AddEggToUser(string userTocken, Guid eggId)
        {
            return await _userEggRepository.AddEggToUser(userTocken, eggId);
        }
        [HttpPost ("CreateUser")]
        public async Task<string> CreateUser(string userTocken)
        {
            if (userTocken == null)
            {
                return await _userEggRepository.CreateUserWithoutTocken();
            }
            return await _userEggRepository.CreateUserWithTocken(userTocken);
        }


    }
}
