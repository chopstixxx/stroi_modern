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
    public partial class Upd_goods : Form
    {
        int id;
        string name;
        long article;
        int price;
        int type_id;
        public Upd_goods(int id_, string name_, long article_, int price_, int type_id_)
        {
            InitializeComponent();
            id = id_;
            name = name_;
            article = article_;
            price = price_;
            type_id = type_id_;
        }

        private void Upd_goods_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Стройматериалы");
            comboBox1.Items.Add("Предметы интерьера");

            if (type_id == 1)
            {
                comboBox1.SelectedIndex = 0; // Выбираем "Стройматериалы"
            }
            else if (type_id == 2)
            {
                comboBox1.SelectedIndex = 1; // Выбираем "Предметы интерьера"
            }

            name_.Text = name;
            article_.Text = article.ToString();
            price_.Text = price.ToString();
        }

        private void real_acc_create_Click(object sender, EventArgs e)
        {
            string _name = name_.Text;
            string _article = article_.Text;
            string _price = price_.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Введите название!");
                return;
            }

            if (string.IsNullOrEmpty(_article))
            {
                MessageBox.Show("Введите артикул!");
                return;
            }
            if (!long.TryParse(_article, out long articleValue) || _article.Length != 13)
            {
                MessageBox.Show("Неправильный формат артикула!");
                return;
            }
            if (_article.Length != 13)
            {
                MessageBox.Show("Артикул должен содержать 13 символов!");
                return;
            }
            if (string.IsNullOrEmpty(_price))
            {
                MessageBox.Show("Введите цену!");
                return;
            }
            else if (!int.TryParse(_price, out int priceValue))
            {
                MessageBox.Show("Неправильный формат цены!");
                return;
            }
           
            if (Convert.ToString(comboBox1.SelectedItem) == "Стройматериалы")
            {
                type_id = 1;
            }
            else
            {
                type_id = 2;
            }
            DB dB = new DB();
            dB.Product_upd(id, type_id, _name, Convert.ToInt32(_price), Convert.ToInt64(_article));
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            Goods_form form = new Goods_form();
            this.Hide();
            form.Show();
        }

        private void Upd_goods_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
