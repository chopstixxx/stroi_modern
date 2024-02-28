using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stroi_modern
{
    public partial class Admin_form : Form
    {
        public Admin_form()
        {
            InitializeComponent();
        }

        private void cart_btn_Click(object sender, EventArgs e)
        {
            Add_acc_form form = new Add_acc_form();
            this.Hide();
            form.Show();
        }

        private void Admin_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void goods_btn_Click(object sender, EventArgs e)
        {
            Goods_form form = new Goods_form();
            this.Hide();
            form.Show();
        }
    }
}
