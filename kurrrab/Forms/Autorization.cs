using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace kurrrab.Forms
{
    public partial class Autorization : Form
    {
        public string Username { get; private set; }
        public Autorization()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            // Проверка на пустые поля
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль.");
                return;
            }

            string connectionString = "Host=172.20.7.53;Port=5432;Username=st3996;Password=pwd3996;Database=db3996_19";

            // Подключение к базе данных
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Создаем запрос с параметрами
                    string query = "SELECT COUNT(*) FROM infsystem.users WHERE login = @login AND password = @password";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                    {
                        // Добавляем параметры
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@password", password);

                        // Выводим в консоль запрос для отладки
                        Console.WriteLine("Executing query: " + query);
                        Console.WriteLine("With login: " + login);
                        Console.WriteLine("With password: " + password);

                        // Выполнение запроса
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // Проверяем результат
                        if (count > 0)
                        {
                            MessageBox.Show("Вы успешно вошли!");

                            Username = login;
                            this.DialogResult = DialogResult.OK;

                            this.Hide();

                            if (login == "admin")
                            {
                                Admin adminForm = new Admin();
                                adminForm.Show();
                            }
                            else
                            {
                                Main mainForm = new Main();
                                mainForm.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин или пароль.");
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox1.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Обработка ошибок подключения
                    MessageBox.Show("Ошибка подключения к базе данных:\n" + ex.Message);
                }
            }
        }



        private void label4_Click(object sender, EventArgs e)
        {
            Registration accountForm = new Registration();
            accountForm.Show();
        }

        private void Autorization_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*'; // Скрытие пароля
        }
    }
}
         
