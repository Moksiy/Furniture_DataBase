using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureDataBase_WS
{
    public class FurnitureElement
    {
        public string Mark { get; set; }
        public string Type { get; set; }
        public string Charact { get; set; }

        public FurnitureElement(string m, string t, string d)
        {
            this.Mark = m;
            this.Type = t;
            this.Charact = d;
        }
    }
}
