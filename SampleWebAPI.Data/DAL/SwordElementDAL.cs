using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Domain;

namespace SampleWebAPI.Data.DAL
{
    public class SwordElementDAL : ISwordElement
    {
        private readonly SamuraiContext _context;
        public SwordElementDAL(SamuraiContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            try
            {
                var deleteSwordElement = await _context.SwordElements
                    .Where(i => i.SwordId == id)
                    .ToListAsync();
                if (deleteSwordElement == null)
                    throw new Exception($"Data Element Dengan Id {id} Tidak Ditemukan");

                _context.SwordElements.RemoveRange(deleteSwordElement);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<SwordElement>> GetAll()
        {
            var results = await _context.SwordElements
                .OrderBy(i => i.SwordId)
                .ToListAsync();
            return results;
        }

        public Task<SwordElement> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<SwordElement> Insert(SwordElement obj)
        {
            try
            {
                _context.SwordElements.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
            
        }

        public Task<SwordElement> Update(SwordElement obj)
        {
            throw new NotImplementedException();
        }
    }
}
