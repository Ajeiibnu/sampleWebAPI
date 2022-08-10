using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Domain;

namespace SampleWebAPI.Data.DAL
{
    public class AttrElementsDAL : IAttrElement
    {
        private readonly SamuraiContext _context;
        public AttrElementsDAL(SamuraiContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var deleteElement = await _context.AttrElements
                    .FirstOrDefaultAsync(i => i.AttrElementId == id);
                if (deleteElement == null)
                    throw new Exception($"Data Element Dengan Id {id} Tidak Ditemukan");
                _context.AttrElements.Remove(deleteElement);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<AttrElement>> GetAll()
        {
            var results = await _context.AttrElements
                .OrderBy(i => i.ElementName).ToArrayAsync();
            return results;
        }

        public async Task<AttrElement> GetById(int id)
        {
            var result = await _context.AttrElements
                .FirstOrDefaultAsync(i => i.AttrElementId == id);
            if (result == null)
                throw new Exception($"Data Element Dengan Id {id} Tidak Ditemukan");
            return result;
        }

        public async Task<IEnumerable<AttrElement>> GetByName(string name)
        {
            var result = await _context.AttrElements
                .Where(s => s.ElementName.Contains(name))
                .OrderBy(s => s.ElementName).ToListAsync();
            return result;
        }

        public async Task<AttrElement> Insert(AttrElement obj)
        {
            try
            {
                _context.AttrElements.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<AttrElement> Update(AttrElement obj)
        {
            try
            {
                var updateElements = await _context.AttrElements
                    .FirstOrDefaultAsync(i => i.AttrElementId == obj.AttrElementId);
                if (updateElements == null)
                    throw new Exception($"Data Element Dengan Id {obj.AttrElementId} Tidak Ditemukan");

                updateElements.ElementName = obj.ElementName;
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
