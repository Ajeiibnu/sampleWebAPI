using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Data.DAL
{
    public interface IAttrElement : ICrud<AttrElement>
    {
        Task<IEnumerable<AttrElement>> GetByName(string name);
    }
}
