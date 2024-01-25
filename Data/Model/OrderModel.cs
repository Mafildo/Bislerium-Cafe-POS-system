
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bislerium.Data.Model
{
    public class OrderModel
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public CoffeeModel Coffee { get; set; }
        public int Quantity { get; set; }
        public List<AddInModel> AddIns { get; set; }
        public decimal Total {  get; set; }
        public bool PaymentStatus {  get; set; }
        public decimal DiscountedAmount { get; set; }
    }


}
