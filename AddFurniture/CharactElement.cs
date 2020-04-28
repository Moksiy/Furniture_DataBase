using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureDataBase_WS
{
    public class CharactElement
    {
        public string Name { get; set; }
        public string Charact { get; set; }

        public CharactElement(string n, string c)
        {
            this.Name = n;
            this.Charact = c;
        }
    }
}
