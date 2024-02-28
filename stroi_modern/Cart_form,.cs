using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stroi_modern
{
    public partial class Cart_form : Form
    {
        public List<Product> CartList = new List<Product>();
        private Manager_from form;
        private int final_price_;
        private string login;
        public Cart_form(List<Product> CartList_, Manager_from form_)
        {
            InitializeComponent();
            CartList = CartList_;
            form = form_;
        }

        private void Cart_form_Load(object sender, EventArgs e)
        {
            login = form.login;
            login_lbl.Text = login;
            Cart_goods_load();


            for (int i = 1; i <= 5; i++)
            {
                Panel currentPanel = (Panel)Controls.Find("panel" + i, true)[0];

                // Добавляем обработчик события для щелчка правой кнопкой мыши на каждой панели
                currentPanel.ContextMenuStrip = contextMenuStrip1;


            }
        }

        private void Cart_goods_load()
        {
            for (int i = 1; i <= 5; i++)
            {
                Panel currentPanel = (Panel)Controls.Find("panel" + i, true)[0];

                if (i <= CartList.Count)
                {
                    currentPanel.Visible = true;

                    PictureBox pictureBox = (PictureBox)currentPanel.Controls["pic" + i];
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Устанавливаем режим изменения размера изображения
                    string imageName = CartList[i - 1].Img_name;
                    pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);



                    Label labelName = (Label)currentPanel.Controls["prod_name" + i];
                    labelName.Text = CartList[i - 1].Name;

                    Label labelPrice = (Label)currentPanel.Controls["price" + i];
                    int price = CartList[i - 1].Price;
                    labelPrice.Text = price + "₽";


                    Label labelCount = (Label)currentPanel.Controls["count" + i];
                    int count = CartList[i - 1].Count;
                    labelCount.Text = count + "шт.";

                    final_price_ += price * count;
                    final_price.Text = string.Format("Итого: {0}₽", final_price_);

                }
                else
                {
                    currentPanel.Visible = false;
                }
            }
        }
        private void Cart_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            form.Show();
            this.Hide();
        }

        private void remove_ТоварToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Получаем выбранную панель
            Panel selectedPanel = (Panel)contextMenuStrip1.SourceControl;

            // Получаем индекс выбранной панели
            int panelIndex = int.Parse(selectedPanel.Name.Replace("panel", ""));

            // Получаем соответствующий продукт
            Product selectedProduct = CartList[panelIndex - 1];

            CartList.Remove(selectedProduct);
            if (CartList.Count < 1)
            {
                form.Show();
                this.Hide();
            }
            else
            {
                final_price_ = 0;
                Cart_goods_load();
            }

        }

        private void add_1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Получаем выбранную панель
            Panel selectedPanel = (Panel)contextMenuStrip1.SourceControl;

            // Получаем индекс выбранной панели
            int panelIndex = int.Parse(selectedPanel.Name.Replace("panel", ""));

            // Получаем соответствующий продукт
            Product selectedProduct = CartList[panelIndex - 1];

            selectedProduct.Count++;
            final_price_ = 0;
            Cart_goods_load();
        }

        private void cart_btn_Click(object sender, EventArgs e)
        {
            Order_form form = new Order_form(CartList, final_price_, login);
            form.Show();
            this.Hide();
        }
    }
}
