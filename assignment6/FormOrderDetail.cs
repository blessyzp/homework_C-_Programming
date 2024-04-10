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
    //FormDetailEdit 窗体用于编辑订单详情
    public partial class FormDetailEdit : Form
    {
        // 公开属性Detail，用于外部访问和设置当前正在编辑的订单详情
        public OrderDetail Detail { get; set; }

        // 默认构造函数，初始化窗体组件
        public FormDetailEdit()
        {
            InitializeComponent();
        }

        // 带参数的构造函数，用于初始化窗体时传入一个订单详情对象
        public FormDetailEdit(OrderDetail detail) : this()
        {
            this.Detail = detail; // 设置当前编辑的订单详情对象
            this.bdsDetail.DataSource = detail; // 将订单详情对象绑定到数据源，用于数据绑定

            // 向数据源bdsGoods添加商品数据
            // 注意：这里硬编码了商品数据，实际应用中，这些数据应该从数据库或其他数据源加载
            bdsGoods.Add(new Goods("1", "milk", 100.0));
            bdsGoods.Add(new Goods("2", "books", 200.0));
            bdsGoods.Add(new Goods("3", "glasses", 200.0));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // 如果是通过 ShowDialog() 显示的，则这将关闭表单
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormDetailEdit_Load(object sender, EventArgs e)
        {

        }
    }
}

