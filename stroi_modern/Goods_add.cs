using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;


namespace stroi_modern
{
    public partial class Goods_add : Form
    {
        bool index_change = false;
        int goods_type;
        public Goods_add()
        {
            InitializeComponent();
        }

        private void Goods_add_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void acc_create_Click(object sender, EventArgs e)
        {

        }

        private void real_acc_create_Click(object sender, EventArgs e)
        {
            string name = name_.Text;
            string article = article_.Text;
            string price = price_.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Введите название!");
                return;
            }

            if (string.IsNullOrEmpty(article))
            {
                MessageBox.Show("Введите артикул!");
                return;
            }
            if (!long.TryParse(article, out long articleValue) || article.Length != 13)
            {
                MessageBox.Show("Неправильный формат артикула!");
                return;
            }
            if (article.Length != 13)
            {
                MessageBox.Show("Артикул должен содержать 13 символов!");
                return;
            }
            if (string.IsNullOrEmpty(price))
            {
                MessageBox.Show("Введите цену!");
                return;
            }
            else if (!int.TryParse(price, out int priceValue))
            {
                MessageBox.Show("Неправильный формат цены!");
                return;
            }
            if (!index_change)
            {
                MessageBox.Show("Выберите пункт тип товара!");
                return;
            }
            if (Convert.ToString(comboBox1.SelectedItem) == "Стройматериалы")
            {
                goods_type = 1;
            }
            else
            {
                goods_type = 2;
            }
            DB dB = new DB();
            dB.Product_add(goods_type, name, Convert.ToInt32(price), Convert.ToInt64(article));


        }

        private void Goods_add_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Стройматериалы");
            comboBox1.Items.Add("Предметы интерьера");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index_change = true;
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            Goods_form form = new Goods_form();
            this.Hide();
            form.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void article_lbl_Click(object sender, EventArgs e)
        {
        }

        private void price__TextChanged(object sender, EventArgs e)
        {
        }

        private void price_lbl_Click(object sender, EventArgs e)
        {
        }

        private void article__TextChanged(object sender, EventArgs e)
        {
        }

        private void name_lbl_Click(object sender, EventArgs e)
        {
        }

        private void name__TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
