using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment5
{
    internal class Order
    {
        public Order(int id, string client,List<OrderDetails> detaillist)
        {
            this.id = id;
            this.client = client;
            this.detailList = detaillist;

        }
        public int id { get; set; }//订单号

        public string client { get; set; } //客户

        public double money => detailList.Sum(detail => detail.ammount * detail.commdityMoney);//订单总金额

        public List<OrderDetails> detailList { get; set; } //orderdetails

        public override string ToString()
        {
            return $"id:{id};\n client:{client};\nmoney:{money}";
        }

        public override bool Equals(object? obj)
        {
            return (obj is Order order) && (id == order.id);
        }
    }
}
