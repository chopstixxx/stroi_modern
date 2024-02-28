namespace stroi_modern
{
    partial class Add_acc_form
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
            label3 = new Label();
            label2 = new Label();
            pass_ = new TextBox();
            login_ = new TextBox();
            acc_create = new Button();
            back_btn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(289, 26);
            label1.TabIndex = 10;
            label1.Text = "Создание учётной записи";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(12, 100);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 19;
            label3.Text = "Пароль";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 49);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 18;
            label2.Text = "Логин";
            // 
            // pass_
            // 
            pass_.Location = new Point(12, 118);
            pass_.Name = "pass_";
            pass_.Size = new Size(289, 23);
            pass_.TabIndex = 17;
            // 
            // login_
            // 
            login_.Location = new Point(12, 67);
            login_.Name = "login_";
            login_.Size = new Size(289, 23);
            login_.TabIndex = 16;
            // 
            // acc_create
            // 
            acc_create.BackColor = Color.FromArgb(192, 192, 0);
            acc_create.Location = new Point(12, 156);
            acc_create.Name = "acc_create";
            acc_create.Size = new Size(289, 34);
            acc_create.TabIndex = 20;
            acc_create.Text = "Создать";
            acc_create.UseVisualStyleBackColor = false;
            acc_create.Click += acc_create_Click;
            // 
            // back_btn
            // 
            back_btn.BackColor = Color.FromArgb(192, 192, 0);
            back_btn.Location = new Point(12, 196);
            back_btn.Name = "back_btn";
            back_btn.Size = new Size(289, 34);
            back_btn.TabIndex = 21;
            back_btn.Text = "На главную";
            back_btn.UseVisualStyleBackColor = false;
            back_btn.Click += back_btn_Click;
            // 
            // Add_acc_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 128);
            ClientSize = new Size(314, 236);
            Controls.Add(back_btn);
            Controls.Add(acc_create);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pass_);
            Controls.Add(login_);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Add_acc_form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Администрирование";
            FormClosing += Add_acc_form_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label label2;
        private TextBox pass_;
        private TextBox login_;
        private Button acc_create;
        private Button back_btn;
    }
}