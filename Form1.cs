using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_minus_Click(object sender, EventArgs e)
        {
            this.Text_Lab.Text += " - ";
        }

        private void Btn_0_Click(object sender, EventArgs e)
        {
            this.Text_Lab.Text += "0";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Text_Lab.Text += "1";
        }

        private void Btn_2_Click(object sender, EventArgs e)
        {
            this.Text_Lab.Text += "2";
        }

        private void Btn_3_Click(object sender, EventArgs e)
        {
            this.Text_Lab.Text += "3";
        }

        private void Btn_4_Click(object sender, EventArgs e)
        {
            this.Text_Lab.Text += "4";
        }

        private void Btn_5_Click(object sender, EventArgs e)
        {
            this.Text_Lab.Text += "5";
        }

        private void Btn_6_Click(object sender, EventArgs e)
        {
            this.Text_Lab.Text += "6";
        }

        private void Btn_7_Click(object sender, EventArgs e)
        {
            this.Text_Lab.Text += "7";
        }

        private void Btn_8_Click(object sender, EventArgs e)
        {
            this.Text_Lab.Text += "8";
        }

        private void Btn_9_Click(object sender, EventArgs e)
        {
            this.Text_Lab.Text += "9";
        }

        private void Btn_dot_Click(object sender, EventArgs e)
        {
            this.Text_Lab.Text += ".";
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            this.Text_Lab.Text += " + ";
        }

        private void Btn_multiply_Click(object sender, EventArgs e)
        {
            this.Text_Lab.Text += " * ";
        }

        private void Btn_divide_Click(object sender, EventArgs e)
        {
            this.Text_Lab.Text += " / ";
        }

        private void Btn_equal_Click(object sender, EventArgs e)
        {
            //Calculator_
            Calculator_Fuction cal = new Calculator_Fuction();
            
            Calculator_Fuction.SNode sn = new Calculator_Fuction.SNode();
            sn.Data = new string[100];
            sn.front = 0;
            sn.rear = 0;
            string text = this.Text_Lab.Text;
            sn = cal.WriteIn(text, this.Text_Lab.Text.Length);

            Calculator_Fuction.SNode r = new Calculator_Fuction.SNode();
            r.Data = new string[100];
            r.front = 0;
            r.rear = 0;
            r = cal.MidToRear(sn);
            string te=cal.Operation(r);
            this.Value_Lab.Text = te;

        }

        private void Btn_clean_Click(object sender, EventArgs e)
        {
            this.Text_Lab.Text = "";
            this.Value_Lab.Text = "";
        }

        private void Btn_F_Click(object sender, EventArgs e)
        {
            this.Text_Lab.Text += "( ";
        }

        private void Btn_R_Click(object sender, EventArgs e)
        {
            this.Text_Lab.Text += " )";
            //MessageBox.Show("hello");
        }

        private void Btn_back_Click(object sender, EventArgs e)
        {
            if (this.Text_Lab.Text.Length != 0)
            {
                //Console.WriteLine("{0}", this.Text_Lab.Text.Substring(this.Text_Lab.Text.Length-1));
                if (this.Text_Lab.Text.Substring(this.Text_Lab.Text.Length - 1) == " ")
                {
                    this.Text_Lab.Text = this.Text_Lab.Text.Substring(0, this.Text_Lab.Text.Length - 1);
                }

                string s = this.Text_Lab.Text.Substring(this.Text_Lab.Text.Length - 1);

                if (s == "+" || s == "-" || s == "*" || s == "/" || s == ")")
                {
                    this.Text_Lab.Text = this.Text_Lab.Text.Substring(0, this.Text_Lab.Text.Length - 2);
                }
                else
                {
                    this.Text_Lab.Text = this.Text_Lab.Text.Substring(0, this.Text_Lab.Text.Length - 1);
                }
            }
        }
    }
}
