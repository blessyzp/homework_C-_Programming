using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment5
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void AddTest()
        {
            OrderService orderservice = new OrderService();
            List<OrderDetails> orderlist = new List<OrderDetails>();
            OrderDetails orderdetails = new OrderDetails("wuping", 20, 10.00);
            orderlist.Add(orderdetails);
            Order order = new Order(1, "ZhangSan", orderlist);

            //Add
            orderservice.Add(order);

            //Assert
            Assert.AreEqual(1, orderservice.searchName("ZhangSan").Count);
        }

        [TestMethod()]
        public void deleteTest()
        {
            OrderService orderservice = new OrderService();
            List<OrderDetails> orderlist = new List<OrderDetails>();
            OrderDetails orderdetails = new OrderDetails("wuping", 20, 10.00);
            orderlist.Add(orderdetails);
            Order order = new Order(1, "ZhangSan", orderlist);

            //Add
            orderservice.Add(order);

            //delete
            orderservice.delete(order.id);

            //Assert
            Assert.AreEqual(0, orderservice.searchName("ZhangSan").Count);
        }

        [TestMethod()]
        public void changeTest()
        {
            OrderService orderservice = new OrderService();
            List<OrderDetails> orderlist = new List<OrderDetails>();
            OrderDetails orderdetails = new OrderDetails("wuping", 20, 10.00);
            orderlist.Add(orderdetails);
            Order order = new Order(1, "ZhangSan", orderlist);

            //Add
            orderservice.Add(order);


            //change
            OrderDetails orderdetails_new = new OrderDetails("wuping_new", 5, 5.00);
            orderlist[0] = (orderdetails_new);
            Order order_new = new Order(1, "LiSi", orderlist);
            orderservice.change(order_new);

            //Assert
            Order answer = orderservice.searchId(1);
            Assert.AreEqual("LiSi", answer.client);
            Assert.AreEqual("wuping_new", answer.detailList[0].commdityName);
        }

        [TestMethod()]
        public void searchIdTest()
        {
            OrderService orderservice = new OrderService();
            List<OrderDetails> orderlist = new List<OrderDetails>();
            OrderDetails orderdetails = new OrderDetails("wuping", 20, 10.00);
            orderlist.Add(orderdetails);
            Order order = new Order(1, "ZhangSan", orderlist);

            //Add
            orderservice.Add(order);


            //search
            Order orderId = orderservice.searchId(1);

            //Assert
            Assert.AreEqual(order, orderId);
        }


        [TestMethod()]
        public void searchNameTest()
        {
            OrderService orderservice = new OrderService();
            List<OrderDetails> orderlist1 = new List<OrderDetails>();
            OrderDetails orderdetails = new OrderDetails("wuping", 20, 10.00);
           
            List<OrderDetails> orderlist2 = new List<OrderDetails>();
            OrderDetails orderdetails2 = new OrderDetails("books", 5, 15.00);
            
            orderlist1.Add(orderdetails);
            orderlist2.Add(orderdetails2);
            Order orderOne = new Order(1, "ZhangSan", orderlist1);
            Order orderTwo = new Order(2, "ZhangSan", orderlist2);

            //Add
            orderservice.Add(orderOne);
            orderservice.Add(orderTwo);


            //search
            List<Order> orderName = orderservice.searchName("books");


            //Assert
            List<Order> anOrder = new List<Order>();
            anOrder.Add(orderTwo);

            Assert.AreEqual(anOrder, orderName);
        }



        [TestMethod()]
        public void searchClientTest()
        {
            OrderService orderservice = new OrderService();
            List<OrderDetails> orderlist = new List<OrderDetails>();
            OrderDetails orderdetails = new OrderDetails("wuping", 20, 10.00);
            orderlist.Add(orderdetails);
            Order orderOne = new Order(1, "ZhangSan", orderlist);
            Order orderTwo = new Order(2, "ZhangSan", orderlist);

            //Add
            orderservice.Add(orderOne);
            orderservice.Add(orderTwo);


            //search
            List<Order> orderName = orderservice.searchName("ZhangSan");


            //Assert
            List<Order> anOrder = new List<Order>();
            anOrder.Add(orderOne);
            anOrder.Add(orderTwo);

            Assert.AreEqual(anOrder,orderName);
        }


        [TestMethod()]
        public void searchMoneyTest()
        {
            OrderService orderservice = new OrderService();
            List<OrderDetails> orderlist1 = new List<OrderDetails>();
            OrderDetails orderdetails = new OrderDetails("wuping", 20, 10.00);

            List<OrderDetails> orderlist2 = new List<OrderDetails>();
            OrderDetails orderdetails2 = new OrderDetails("books", 5, 15.00);

            orderlist1.Add(orderdetails);
            orderlist2.Add(orderdetails2);
            Order orderOne = new Order(1, "ZhangSan", orderlist1);
            Order orderTwo = new Order(2, "ZhangSan", orderlist2);

            //Add
            orderservice.Add(orderOne);
            orderservice.Add(orderTwo);


            //search
            List<Order> orderMoney = orderservice.searchMoney(75.00);


            //Assert
            List<Order> anOrder = new List<Order>();
            anOrder.Add(orderTwo);

            Assert.AreEqual(anOrder, orderMoney);
        }



        [TestMethod()]
        public void sortOrderTest()
        {
            OrderService orderservice = new OrderService();
            List<OrderDetails> orderlist1 = new List<OrderDetails>();
            OrderDetails orderdetails = new OrderDetails("wuping", 20, 10.00);

            List<OrderDetails> orderlist2 = new List<OrderDetails>();
            OrderDetails orderdetails2 = new OrderDetails("books", 5, 15.00);

            orderlist1.Add(orderdetails);
            orderlist2.Add(orderdetails2);
            Order orderOne = new Order(1, "ZhangSan", orderlist1);
            Order orderTwo = new Order(2, "ZhangSan", orderlist2);

            //Add
            orderservice.Add(orderOne);
            orderservice.Add(orderTwo);


            //search
            orderservice.sortOrder(o => o.money);

            //Assert
            Assert.AreEqual(75, orderservice.orderlist[0].money);
            Assert.AreEqual(200, orderservice.orderlist[1].money);

        }
    }



}
