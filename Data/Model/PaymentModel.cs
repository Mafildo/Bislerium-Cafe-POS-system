using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bislerium.Data.Model
{
    public class PaymentModel
    {
        public int PucrhcaseCount {  get; set; }
        public OrderModel Order {  get; set; }
        public string CustomerName {  get; set; }
        public string CustomerPhone{ get; set; }

        public string PaymentDate { get; set; }

        public int Discount{ get; set; }
    }
}
