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
    public partial class FormDetailEdit : Form
    {
        public OrderDetail Detail { get; set; }
        public FormDetailEdit()
        {
            InitializeComponent();
        }


        public FormDetailEdit(OrderDetail detail) : this()
        {
            this.Detail = detail;
            this.bdsDetail.DataSource = detail;
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

