using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Domain;

namespace SampleWebAPI.Data.DAL
{
    public class SwordDAL : ISword
    {
        private readonly SamuraiContext _context;
        public SwordDAL(SamuraiContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            try
            {
                var deleteSword = await _context.Swords
                    .FirstOrDefaultAsync(i => i.Id == id);
                if (deleteSword == null)
                    throw new Exception($"Data Sword Dengan Id {id} Tidak Ditemukan");
                _context.Swords.Remove(deleteSword);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<Sword>> GetAll()
        {
            var results = await _context.Swords.OrderBy(i => i.Weight)
                .ToListAsync();
            return results;
        }

        public async Task<IEnumerable<Sword>> GetAllField()
        {
            var swords = await _context.Swords
                .Include(i => i.SwordType)
                .Include(i => i.AttrElements)
                .AsNoTracking()
                .ToListAsync();
            return swords;
        }

        public async Task<Sword> GetById(int id)
        {
            var result = await _context.Swords.FirstOrDefaultAsync(i => i.Id == id);
            if (result == null)
                throw new Exception($"Data Sword Dengan Id {id} Tidak Ditemukan");
            return result;
        }        

        public async Task<IEnumerable<Sword>> GetByName(string name)
        {
            var sword = await _context.Swords.Where(s => s.Name.Contains(name))
               .OrderBy(s => s.Name)
               .ToListAsync();
            return sword;
        }

        public async Task<IEnumerable<Sword>> GetSwordElement(int id)
        {
            var sword = await _context.Swords
                .Where(o => o.Id == id)
                .Include(k => k.AttrElements)
                .ToListAsync();
            if (sword == null)
                throw new Exception($"Data Sword Dengan Id {id} Tidak Ditemukan");
            return sword;
        }

        public async Task<IEnumerable<Sword>> GetSwordType()
        {
            var sword = await _context.Swords
                .Include(i => i.SwordType)
                .OrderBy(i => i.SwordType.TypeName)
                .ToListAsync();
            return sword;
        }

        public async Task<Sword> Insert(Sword obj)
        {
            try
            {
                _context.Swords.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Sword> Update(Sword obj)
        {
            try
            {
                var updateSword = await _context.Swords
                    .FirstOrDefaultAsync(i => i.Id == obj.Id);
                if (updateSword == null)
                    throw new Exception($"Data Sword Dengan Id {obj.Id} Tidak Ditemukan");

                updateSword.Name = obj.Name;
                updateSword.Weight = obj.Weight;
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
