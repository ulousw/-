

using proverka;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DryCleaningApp
{
    public partial class LoginForm : Form
    {
        private bool isDarkTheme = false;
        private string connectionString = "Data Source=DESKTOP-DLQ4A54\\SQLEXPRESS02;Initial Catalog=CLEAN;Integrated Security=True;Encrypt=False;";

        public LoginForm()
        {
            InitializeComponent();
            CustomizeForm();
        }

        private void CustomizeForm()
        {
            this.BackColor = Color.White;
            lblTitle.Text = "Химчистка Чистюля";
            lblTitle.ForeColor = Color.Black;

            // Стиль кнопок и полей
            btnLogin.BackColor = Color.LightBlue;
            btnCreateAccount.BackColor = Color.LightBlue;
            btnLogin.ForeColor = Color.Black;
            btnCreateAccount.ForeColor = Color.Black;
            btnClear.BackColor = Color.LightGray;
            btnChangeTheme.BackColor = Color.LightGray;

            // Стиль текстовых полей
            txtPhone.ForeColor = Color.Gray;
            txtPassword.ForeColor = Color.Gray;

            // Установка подсказок (ручная реализация)
            txtPhone.Text = "Телефон";
            txtPassword.Text = "Пароль";

            // Привязываем события Enter и Leave
            txtPhone.Enter += new EventHandler(txtPhone_Enter);
            txtPhone.Leave += new EventHandler(txtPhone_Leave);
            txtPassword.Enter += new EventHandler(txtPassword_Enter);
            txtPassword.Leave += new EventHandler(txtPassword_Leave);
        }

        // Обработчики событий для txtPhone
        private void txtPhone_Enter(object sender, EventArgs e)
        {
            if (txtPhone.Text == "Телефон")
            {
                txtPhone.Text = "";
                txtPhone.ForeColor = Color.Black;
            }
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                txtPhone.Text = "Телефон";
                txtPhone.ForeColor = Color.Gray;
            }
        }

        // Обработчики событий для txtPassword
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Пароль")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.PasswordChar = '*';
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Пароль";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.PasswordChar = '\0'; // Отключаем скрытие символов
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string phone = txtPhone.Text;
            string password = txtPassword.Text;

            // Проверка на "умные" подсказки
            if (phone == "Телефон" || password == "Пароль")
            {
                MessageBox.Show("Пожалуйста, введите номер телефона и пароль.");
                return;
            }

            // Попробуем подключиться к базе данных
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Пользователи WHERE Phone = @phone AND Password = @password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@password", password);

                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        // Данные совпадают, переход на EmployeePanel
                        EmployeePanel employeePanel = new EmployeePanel();
                        employeePanel.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Так нельзя, давай заново");
                    }
                }
            }
        }


        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            RegistrationForm frm = new RegistrationForm();
            frm.Show();
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPhone.Text = "Телефон";
            txtPhone.ForeColor = Color.Gray;

            txtPassword.Text = "Пароль";
            txtPassword.ForeColor = Color.Gray;
            txtPassword.PasswordChar = '\0'; // Отключаем скрытие символов
        }

        private void btnChangeTheme_Click(object sender, EventArgs e)
        {
            if (!isDarkTheme)
            {
                this.BackColor = Color.Black;
                lblTitle.ForeColor = Color.White;
                txtPhone.BackColor = Color.DarkGray;
                txtPassword.BackColor = Color.DarkGray;
                txtPhone.ForeColor = Color.White;
                txtPassword.ForeColor = Color.White;
                btnLogin.BackColor = Color.Gray;
                btnCreateAccount.BackColor = Color.Gray;
                btnClear.BackColor = Color.Gray;
                btnChangeTheme.BackColor = Color.Gray;
            }
            else
            {
                CustomizeForm(); // Возвращаемся к светлой теме
            }
            isDarkTheme = !isDarkTheme;
        }
    }
}
