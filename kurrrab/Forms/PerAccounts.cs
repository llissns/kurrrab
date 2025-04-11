using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace kurrrab.Forms
{
    public partial class PerAccounts : Form
    {
        private string _login;
        public PerAccounts(string login)
        {
            InitializeComponent();
            _login = login;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main accountForm = new Main();
            accountForm.Show();
        }

        private void PerAccounts_Load(object sender, EventArgs e)
        {
            label2.Text = $"Логин: {_login}";
            LoadUser();
        }
        private void LoadUser()
        {
            using (var conn = new NpgsqlConnection("Host=172.20.7.53;Port=5432;Username=st3996;Password=pwd3996;Database=db3996_19"))
            {
                conn.Open();
                string query = "SELECT RoomId, CheckInDate, CheckOutDate, PaymentStatus FROM infsystem.bookings WHERE login = @login";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("login", _login);
                    using (var reader = cmd.ExecuteReader())
                    {
                        StringBuilder bookingInfo = new StringBuilder();
                        while (reader.Read())
                        {
                            bookingInfo.AppendLine($" {reader["Roomid"]}");
                            bookingInfo.AppendLine($"Заезд: {reader["CheckInDate"]}");
                            bookingInfo.AppendLine($"Выезд: {reader["CheckOutDate"]}");
                            bookingInfo.AppendLine($"Оплата:: {reader["PaymentStatus"]}");

                            bookingInfo.AppendLine("-----------------------------");
                        }
                        textBox1.Text = bookingInfo.ToString();
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Main form4 = new Main();
            form4.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
