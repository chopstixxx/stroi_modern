using Microsoft.VisualBasic.Logging;
using Npgsql;
using NpgsqlTypes;
using Org.BouncyCastle.Utilities;
using stroi_modern;
using System.Data;
using System.Windows.Forms;

namespace document_oborot
{
    public partial class Auth_form : Form
    {
        int auth_count = 0;
        DateTime end_locktime;
        public Auth_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string login = textBox1.Text;
            string password = textBox2.Text;
            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("���� ������ ������!");
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("���� ������ ������!");
                return;
            }




            DB dB = new DB();

            using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter($"SELECT * from users WHERE login = @login", dB.Get_conn()))
            {
                dataAdapter.SelectCommand.Parameters.AddWithValue("@login", login);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    if (check_password(password) == true)
                    {


                        Check_role(login, password);
                        auth_count = 0;
                    }
                    else
                    {
                        if (auth_count >= 2)
                        {
                            end_locktime = DateTime.Now.AddSeconds(30);
                            button1.Enabled = false;
                            timer1.Start();
                        }
                        MessageBox.Show("������������ ������!");
                        auth_count++;
                    }

                }
                else
                {
                    MessageBox.Show("������������ �� ����������!");
                }




            }

        }
        private bool check_password(string password)
        {
            DB dB = new DB();
            using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter($"SELECT * from users WHERE password = @pass", dB.Get_conn()))
            {
                dataAdapter.SelectCommand.Parameters.AddWithValue("@pass", password);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        private void Check_role(string login, string password)
        {

            DB db = new DB();

            db.Open_conn();
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT role_id FROM users WHERE login = @login and password = @pass", db.Get_conn()))
            {
                cmd.Parameters.Add("@login", NpgsqlDbType.Text).Value = login;
                cmd.Parameters.Add("@pass", NpgsqlDbType.Text).Value = password;
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int role_id = reader.GetInt32(reader.GetOrdinal("role_id"));
                        switch (role_id)
                        {
                            case 1:
                            Admin_form form = new Admin_form();
                            form.Show();
                            this.Hide();
                            break;

                            case 2:
                                Manager_from form2 = new Manager_from(login);
                                form2.Show();
                                this.Hide();
                                break;
                        }
                    }
                }

            }




        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }


        private void Auth_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now >= end_locktime)
            {
                timer1.Stop();
                button1.Enabled = true;
                Capcha_form form = new Capcha_form();
                this.Hide();
                form.Show();
            }
        }

        private void Auth_form_Load(object sender, EventArgs e)
        {

        }
    }
}