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
    // FormOrder 窗体类，用于添加或编辑订单
    public partial class FormOrder : Form
    {
        // 订单服务对象，用于操作订单数据
        private OrderService orderService;

        // 表明当前是否为编辑模式
        public bool EditModel { get; set; }

        // 当前正在编辑或创建的订单
        public Order CurrentOrder { get; set; }

        // 关闭编辑窗体时触发的事件
        public event Action<FormOrder> CloseEditFrom;

        public FormOrder(Order order, bool model, OrderService orderService)
        {
            InitializeComponent(); // 初始化窗体组件

            // 事件订阅为空，需要适当实现
            CloseEditFrom += (f => { });

            // 初始化成员变量
            this.orderService = orderService;
            this.EditModel = model;

            // 为下拉列表添加客户数据（这应该从数据库或其他数据源加载）
            bdsCustomers.Add(new Customer("1", "li"));
            bdsCustomers.Add(new Customer("2", "zhang"));

            // 如果需要实现深克隆，以下代码需要替换为一个深克隆的实现
            order.Customer = bdsCustomers.Current as Customer;
            this.CurrentOrder = order;
            bdsOrders.DataSource = CurrentOrder;

            // 设置文本框是否启用，基于当前是否为编辑模式
            textBox1.Enabled = !model;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 创建并显示订单详情编辑窗体
            FormDetailEdit formItemEdit = new FormDetailEdit(new OrderDetail());
            try
            {
                // 如果用户在订单详情编辑窗体中点击OK，添加新的订单详情到当前订单
                if (formItemEdit.ShowDialog() == DialogResult.OK)
                {
                    int index = 0;
                    if (CurrentOrder.Details.Count != 0)
                    {
                        // 获取当前最高的订单项索引并加1，用于新的订单项
                        index = CurrentOrder.Details.Max(i => i.Index) + 1;
                    }
                    formItemEdit.Detail.Index = index;
                    CurrentOrder.AddItem(formItemEdit.Detail);
                    bdsDetails.ResetBindings(false); // 刷新数据绑定，以更新界面
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message); // 异常处理
            }
        }

        private void EditDetail()
        {
            // 获取当前选中的订单详情
            OrderDetail detail = bdsDetails.Current as OrderDetail;
            if (detail == null)
            {
                MessageBox.Show("请选择需要修改的订单");
                return;
            }
            // 创建并显示订单详情编辑窗体
            FormDetailEdit formDetailEdit = new FormDetailEdit(detail);
            if (formDetailEdit.ShowDialog() == DialogResult.OK)
            {
                bdsDetails.ResetBindings(false); // 刷新数据绑定
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditDetail();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 获取当前选中的订单详情
            OrderDetail detail = bdsDetails.Current as OrderDetail;
            if (detail == null)
            {
                MessageBox.Show("请选择需要删除的订单");
                return;
            }
            // 从当前订单中移除选中的订单项
            CurrentOrder.RemoveDetail(detail);
            bdsDetails.ResetBindings(false); // 刷新数据绑定
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // 根据编辑模式决定是更新订单还是添加新订单
                if (this.EditModel)
                {
                    orderService.UpdateOrder(CurrentOrder);
                }
                else
                {
                    orderService.AddOrder(CurrentOrder);
                }
                CloseEditFrom(this); // 触发关闭编辑窗体的事件
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message); // 异常处理
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
