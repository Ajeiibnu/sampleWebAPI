using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Domain
{
    public class Sword
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
        public Samurai? Samurai { get; set; }
        public SwordType SwordType { get; set; }
        public List<AttrElement> AttrElements { get; set; } = new List<AttrElement>();
    }
}
