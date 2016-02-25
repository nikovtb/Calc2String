using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc2String
{
    public partial class Form1 : Form
    {
        public string str;
        bool isPushedDec = false;
        public Form1()
        {
            InitializeComponent();
        }

        //private void bt1_Click(object sender, EventArgs e)
        //{
        //    Button bt = (Button)sender;

        //    textBox.Text = textBox.Text + bt.Text;
            
        //}
        private void bt_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;

            textBox.Text = textBox.Text + bt.Text;

        }

        private void btDec_Click(object sender, EventArgs e)
        {
            if (!isPushedDec)
            {
                Button bt = (Button)sender;

                textBox.Text = textBox.Text + bt.Text;

                isPushedDec = true;
            }


        }
    }
}
