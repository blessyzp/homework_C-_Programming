using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_calculator_WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //准备数据输入
        string str = "", s = "";
        double a = 0.0, b = 0.0, c=0.0;



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            str = this.comboBox1.Text;


            if (str == null)
            {
                MessageBox.Show("SelectedValue is null.");
                str = "";
            }

            switch (str)
            {
                case "+":
                    c = a + b;
                    break;
                case "-":
                    c = a - b;
                    break;
                case "*":
                    c = a * b;
                    break;
                case "/":
                    c = a / b;
                    break;
                case "**":
                    c = Math.Pow(a, b);
                    break;
                default: break;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            while (true)
            {
                s = textBox1.Text;
                if (s == "")
                    a = 0.0;
                else a = System.Convert.ToDouble(s);
                break;

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            while (true)
            {
                s = textBox2.Text;
                if (s == "")
                    b = 0.0;
                else b = System.Convert.ToDouble(s);
                break;

            }
        }
        private void button1_Click(object sender, EventArgs e)

        {
            comboBox1_SelectedIndexChanged(sender, e);
            while (str == "/" && b == 0)
            {
                MessageBox.Show("The input is invalid. Please input the number b and operator again: ");
                s = textBox2.Text;
                b = Double.Parse(s);
                comboBox1_SelectedIndexChanged(sender, e);
            }

            textBox3.Text = c.ToString();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
