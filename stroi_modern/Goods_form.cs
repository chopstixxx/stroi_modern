using Npgsql;
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
    public partial class Goods_form : Form
    {
        private const int MaxProductsPerPage = 5;
        private int currentPage = 1;
        private List<Product> productsList = new List<Product>();
        private List<Product> DisplayedProductsList = new List<Product>();
        public Goods_form()
        {
            InitializeComponent();
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            Admin_form form = new Admin_form();
            this.Hide();
            form.Show();
        }

        private void Goods_add_btn_Click(object sender, EventArgs e)
        {
            Goods_add form = new Goods_add();
            this.Hide();
            form.Show();
        }

        private void Goods_form_Load(object sender, EventArgs e)
        {

            sort.Items.Add("Дороже");
            sort.Items.Add("Дешевле");
            sort.Items.Add("По алфавиту (А-Я)");
            sort.Items.Add("По алфавиту (Я-А)");


            filter.Items.Add("Все типы");
            filter.Items.Add("Стройматериалы");
            filter.Items.Add("Предметы интерьера");

            Goods_load();
            DisplayedProductsList = productsList;
            DisplayCurrentPage();

            for (int i = 1; i <= MaxProductsPerPage; i++)
            {
                Panel currentPanel = (Panel)Controls.Find("panel" + i, true)[0];

                // Добавляем обработчик события для щелчка правой кнопкой мыши на каждой панели
                currentPanel.ContextMenuStrip = contextMenuStrip1;


            }
        }
        private void Goods_load()
        {
            DB dB = new DB();
            dB.Open_conn();
            using (var command = new NpgsqlCommand("SELECT * FROM goods", dB.Get_conn()))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Img_name = reader["img_path"].ToString(),
                            Article = Convert.ToInt64(reader["article"]),
                            Name = reader["name"].ToString(),
                            Price = Convert.ToInt32(reader["price"]),
                            Type_id = Convert.ToInt32(reader["type_id"]),
                            Count = 1
                        };
                        productsList.Add(product);
                    }
                }
            }


        }
        private void prev_page_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayCurrentPage();
            }
        }
        private void DisplayCurrentPage()
        {

            int startIndex = (currentPage - 1) * MaxProductsPerPage;
            int endIndex = Math.Min(startIndex + MaxProductsPerPage, DisplayedProductsList.Count);

            for (int i = 1; i <= MaxProductsPerPage; i++)
            {
                Panel currentPanel = (Panel)Controls.Find("panel" + i, true)[0];

                if (i <= endIndex - startIndex)
                {
                    currentPanel.Visible = true;

                    PictureBox pictureBox = (PictureBox)currentPanel.Controls["pic" + i];
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Устанавливаем режим изменения размера изображения
                    string imageName = DisplayedProductsList[startIndex + i - 1].Img_name;
                    pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);


                    Label labelArticul = (Label)currentPanel.Controls["article" + i];
                    labelArticul.Text = DisplayedProductsList[startIndex + i - 1].Article.ToString();

                    Label labelName = (Label)currentPanel.Controls["prod_name" + i];
                    labelName.Text = DisplayedProductsList[startIndex + i - 1].Name;

                    Label labelPrice = (Label)currentPanel.Controls["price" + i];
                    labelPrice.Text = DisplayedProductsList[startIndex + i - 1].Price + "₽";
                }
                else
                {
                    currentPanel.Visible = false;
                }
            }



        }
        private void next_page_Click(object sender, EventArgs e)
        {
            if ((currentPage * MaxProductsPerPage) < DisplayedProductsList.Count)
            {
                currentPage++;
                DisplayCurrentPage();
            }
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            string searchText = search.Text.ToLower();
            DisplayedProductsList = productsList.Where(product =>
                product.Name.ToLower().StartsWith(searchText)).ToList();

            currentPage = 1;

            DisplayCurrentPage();
        }

        private void sort_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSort = sort.SelectedItem.ToString();
            switch (selectedSort)
            {
                case "Дороже":
                    DisplayedProductsList = DisplayedProductsList.OrderByDescending(product => product.Price).ToList();
                    break;
                case "Дешевле":
                    DisplayedProductsList = DisplayedProductsList.OrderBy(product => product.Price).ToList();
                    break;
                case "По алфавиту (А-Я)":
                    DisplayedProductsList = DisplayedProductsList.OrderBy(product => product.Name).ToList();
                    break;
                case "По алфавиту (Я-А)":
                    DisplayedProductsList = DisplayedProductsList.OrderByDescending(product => product.Name).ToList();
                    break;

            }

            DisplayCurrentPage();
        }

        private void filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSort = filter.SelectedItem.ToString();
            switch (selectedSort)
            {
                case "Все типы":
                    DisplayedProductsList = productsList;
                    break;
                case "Стройматериалы":
                    DisplayedProductsList = productsList.Where(product => product.Type_id == 1).ToList();
                    break;
                case "Предметы интерьера":
                    DisplayedProductsList = productsList.Where(product => product.Type_id == 2).ToList();
                    break;


            }

            DisplayCurrentPage();
        }

        private void delete_pos_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Получаем выбранную панель
            Panel selectedPanel = (Panel)contextMenuStrip1.SourceControl;

            // Получаем индекс выбранной панели
            int panelIndex = int.Parse(selectedPanel.Name.Replace("panel", ""));

            // Получаем соответствующий продукт
            Product selectedProduct = DisplayedProductsList[(currentPage - 1) * MaxProductsPerPage + panelIndex - 1];
            DB dB = new DB();
            dB.Product_remove(selectedProduct.Id);
            productsList.Remove(selectedProduct);
            DisplayCurrentPage();
        }

        private void remaster_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel selectedPanel = (Panel)contextMenuStrip1.SourceControl;

            // Получаем индекс выбранной панели
            int panelIndex = int.Parse(selectedPanel.Name.Replace("panel", ""));

            // Получаем соответствующий продукт
            Product selectedProduct = DisplayedProductsList[(currentPage - 1) * MaxProductsPerPage + panelIndex - 1];

            Upd_goods form = new Upd_goods(selectedProduct.Id,selectedProduct.Name,selectedProduct.Article,selectedProduct.Price,selectedProduct.Type_id);
            this.Hide();
            form.Show();
        }

        private void Goods_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
