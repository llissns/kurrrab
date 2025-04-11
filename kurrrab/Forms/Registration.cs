using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kurrrab.Forms
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Autorization accountForm = new Autorization();
            accountForm.Show();
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем данные из полей
            string firstName = textBoxFirstName.Text.Trim();
            string lastName = textBoxLastName.Text.Trim();
            string phoneNumber = textBoxPhoneNumber.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            string login = textBoxLogin.Text.Trim(); // Логин пользователя

            // Проверка на пустые поля
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(phoneNumber) ||
                string.IsNullOrEmpty(email)||  string.IsNullOrEmpty(password) || string.IsNullOrEmpty(login))
    {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            string connectionString = "Host=172.20.7.53;Port=5432;Username=st3996;Password=pwd3996;Database=db3996_19";

            // Подключаемся к базе данных
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Начинаем транзакцию для сохранения данных в обе таблицы
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Вставка данных в таблицу users (логин и пароль)
                            string userQuery = "INSERT INTO users (login, password) VALUES (@login, @password)";
                            using (NpgsqlCommand userCmd = new NpgsqlCommand(userQuery, connection))
                            {
                                userCmd.Parameters.AddWithValue("@login", login);
                                userCmd.Parameters.AddWithValue("@password", password); // Пароль должен быть захеширован!
                                userCmd.ExecuteNonQuery();
                            }

                            // Вставка данных в таблицу Client (имя, фамилия, телефон, email, предпочтения)
                            string clientQuery = "INSERT INTO Clients (firstname, lastname, phonenumber, email, preference) " +
                                                 "VALUES (@firstname, @lastname, @phonenumber, @email, @preference)";
                            using (NpgsqlCommand clientCmd = new NpgsqlCommand(clientQuery, connection))
                            {
                                clientCmd.Parameters.AddWithValue("@firstname", firstName);
                                clientCmd.Parameters.AddWithValue("@lastname", lastName);
                                clientCmd.Parameters.AddWithValue("@phonenumber", phoneNumber);
                                clientCmd.Parameters.AddWithValue("@email", email);
                                clientCmd.Parameters.AddWithValue("@preference", ""); // По умолчанию preference пустое, можно добавить значение.
                                clientCmd.ExecuteNonQuery();
                            }

                            // Если оба запроса выполнены успешно, подтверждаем транзакцию
                            transaction.Commit();

                            MessageBox.Show("Регистрация успешна!");
                            this.Close(); // Закрываем форму регистрации
                        }
                        catch (Exception ex)
                        {
                            // Если ошибка, откатываем транзакцию
                            transaction.Rollback();
                            MessageBox.Show("Ошибка регистрации: " + ex.Message);
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
    }
}
