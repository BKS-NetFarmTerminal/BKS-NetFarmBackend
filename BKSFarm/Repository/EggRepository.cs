using BKSFarm.api.Data;
using BKSFarm.api.Entities;
using BKSFarm.api.Interfaces;
using BKSFarm.Dto.Egg;
using Microsoft.EntityFrameworkCore;

namespace BKSFarm.api.Repository
{
    public class EggRepository : IEggRepository
    {
        private readonly DataContext _ctx;
        public EggRepository(DataContext ctx)
        {
            _ctx = ctx;
            
        }
        private async Task<bool> EggExist(string eggType)
        {
            return await _ctx.Eggs.AnyAsync(c => c.Type == eggType);
        }
        private async Task<bool> EggExist(Guid id)
        {
            return await _ctx.Seeds.AnyAsync(c => c.Id == id);
        }
        public async Task<Egg> CreateEgg(CreateEggDto newEgg)
        {
            if (await EggExist(newEgg.Type) == false)
            {
                var egg = new Egg()
                {
                    Id = Guid.NewGuid(),
                    Type = newEgg.Type,
                    ImageUrl = newEgg.ImageUrl,
                };
                if (egg != null)
                {
                    await _ctx.Eggs.AddAsync(egg);
                    await _ctx.SaveChangesAsync();
                    return egg;
                }
            }
            return null;
        }

        public async Task<bool> DeleteEgg(Guid id)
        {
            var egg = await _ctx.Eggs.FindAsync(id);
            if (egg != null)
            {
                _ctx.Eggs.Remove(egg);
                await _ctx.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Egg>> GetAllEggs()
        {
            var egg = await _ctx.Eggs.ToListAsync();
            return egg;
        }

        public async Task<Egg> GetEGgById(Guid id)
        {
            if (!await EggExist(id))
            {
                var egg = await _ctx.Eggs.FindAsync(id);
                return egg;
            }
            return null;
        }

        public async Task<Egg> UpdateEgg(Guid id, UpdateEggDto upadedEgg)
        {
            var egg = await _ctx.Eggs.FindAsync(id);
            if (egg != null)
            {
                egg.Type = upadedEgg.Type;
                egg.ImageUrl = upadedEgg.ImageUrl;
                await _ctx.SaveChangesAsync();
                return egg;
               
            }
            return null;
        }
    }
}
