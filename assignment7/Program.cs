using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //添加数据
            using(var ctx = new BloggingContext())
            {
                //public Goods(string iD, string name, double price)
                //OrderDetail(int index, Goods goods, int quantity) 
                //public Order(int orderId, Customer customer, List<OrderDetail> items)

                Goods good1 = new Goods("00001", "apple", 12.01);

                OrderDetail orderdetail1 = new OrderDetail(001, good1, 20);

                List<OrderDetail> orderlist = new List<OrderDetail>();

                Customer cus1 = new Customer("00123", "Jessie");


                Order order1 = new Order(001, cus1, orderlist);

                OrderService orderservice = new OrderService();

                ctx.Order.Add(order1);
                ctx.Goods.Add(good1);
                ctx.OrderDetail.Add(orderdetail1);
                ctx.Customer.Add(cus1);
                ctx.OrderService.Add(orderservice);
                ctx.SaveChanges();
            }

            //删除id为001的数据（先查询后删除）
            using(var context = new BloggingContext())
            {
                var order = context.Order.FirstOrDefault(p => p.OrderID == 001);
                if(order != null)
                {
                    context.Order.Remove(order);
                    context.SaveChanges();
                }
            }

            //删除id为001的数据及其相关内容
            using(var context = new BloggingContext())
            {
                var order = context.Order.Include("Order").FirstOrDefault(p => p.OrderID == 001);
                if(order != null)
                {
                    context.Order.Remove(order);
                    context.SaveChanges();
                }
            }

            //更新
            using (var context = new BloggingContext())
            {
                var order = context.Order.FirstOrDefault(p => p.OrderID == 001);
                if(order != null)
                {
                    Customer cus2 = new Customer("00234", "Lily");
                    order.Customer = cus2;
                }
                context.Entry(order).State = EntityState.Modified;
                context.SaveChanges();
            }

            //查询（单表）
            using(var context = new BloggingContext())
            {
                var order = context.Order
                .SingleOrDefault(b => b.OrderID == 001);
                if (order != null) Console.WriteLine(order.CustomerName);
            }

            //查询评分大于1（单表）
            using (var db = new BloggingContext())
            {
                var query = db.Order
                .Where(b => b.OrderID == 001)
                .OrderBy(b => b.CustomerName);
                foreach (var b in query)
                {
                    Console.WriteLine(b.OrderID);
                }
            }

            //查询（多表）
            using (var db = new BloggingContext())
            {
                var query = db.Order.Where(p => p.CustomerName == "Lily").OrderBy(p => p.OrderID);
                foreach(var p in query)
                {
                    Console.WriteLine(p.CustomerName);
                }
                
            }

            //查询（多表）
            using (var db = new BloggingContext())
            {
                //Include（）
                var query = db.Order.Include("Order")
                .Where(b => b.OrderID == 001)
                .OrderBy(b => b.CustomerName);
                foreach (var b in query)
                {
                    Console.WriteLine(b.OrderID);
                }
            }

            //分页查询
            int currentPage = 2;
            int pageSize = 10;

            using (var db = new BloggingContext())
            {
                //Include（）
                var users = db.Order.OrderBy(p => p.CustomerName).Skip((currentPage - 1) * pageSize).Take(pageSize);
            }

        }
    }
}
