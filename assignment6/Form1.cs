using OrderApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderForm
{
    public partial class Form1 : Form
    {
        // 实例化订单服务对象，用于处理订单数据
        OrderService orderService = new OrderService();

        // 关键词属性，用于搜索和查询订单
        public String Keyword { get; set; }

        // 定义一个事件，当需要显示FormOrder编辑表单时触发
        public event Action<FormOrder> ShowEditForm;

        // 构造函数：初始化窗体组件
        public Form1()
        {
            InitializeComponent();
            InitOrders(); // 初始化订单数据
            bdsOrders.DataSource = orderService.GetAllOrders(); // 数据绑定
            textBox1.DataBindings.Add("Context", this, "word"); // 绑定关键词文本框
            ShowEditForm += (formOrder) => formOrder.Show(); // 订阅显示表单事件
        }

        // 初始化订单数据方法
        private void InitOrders()
        {
            // 创建订单示例并添加到服务
            Order order = new Order(1, new Customer("1", "zhang"), new List<OrderDetail>());
            order.AddItem(new OrderDetail(1, new Goods("1", "books", 20.0), 10));
            order.AddItem(new OrderDetail(2, new Goods("2", "milk", 250.0), 61));
            order.AddItem(new OrderDetail(3, new Goods("2", "chocolate", 250.0), 81));
            orderService.AddOrder(order);

            Order order2 = new Order(2, new Customer("2", "zhu"), new List<OrderDetail>());
            order2.AddItem(new OrderDetail(1, new Goods("2", "bread", 200.0), 10));
            orderService.AddOrder(order2);
        }

        // 查询所有订单并刷新绑定的方法
        public void QueryAll()
        {
            bdsOrders.DataSource = orderService.GetAllOrders();
            bdsOrders.ResetBindings(false);
        }

        // 查询按钮点击事件处理
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (comboBox1.SelectedIndex) // 根据下拉框选择的索引执行不同的查询
                {
                    // all
                    case 0: 
                        bdsOrders.DataSource = orderService.GetAllOrders();
                        break;
                    // id
                    case 1: 
                        int id = Convert.ToInt32(Keyword);
                        Order order = orderService.GetOrder(id);
                        List<Order> result = new List<Order>();
                        if (order != null) result.Add(order);
                        bdsOrders.DataSource = result;
                        break;
                    // customer
                    case 2: 
                        bdsOrders.DataSource = orderService.QueryOrdersByCustomerName(Keyword);
                        break;
                    // goods
                    case 3: 
                        bdsOrders.DataSource = orderService.QueryOrdersByGoodsName(Keyword);
                        break;
                    // totalprice
                    case 4: 
                        float totalPrice = Convert.ToInt32(Keyword);
                        bdsOrders.DataSource = orderService.QueryByTotalAmount(totalPrice);
                        break;
                }
                bdsOrders.ResetBindings(false); // 刷新数据绑定
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // 异常处理
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // 用于响应订单搜索框文本变化
        }
        // 编辑订单方法
        private void EditOrder()
        {
            Order order = bdsOrders.Current as Order;
            if (order == null)
            {
                MessageBox.Show("请选择需要更新的订单");
                return;
            }
            FormOrder formOrder = new FormOrder(order, true, orderService);
            ShowEditForm(formOrder); // 触发显示编辑表单的事件
        }

        // 新增订单按钮点击事件处理
        private void button2_Click(object sender, EventArgs e)
        {
            // 创建新的订单编辑窗体实例，并显示
            FormOrder formOrder = new FormOrder(new Order(), false, orderService);
            ShowEditForm(formOrder); // 触发显示编辑表单的事件
        }

        // 双击订单列表事件处理
        private void button3_Click(object sender, EventArgs e)
        {
            EditOrder();
        }
        private void dbvOrders_DoubleClick(object sender, EventArgs e)
        {
            EditOrder(); // 调用编辑订单方法
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Order order = bdsOrders.Current as Order;
            if (order == null)
            {
                MessageBox.Show("请选择需要删除的订单");
                return;
            }
            DialogResult result = MessageBox.Show($"确认要删除Id为{order.OrderId}的订单吗？", "删除", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                orderService.RemoveOrder(order.OrderId);
                QueryAll();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fileName = saveFileDialog1.FileName;
                orderService.Export(fileName);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String fileName = openFileDialog1.FileName;
                orderService.Import(fileName);
                QueryAll();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        // 窗体加载事件
        private void Form1_Load(object sender, EventArgs e)
        {
            // 可以放置窗体加载时需要执行的代码
        }
    }
}
