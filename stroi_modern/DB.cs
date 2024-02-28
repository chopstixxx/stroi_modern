using Microsoft.VisualBasic.Logging;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace stroi_modern
{
    public class DB
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=stroimodern_db;User Id=postgres;Password=123;");

        public NpgsqlConnection Get_conn()
        { return conn; }
        public void Open_conn()
        { conn.Open(); }

        public int Get_user_id(string login)
        {
            using (conn)
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand($"SELECT id FROM users WHERE login = @login", conn))
                {
                    cmd.Parameters.Add("@login", NpgsqlDbType.Varchar).Value = login;
                    using(NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            int user_id = reader.GetInt32(reader.GetOrdinal("id"));
                            return user_id;
                        }
                        return 0;
                    }

                }
            }
        }
        public int Order_create(int user_id, string full_name, string adress, int final_price)
        {
            using (conn)
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand($"INSERT INTO orders (user_id,customer_fullname,building_adress,final_price) VALUES (@user_id,@full_name,@adress,@final_price) RETURNING id", conn))
                {
                    cmd.Parameters.Add("@user_id", NpgsqlDbType.Integer).Value = user_id;
                    cmd.Parameters.Add("@full_name", NpgsqlDbType.Varchar).Value = full_name;
                    cmd.Parameters.Add("@adress", NpgsqlDbType.Varchar).Value = adress;
                    cmd.Parameters.Add("@final_price", NpgsqlDbType.Integer).Value = final_price;



                    try
                    {
                        int order_id = (int)cmd.ExecuteScalar();
                        return order_id;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return 0;
                    }
                }

            }

        }
        public void Order_products_create(int order_id, int proudct_id, int count)
        {

            using (conn)
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand($"INSERT INTO order_products (order_id, product_id, count) VALUES (@order_id,@product_id,@count) RETURNING id", conn))
                {
                    cmd.Parameters.Add("@order_id", NpgsqlDbType.Integer).Value = order_id;
                    cmd.Parameters.Add("@product_id", NpgsqlDbType.Integer).Value = proudct_id;
                    cmd.Parameters.Add("@count", NpgsqlDbType.Integer).Value = count;


                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
        }
        public void Account_create(string login, string password)
        {
            using (conn)
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand($"INSERT INTO users (role_id,login,password) VALUES (@role_id,@login,@password)", conn))
                {
                    cmd.Parameters.Add("@role_id", NpgsqlDbType.Integer).Value = 2;
                    cmd.Parameters.Add("@login", NpgsqlDbType.Varchar).Value = login;
                    cmd.Parameters.Add("@password", NpgsqlDbType.Varchar).Value = password;


                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        public bool Login_check(string login)
        {
            using (conn)
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand($"SELECT id FROM users WHERE login = @login", conn))
                {
                    cmd.Parameters.Add("@login", NpgsqlDbType.Varchar).Value = login;
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                       if(reader.HasRows)
                        {
                           return false;
                        }
                        return true;
                    }

                }
            }
        }
        public void Product_remove(int productId)
        {
            using (conn)
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM goods WHERE id = @id", conn))
                {
                    cmd.Parameters.Add("@id", NpgsqlDbType.Integer).Value = productId;


                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Товар успешно удалён!");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                }

            }
        }
        public void Product_add(int type_id,string name, int price, long article)
        {
            conn.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand($"INSERT INTO goods (type_id,name,price,img_path,count,article) VALUES (@type_id,@name,@price,@path,@count,@article)", conn))
            {
                cmd.Parameters.Add("@type_id", NpgsqlDbType.Integer).Value = type_id;
                cmd.Parameters.Add("@name", NpgsqlDbType.Varchar).Value = name;
                cmd.Parameters.Add("@price", NpgsqlDbType.Integer).Value = price;
                cmd.Parameters.Add("@path", NpgsqlDbType.Varchar).Value = "sample";
                cmd.Parameters.Add("@count", NpgsqlDbType.Integer).Value = 1;
                cmd.Parameters.Add("@article", NpgsqlDbType.Bigint).Value = article;





                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Товар успешно добавлен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void Product_upd(int id, int type_id, string name, int price, long article)
        {
            conn.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand($"UPDATE goods SET type_id = @type_id, name = @name, price = @price, count = @count, article = @article WHERE id = @id", conn))
            {
                cmd.Parameters.Add("@id", NpgsqlDbType.Integer).Value = id;
                cmd.Parameters.Add("@type_id", NpgsqlDbType.Integer).Value = type_id;
                cmd.Parameters.Add("@name", NpgsqlDbType.Varchar).Value = name;
                cmd.Parameters.Add("@price", NpgsqlDbType.Integer).Value = price;
                cmd.Parameters.Add("@count", NpgsqlDbType.Integer).Value = 1;
                cmd.Parameters.Add("@article", NpgsqlDbType.Bigint).Value = article;





                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Товар успешно обновлён!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
