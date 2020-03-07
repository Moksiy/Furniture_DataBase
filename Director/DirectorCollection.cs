using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureDataBase_WS
{
    /// <summary>
    /// Класс для списка продукции каюинета директора   
    /// </summary>
    public class DirectorCollection
    {
        //Маркировка
        public string Marking { get; set; }

        //Тип оборудования
        public string Type { get; set; }

        //Характеристики через JSON
        public string Specifications { get; set; }
    }
}
