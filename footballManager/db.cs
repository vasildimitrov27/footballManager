using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

public static class Db
{
    private static string connString = ConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString;

    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(connString);
    }

    // Помощен метод за SELECT (връща DataTable)
    public static DataTable GetDataTable(string sql, MySqlParameter[] parameters = null)
    {
        using (var conn = GetConnection())
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                if (parameters != null) cmd.Parameters.AddRange(parameters);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при четене: " + ex.Message);
                return null;
            }
        }
    }

    // Помощен метод за INSERT/UPDATE/DELETE
    public static int ExecuteNonQuery(string sql, MySqlParameter[] parameters)
    {
        using (var conn = GetConnection())
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при изпълнение: " + ex.Message);
                return -1;
            }
        }
    }
}