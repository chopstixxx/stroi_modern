namespace stroi_modern
{
    partial class Upd_goods
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            back_btn = new Button();
            real_acc_create = new Button();
            label2 = new Label();
            comboBox1 = new ComboBox();
            article_lbl = new Label();
            price_ = new TextBox();
            price_lbl = new Label();
            article_ = new TextBox();
            name_lbl = new Label();
            name_ = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // back_btn
            // 
            back_btn.BackColor = Color.FromArgb(192, 192, 0);
            back_btn.Location = new Point(12, 303);
            back_btn.Name = "back_btn";
            back_btn.Size = new Size(245, 26);
            back_btn.TabIndex = 41;
            back_btn.Text = "Назад";
            back_btn.UseVisualStyleBackColor = false;
            back_btn.Click += back_btn_Click;
            // 
            // real_acc_create
            // 
            real_acc_create.BackColor = Color.FromArgb(192, 192, 0);
            real_acc_create.Location = new Point(12, 246);
            real_acc_create.Name = "real_acc_create";
            real_acc_create.Size = new Size(245, 51);
            real_acc_create.TabIndex = 40;
            real_acc_create.Text = "Обновить";
            real_acc_create.UseVisualStyleBackColor = false;
            real_acc_create.Click += real_acc_create_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 189);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 39;
            label2.Text = "Тип товара";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 207);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(245, 23);
            comboBox1.TabIndex = 38;
            // 
            // article_lbl
            // 
            article_lbl.AutoSize = true;
            article_lbl.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point);
            article_lbl.Location = new Point(12, 143);
            article_lbl.Name = "article_lbl";
            article_lbl.Size = new Size(35, 15);
            article_lbl.TabIndex = 37;
            article_lbl.Text = "Цена";
            // 
            // price_
            // 
            price_.Location = new Point(12, 161);
            price_.Name = "price_";
            price_.Size = new Size(245, 23);
            price_.TabIndex = 36;
            // 
            // price_lbl
            // 
            price_lbl.AutoSize = true;
            price_lbl.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point);
            price_lbl.Location = new Point(12, 93);
            price_lbl.Name = "price_lbl";
            price_lbl.Size = new Size(54, 15);
            price_lbl.TabIndex = 35;
            price_lbl.Text = "Артикул";
            // 
            // article_
            // 
            article_.Location = new Point(12, 111);
            article_.MaxLength = 13;
            article_.Name = "article_";
            article_.Size = new Size(245, 23);
            article_.TabIndex = 34;
            // 
            // name_lbl
            // 
            name_lbl.AutoSize = true;
            name_lbl.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point);
            name_lbl.Location = new Point(12, 45);
            name_lbl.Name = "name_lbl";
            name_lbl.Size = new Size(59, 15);
            name_lbl.TabIndex = 33;
            name_lbl.Text = "Название";
            // 
            // name_
            // 
            name_.Location = new Point(12, 63);
            name_.Name = "name_";
            name_.Size = new Size(245, 23);
            name_.TabIndex = 32;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 7);
            label1.Name = "label1";
            label1.Size = new Size(222, 26);
            label1.TabIndex = 31;
            label1.Text = "Обновление товара";
            // 
            // Upd_goods
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 128);
            ClientSize = new Size(269, 337);
            Controls.Add(back_btn);
            Controls.Add(real_acc_create);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(article_lbl);
            Controls.Add(price_);
            Controls.Add(price_lbl);
            Controls.Add(article_);
            Controls.Add(name_lbl);
            Controls.Add(name_);
            Controls.Add(label1);
            Name = "Upd_goods";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Обновление товара";
            FormClosing += Upd_goods_FormClosing;
            Load += Upd_goods_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button back_btn;
        private Button real_acc_create;
        private Label label2;
        private ComboBox comboBox1;
        private Label article_lbl;
        private TextBox price_;
        private Label price_lbl;
        private TextBox article_;
        private Label name_lbl;
        private TextBox name_;
        private Label label1;
    }
}