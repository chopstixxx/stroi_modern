namespace stroi_modern
{
    partial class Order_form
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
            label1 = new Label();
            full_name = new TextBox();
            adress_of_building = new TextBox();
            label2 = new Label();
            label3 = new Label();
            cart_btn = new Button();
            login_lbl = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(99, 9);
            label1.Name = "label1";
            label1.Size = new Size(228, 26);
            label1.TabIndex = 11;
            label1.Text = "Оформление заказа";
            // 
            // full_name
            // 
            full_name.Location = new Point(12, 59);
            full_name.Name = "full_name";
            full_name.Size = new Size(406, 23);
            full_name.TabIndex = 12;
            // 
            // adress_of_building
            // 
            adress_of_building.Location = new Point(12, 110);
            adress_of_building.Name = "adress_of_building";
            adress_of_building.Size = new Size(406, 23);
            adress_of_building.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 41);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 14;
            label2.Text = "ФИО заказчика";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(12, 92);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 15;
            label3.Text = "Адрес здания";
            // 
            // cart_btn
            // 
            cart_btn.BackColor = Color.FromArgb(192, 192, 0);
            cart_btn.Location = new Point(93, 148);
            cart_btn.Name = "cart_btn";
            cart_btn.Size = new Size(240, 34);
            cart_btn.TabIndex = 16;
            cart_btn.Text = "Оформить заказ";
            cart_btn.UseVisualStyleBackColor = false;
            cart_btn.Click += cart_btn_Click;
            // 
            // login_lbl
            // 
            login_lbl.AutoSize = true;
            login_lbl.Dock = DockStyle.Right;
            login_lbl.Location = new Point(387, 0);
            login_lbl.Name = "login_lbl";
            login_lbl.Size = new Size(40, 15);
            login_lbl.TabIndex = 19;
            login_lbl.Text = "логин";
            // 
            // Order_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 128);
            ClientSize = new Size(427, 194);
            Controls.Add(login_lbl);
            Controls.Add(cart_btn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(adress_of_building);
            Controls.Add(full_name);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Order_form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Оформление заказа";
            FormClosing += Order_form_FormClosing;
            Load += Order_form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox full_name;
        private TextBox adress_of_building;
        private Label label2;
        private Label label3;
        private Button cart_btn;
        private Label login_lbl;
    }
}