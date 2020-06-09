using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo.Models
{
    public class todoItem
    {
        //ID вещи
        public long Id { get; set; }
        //название вещи
        public string Name { get; set; }
        //цена
        public string Price { get; set; }
    }
}
