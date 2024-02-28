namespace stroi_modern
{
    partial class Admin_form
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
            admin_btn = new Button();
            goods_btn = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // admin_btn
            // 
            admin_btn.BackColor = Color.FromArgb(192, 192, 0);
            admin_btn.Location = new Point(9, 51);
            admin_btn.Name = "admin_btn";
            admin_btn.Size = new Size(366, 34);
            admin_btn.TabIndex = 9;
            admin_btn.Text = "Администрирование";
            admin_btn.UseVisualStyleBackColor = false;
            admin_btn.Click += cart_btn_Click;
            // 
            // goods_btn
            // 
            goods_btn.BackColor = Color.FromArgb(192, 192, 0);
            goods_btn.Location = new Point(9, 91);
            goods_btn.Name = "goods_btn";
            goods_btn.Size = new Size(366, 34);
            goods_btn.TabIndex = 11;
            goods_btn.Text = "Товары";
            goods_btn.UseVisualStyleBackColor = false;
            goods_btn.Click += goods_btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(56, 9);
            label1.Name = "label1";
            label1.Size = new Size(275, 26);
            label1.TabIndex = 12;
            label1.Text = "Панель администратора";
            // 
            // Admin_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 128);
            ClientSize = new Size(387, 132);
            Controls.Add(label1);
            Controls.Add(goods_btn);
            Controls.Add(admin_btn);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Admin_form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Панель администратора";
            FormClosing += Admin_form_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button admin_btn;
        private Button goods_btn;
        private Label label1;
    }
}