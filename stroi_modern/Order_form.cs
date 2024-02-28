using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
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
    public partial class Order_form : Form
    {
        public List<Product> CartList = new List<Product>();
        private int final_price;
        private string login;


        public Order_form(List<Product> CartList_, int final_price_, string login_)
        {
            InitializeComponent();
            CartList = CartList_;
            login = login_;
            final_price = final_price_;
        }

        private void cart_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(full_name.Text))
            {
                MessageBox.Show("Введите ФИО!");
                return;
            }
            if (string.IsNullOrEmpty(adress_of_building.Text))
            {
                MessageBox.Show("Введите адрес!");
                return;

            }
            DB dB = new DB();
            int user_id = dB.Get_user_id(login);
            DB dB1 = new DB();
            int order_id = dB1.Order_create(user_id, full_name.Text, adress_of_building.Text, final_price);

            foreach (var product in CartList)
            {
                DB dB2 = new DB();
                dB2.Order_products_create(order_id, product.Id, product.Count);
            }
            Create_pdf_doc();
            this.Hide();
            Manager_from form = new Manager_from(login);
            form.Show();
        }

        private void Create_pdf_doc()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string dest = saveFileDialog.FileName;

                using (var writer = new PdfWriter(dest))
                {
                    using (var pdf = new PdfDocument(writer))
                    {
                        var document = new Document(pdf);

                        // Установка шрифта
                        PdfFont font = PdfFontFactory.CreateFont(@"C:\Windows\Fonts\Arial.ttf", PdfEncodings.IDENTITY_H);

                        // Добавление компании и надписи "ЧЕК"
                        Paragraph header = new Paragraph("Компания ООО \"СтройМодерн\"").SetTextAlignment(TextAlignment.RIGHT).SetFont(font);
                        Paragraph title = new Paragraph("ЧЕК").SetTextAlignment(TextAlignment.CENTER).SetFont(font);
                        document.Add(header);
                        document.Add(title);

                        // Создание таблицы
                        Table table = new Table(4);
                        Cell[] headerCells = new Cell[] {
                            new Cell().Add(new Paragraph("Название товара").SetFont(font)),
                            new Cell().Add(new Paragraph("Кол-во").SetFont(font)),
                            new Cell().Add(new Paragraph("Цена").SetFont(font)),
                            new Cell().Add(new Paragraph("Итоговая сумма").SetFont(font))
                        };

                        foreach (Cell cell in headerCells)
                        {
                            table.AddHeaderCell(cell);
                        }

                        // Заполнение таблицы данными
                        foreach (var product in CartList)
                        {
                            table.AddCell(new Cell().Add(new Paragraph(product.Name).SetFont(font)));
                            table.AddCell(new Cell().Add(new Paragraph(product.Count.ToString() + " шт.").SetFont(font)));
                            table.AddCell(new Cell().Add(new Paragraph(product.Price.ToString() + "₽").SetFont(font)));
                            table.AddCell(new Cell().Add(new Paragraph((product.Count * product.Price).ToString() + "₽").SetFont(font)));
                        }

                        // Добавление таблицы и итоговой суммы
                        document.Add(table);
                        document.Add(new Paragraph("Итого: " + final_price + "₽").SetFont(font));
                    }
                }

                MessageBox.Show("Заказ успешно оформлен!");
            }
        }
        private void Order_form_Load(object sender, EventArgs e)
        {
            login_lbl.Text = login;
        }

        private void Order_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
