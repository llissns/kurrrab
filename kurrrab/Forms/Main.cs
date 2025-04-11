using kurrrab.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace kurrrab
{
    public partial class Main : Form
    {
        private string _login;
        private bool isLoggedIn = false;
        public Main()
        {
            InitializeComponent();
        }


        private void LoadContent(string content)
        {
            PanelContent.Controls.Clear(); // Очищаем правую панель

            // Создаем панель с прокруткой
            Panel scrollPanel = new Panel
            {
                AutoScroll = true, // Включаем прокрутку
                Size = new Size(PanelContent.Width - 20, PanelContent.Height - 20), // Размер панели с учетом отступов
                Location = new Point(10, 10),
            };

            // Создаем текстовый блок с содержанием
            TextBox textBox = new TextBox
            {
                Text = content,
                Multiline = true, // Включаем многострочный режим
                ReadOnly = true, // Запрещаем редактирование
                Dock = DockStyle.Top, // Размещение по верхней части панели
                Font = new System.Drawing.Font("Verdana", 10, System.Drawing.FontStyle.Regular), // Шрифт
                ScrollBars = ScrollBars.Vertical, // Добавляем вертикальную прокрутку
                BackColor = System.Drawing.Color.Linen, // Фон
                Height = 200 // Фиксированная высота для текста
            };

            // Добавляем текст в панель
            scrollPanel.Controls.Add(textBox);

            // Добавляем панель с прокруткой на главную панель
            PanelContent.Controls.Add(scrollPanel);
        }


        private void buttonAbout_Click(object sender, EventArgs e)
        {
            LoadContent("Гостиница \"Лесное Озеро\" — это уютный уголок природы, спрятанный среди живописных лесов и кристально чистых вод. Здесь гармонично сочетаются комфорт современного отеля и спокойствие природного заповедника.  \r\n\r\nРасположенный на берегу живописного озера, отель предлагает гостям возможность насладиться свежим воздухом, прогулками по лесным тропам, рыбалкой, катанием на лодках и вечерами у костра. Внутреннее убранство гостиницы выполнено в стиле эко-лофт, с использованием натуральных материалов, создавая атмосферу тепла и уюта.  \r\n\r\nВ \"Лесном Озере\" доступны номера разного уровня — от стандартных уютных комнат до роскошных коттеджей с панорамными окнами. Для полного расслабления гостей работают спа-центр, сауна и йога-зона на открытом воздухе. В ресторане отеля подают блюда из свежих местных продуктов, включая лесные ягоды, грибы и фермерские деликатесы.  \r\n\r\nГостиница идеально подходит как для романтических поездок и семейного отдыха, так и для уединенного релакса вдали от городской суеты. \"Лесное Озеро\" — место, где природа и комфорт встречаются, создавая незабываемые впечатления для каждого гостя.");
        }

        private void buttonRooms_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();

            //панель с прокруткой
            Panel scrollPanel = new Panel
            {
                AutoScroll = true,
                Size = new Size(PanelContent.Width - 20, PanelContent.Height - 20),
                Location = new Point(10, 10),
            };

            //данные о номерах (используем ресурсы)
            var rooms = new List<(string Name, Image Img, string Area, string Capacity, string Details)>
        {
            ("Стандартный", Properties.Resources.standart, "20 м²", "2 человека", "Этот номер идеально подходит для двух человек. Уютная обстановка и все необходимые удобства."),
            ("Семейный", Properties.Resources.semeiniy, "35 м²", "4 человека", "Просторный семейный номер с двумя кроватями и дополнительными удобствами для семьи."),
            ("Большой", Properties.Resources.bolshoy, "50 м²", "6 человек", "Просторный номер с большими окнами и зоной отдыха. Отлично подходит для групп и больших семей."),
            ("Молодёжный", Properties.Resources.molodesh, "25 м²", "3 человека", "Яркий и стильный номер для молодежных групп, оснащённый всеми современными удобствами."),
            ("Мансардный", Properties.Resources.mansard, "30 м²", "2 человека", "Уютный номер на мансарде с красивым видом. Идеально для романтических поездок."),
        };

            int y = 10; foreach (var room in rooms)
            {
                Panel panel = new Panel
                {
                    Size = new Size(scrollPanel.Width - 40, 180),
                    Location = new Point(10, y),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White,
                    Padding = new Padding(10),
                    Margin = new Padding(5)
                };

                PictureBox pictureBox = new PictureBox
                {
                    Image = room.Img,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(10, 10),
                    Size = new Size(130, 130)
                };

                Label label = new Label
                {
                    Text = $"{room.Name}\nПлощадь: {room.Area}\nВместимость: {room.Capacity}",
                    Font = new Font("Verdana", 10, FontStyle.Bold),
                    Location = new Point(150, 10),
                    AutoSize = true
                };

                //кнопка "Подробнее"
                Button btnDetails = new Button
                {
                    Text = "Подробнее",
                    Size = new Size(100, 30),
                    Location = new Point(150, 100),
                    Font = new Font("Verdana", 8, FontStyle.Regular),
                    BackColor = Color.Linen,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };
                btnDetails.FlatAppearance.BorderSize = 0;
                btnDetails.Click += (buttonSender, args) => MessageBox.Show(room.Details, $"Подробнее о номере {room.Name}");

                panel.Controls.Add(pictureBox);
                panel.Controls.Add(label);
                panel.Controls.Add(btnDetails);
                scrollPanel.Controls.Add(panel);

                y += 190;
            }

            //добавляем панель с прокруткой на главную панель
            PanelContent.Controls.Add(scrollPanel);
        }

        private void buttonServices_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear(); // Очищаем панель

            // Создаем панель с прокруткой
            Panel scrollPanel = new Panel
            {
                AutoScroll = true, // Включаем прокрутку
                Size = new Size(PanelContent.Width - 20, PanelContent.Height - 20), // Размер панели с учетом отступов
                Location = new Point(10, 10),
            };

            // Данные об услугах (используем ресурсы)
            var services = new List<(string Name, Image Img, string Description)>
            {
                ("Спа-кабинет", Properties.Resources.spa, "Расслабляющие процедуры для тела и души в уютной атмосфере."),
                ("Бани и сауны", Properties.Resources.banya, "Традиционные русские бани и сауны для релаксации и оздоровления."),
                ("Каток", Properties.Resources.katok, "Зимние развлечения для всей семьи."),
                ("Экскурсии", Properties.Resources.ecscurs, "Познавательные экскурсии по живописным окрестностям."),
                ("Массаж", Properties.Resources.masss, "Профессиональные массажи для расслабления и восстановления."),
                ("Рыбалка", Properties.Resources.fishing, "Рыбалка на озере с возможностью поймать различные виды рыб.")
            };

            int y = 10; 
            
            foreach (var service in services)
            {
                Panel panel = new Panel
                {
                    Size = new Size(scrollPanel.Width - 40, 180),
                    Location = new Point(10, y),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White,
                    Padding = new Padding(10),
                    Margin = new Padding(5)
                };

                PictureBox pictureBox = new PictureBox
                {
                    Image = service.Img,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(10, 10),
                    Size = new Size(130, 130)
                };

                Label label = new Label
                {
                    Text = service.Name,
                    Font = new Font("Verdana", 12, FontStyle.Bold),
                    Location = new Point(150, 10),
                    AutoSize = false,
                    Size = new Size(panel.Width - 170, 40), // Устанавливаем фиксированную высоту и максимальную ширину
                    TextAlign = ContentAlignment.MiddleLeft, // Выравниваем текст по левому краю
                    MaximumSize = new Size(panel.Width - 170, 40)
                };

                // Кнопка "Подробнее"
                Button btnDetails = new Button
                {
                    Text = "Подробнее",
                    Size = new Size(100, 30),
                    Location = new Point(150, 100),
                    Font = new Font("Verdana", 8, FontStyle.Regular),
                    BackColor = Color.Linen,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };
                btnDetails.FlatAppearance.BorderSize = 0;
                btnDetails.Click += (buttonSender, args) => MessageBox.Show(service.Description, $"Подробнее об услуге {service.Name}");

                panel.Controls.Add(pictureBox);
                panel.Controls.Add(label);
                panel.Controls.Add(btnDetails);
                scrollPanel.Controls.Add(panel);

                y += 190; // Смещаем вниз для следующего номера
            }

            // Добавляем панель с прокруткой на главную панель
            PanelContent.Controls.Add(scrollPanel);
        }

        private void buttonContacts_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear(); // Очищаем панель

            // Создадим панель для контактной информации
            Panel contactPanel = new Panel
            {
                Size = new Size(PanelContent.Width - 40, 300),
                Location = new Point(10, 10),
                BorderStyle = BorderStyle.None,
                BackColor = Color.White
            };

            // Заголовок
            Label titleLabel = new Label
            {
                Text = "Контактная информация",
                Font = new Font("Verdana", 16, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true,
                ForeColor = Color.Tan
            };

            // Адрес
            Label addressLabel = new Label
            {
                Text = "Адрес: ул. Лесная, 1, г. Лесное, Россия",
                Font = new Font("Verdana", 12),
                Location = new Point(10, 60),
                AutoSize = true
            };

            // Телефон
            Label phoneLabel = new Label
            {
                Text = "Телефон: +7 (123) 456-78-90",
                Font = new Font("Verdana", 12),
                Location = new Point(10, 100),
                AutoSize = true
            };

            // Email
            Label emailLabel = new Label
            {
                Text = "Email: contact@lesnoe-ozero.ru",
                Font = new Font("Verdana", 12),
                Location = new Point(10, 140),
                AutoSize = true
            };

            // Социальные сети
            Label socialLabel = new Label
            {
                Text = "Социальные сети:",
                Font = new Font("Verdana", 12),
                Location = new Point(10, 180),
                AutoSize = true
            };

            // Иконки социальных сетей
            PictureBox fbIcon = new PictureBox
            {
                Image = Properties.Resources.standart, // Используем ресурс для иконки Facebook
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(10, 210),
                Size = new Size(40, 40),
                Cursor = Cursors.Hand
            };

            PictureBox vkIcon = new PictureBox
            {
                Image = Properties.Resources.standart, // Иконка ВКонтакте
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(60, 210),
                Size = new Size(40, 40),
                Cursor = Cursors.Hand
            };

            PictureBox instaIcon = new PictureBox
            {
                Image = Properties.Resources.standart, // Иконка Instagram
                SizeMode = PictureBoxSizeMode.StretchImage,
                Location = new Point(110, 210),
                Size = new Size(40, 40),
                Cursor = Cursors.Hand
            };

            // Добавим обработчики для иконок социальных сетей
            fbIcon.Click += (buttonSender, args) => Process.Start("https://www.facebook.com/yourpage");
            vkIcon.Click += (buttonSender, args) => Process.Start("https://vk.com/yourpage");
            instaIcon.Click += (buttonSender, args) => Process.Start("https://www.instagram.com/yourpage");

            // Добавляем все элементы на панель
            contactPanel.Controls.Add(titleLabel);
            contactPanel.Controls.Add(addressLabel);
            contactPanel.Controls.Add(phoneLabel);
            contactPanel.Controls.Add(emailLabel);
            contactPanel.Controls.Add(socialLabel);
            contactPanel.Controls.Add(fbIcon);
            contactPanel.Controls.Add(vkIcon);
            contactPanel.Controls.Add(instaIcon);

            // Добавляем панель на основную панель
            PanelContent.Controls.Add(contactPanel);
        }

        private void buttonAccount_Click(object sender, EventArgs e)
        {
            Autorization auto = new Autorization();
            if (auto.ShowDialog() == DialogResult.OK)
            {
                _login = auto.Username; // Получаем логин
                isLoggedIn = true;

                this.Hide();

                if (_login == "admin")
                {
                    Admin adminForm = new Admin();
                    adminForm.Show();
                }
                else if (_login == "user1")
                {
                    PerAccounts form = new PerAccounts(_login);
                    form.Show();
                }
            }
        }
            

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PanelContent_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }

}
