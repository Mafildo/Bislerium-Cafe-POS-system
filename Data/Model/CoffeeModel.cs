using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bislerium.Data.Model
{
    public class CoffeeModel
    {
        /*public Guid Id { get; set; } = Guid.NewGuid();*/
        public int Id { get; set; }

        public string CoffeeName { get; set; }
        public decimal Price { get; set; }
    }
}
