using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment5
{
    internal class OrderService
    {
        public List<Order> orderlist = new List<Order>();//存储order的list

        public void Add(Order newOrder)
        {
            if (newOrder == null) throw new ArgumentNullException("The order is null!");
            if (orderlist.Contains(newOrder)) throw new ArgumentNullException("The order already exists!");
            orderlist.Add(newOrder);
            Console.WriteLine("the order has been added successfully!");
            
        }

        public void delete(int id)
        {
            if (id == null) throw new ArgumentNullException("The id of the order to be deleted is null!");
            Order order = orderlist.FirstOrDefault(o => o.id == id);
            if(order == null)
            {
                orderlist.Remove(order);
                Console.WriteLine("the order has been deleted successfully!");
            }
            else Console.WriteLine("the order can be found!");


        }

        public void change(Order order)
        {
            /*            if (id == null) throw new ArgumentNullException("The id is null!");
                        Console.WriteLine("Which one do you want to change? \n 1.client; \n 2.money \n 3.orderdetails");

                        string choose = "";
                        choose = Console.ReadLine();

                        switch (choose)
                        {
                            case "1":
                                Console.WriteLine("What's the new client's name?");
                                string name = Console.ReadLine();
                                if (name == null) throw new ArgumentNullException("The name is null!");
                                orderlist[id].client.name = name;
                        }
            */

            if (order == null) throw new ArgumentNullException("The order is null!");
            orderlist[order.id] = order;
            Console.WriteLine("The order has been changed successfully!");

        }

/*        public void searchOrderId( int id)
        {
            if(id == null) throw new ArgumentNullException("The id is null!");
            var selected = from n in orderlist
                             where n.id == id
                             select n;
            if(selected == null)Console.WriteLine("The order id is not founded!");
            //展示订单
            else selected.showOrder()
        }

        //按商品名称
        public void searchOrderName(string name)
        {
            if (name == null) throw new ArgumentNullException("The name is null!");
            var selectedId = from n in orderlist.
                             where n.detailList. == id
                             select n;
            if (selectedId == null) Console.WriteLine("The order id is not founded!");
        }

        //按客户名称
        public void searchClient(Client client)
        {
            if (client == null) throw new ArgumentNullException("The client is null!");
            var selectedId = from n in orderlist
                             where n.client == client
                             select n;
            if (selectedId == null) Console.WriteLine("The order id is not founded!");
        }*/

        //按id查询
        public Order searchId(int id)
        {
            return orderlist.FirstOrDefault(o => o.id == id);
        }
        //按商品名称查询
        public List<Order> searchName(string name)
        {
            return orderlist.Where(o => o.detailList.Any(d => d.commdityName == name)).OrderBy(o =>o.money).ToList();
        }
        //按客户查询
        public List<Order> searchClient(string client)
        {
            return orderlist.Where(o => o.client == client).OrderBy(o => o.money).ToList();
        }
        //按订单金额
        public List<Order> searchMoney(double money)
        {
            return orderlist.Where(o => o.money == money).OrderBy(o => o.id).ToList();
        }

        //排序
        public void sortOrder(Func<Order,object> key)
        {
            orderlist = orderlist.OrderBy(key).ToList();
        }
    }
}
