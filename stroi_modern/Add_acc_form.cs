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
    public partial class Add_acc_form : Form
    {
        public Add_acc_form()
        {
            InitializeComponent();
        }

        private void acc_create_Click(object sender, EventArgs e)
        {
            string login = login_.Text;
            if(string.IsNullOrEmpty(login) )
            {
                MessageBox.Show("Введите логин!");
                return;
            }
            string pass = pass_.Text;
            if (string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Введите пароль!");
                return;
            }
            DB dB1 = new DB();
            if (!dB1.Login_check(login))
            {
                MessageBox.Show("Логин занят!");
                return;
            }
            DB dB = new DB();
            dB.Account_create(login, pass);
            MessageBox.Show("Пользователь создан!");
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            Admin_form form = new Admin_form();
            this.Hide();
            form.Show();
        }

        private void Add_acc_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
