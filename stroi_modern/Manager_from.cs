using Npgsql;
using System.Drawing.Printing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace stroi_modern
{
    public partial class Manager_from : Form
    {
        private const int MaxProductsPerPage = 5;
        private int currentPage = 1;
        private List<Product> productsList = new List<Product>();
        private List<Product> DisplayedProductsList = new List<Product>();
        public string login;
        public List<Product> CartList = new List<Product>();

        public Manager_from(string login_)
        {
            InitializeComponent();
            login = login_;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            login_lbl.Text = login;



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

        private void prev_page_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayCurrentPage();
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

        private void Manager_from_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }



        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cart_btn.Visible = true;
            // Получаем выбранную панель
            Panel selectedPanel = (Panel)contextMenuStrip1.SourceControl;

            // Получаем индекс выбранной панели
            int panelIndex = int.Parse(selectedPanel.Name.Replace("panel", ""));

            // Получаем соответствующий продукт
            Product selectedProduct = DisplayedProductsList[(currentPage - 1) * MaxProductsPerPage + panelIndex - 1];

            // Проверяем, есть ли уже продукт в корзине
            Product existingProduct = CartList.FirstOrDefault(p => p.Id == selectedProduct.Id);

            if (existingProduct != null)
            {
                // Если продукт уже есть в корзине, увеличиваем счетчик Count
                existingProduct.Count++;
            }
            else
            {
                // Если продукта нет в корзине, добавляем его
                CartList.Add(selectedProduct);
            }


        }

        private void распечататьШтрихкодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel selectedPanel = (Panel)contextMenuStrip1.SourceControl;
            int panelIndex = int.Parse(selectedPanel.Name.Replace("panel", ""));
            Product selectedProduct = DisplayedProductsList[(currentPage - 1) * MaxProductsPerPage + panelIndex - 1];

            string str_arcile = Convert.ToString(selectedProduct.Article);
            Bitmap bitmap = DrawBarcode(str_arcile);


            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PrinterResolution = new PrinterResolution() { X = 20, Y = 20 }; // Установка разрешения печати


            pd.DefaultPageSettings.PaperSize = new PaperSize("Custom", (int)(bitmap.Width / 20 * 100), (int)(bitmap.Height / 20 * 100));

            // Обработчик события печати
            pd.PrintPage += (sender, e) =>
            {

                e.Graphics.DrawImage(bitmap, 0, 0, bitmap.Width / 20 * 100, bitmap.Height / 20 * 100);
            };


            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = pd;

            // Показ предпросмотра печати
            if (printPreviewDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }

            bitmap.Dispose();
        }

        private Bitmap DrawBarcode(string code, int resolution = 20) // resolution - пикселей на миллиметр
        {
            // Параметры для создания изображения
            int numberCount = 13;

            float height = 25.93f * resolution;
            float lineHeight = 22.85f * resolution;
            float leftOffset = 3.63f * resolution;
            float rightOffset = 2.31f * resolution;
            float longLineHeight = lineHeight + 1.65f * resolution;
            float fontHeight = 2.75f * resolution;
            float lineToFontOffset = 0.165f * resolution;
            float lineWidthDelta = 0.15f * resolution;
            float lineWidthFull = 1.35f * resolution;
            float lineOffset = 0.2f * resolution;
            float width = leftOffset + rightOffset + 6 * (lineWidthDelta + lineOffset) + numberCount * (lineWidthFull + lineOffset);

            Bitmap bitmap = new Bitmap((int)width, (int)height);
            Graphics g = Graphics.FromImage(bitmap);
            Font font = new Font("Arial", fontHeight, FontStyle.Regular, GraphicsUnit.Pixel);
            StringFormat fontFormat = new StringFormat();
            fontFormat.Alignment = StringAlignment.Center;
            fontFormat.LineAlignment = StringAlignment.Center;
            float x = leftOffset;



            // Создание штрих-кода
            for (int i = 0; i < numberCount; i++)
            {
                int number = Convert.ToInt32(code[i].ToString());
                if (number != 0)
                {
                    g.FillRectangle(Brushes.Black, x, 0, number * lineWidthDelta, lineHeight);
                }
                RectangleF fontRect = new RectangleF(x, lineHeight + lineToFontOffset, lineWidthFull, fontHeight);
                g.DrawString(code[i].ToString(), font, Brushes.Black, fontRect, fontFormat);
                x += lineWidthFull + lineOffset;

                if (i == 0 || i == numberCount / 2 || i == numberCount - 1)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        g.FillRectangle(Brushes.Black, x, 0, lineWidthDelta, longLineHeight);
                        x += lineWidthDelta + lineOffset;
                    }
                }
            }
            return bitmap;



        }

        private void cart_btn_Click(object sender, EventArgs e)
        {
            Cart_form form = new Cart_form(CartList, this);
            this.Hide();
            form.Show();
        }

        private void Manager_from_Activated(object sender, EventArgs e)
        {
            if (CartList.Count < 1)
            {
                cart_btn.Visible = false;
            }
            else
            {
                cart_btn.Visible = true;
            }
        }
    }



}