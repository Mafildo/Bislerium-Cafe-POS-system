using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Bislerium.Data.Model
{
     public class AddInModel
    {
       /* public Guid Id { get; set; } = Guid.NewGuid();*/
       public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
     } 
}

