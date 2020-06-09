using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace todo.Models
{
    public class Customer
    {
        //ID покупателя
        public long Id { get; set; }
        //имя покупателя
        public string Name { get; set; }
        //фамилия покупателя
        public string Surname { get; set; }
        //адресс покупателя
        public string Adress { get; set; }
        //подтверждение заказа 
        public bool Confirmation { get; set; }

        //покупки
        public ICollection<todoItem> Things { get; set; }

        //колличество вещей
        public int GetCountOfTodoItems()
        {
            return Things.Count;
        }
    }
}
