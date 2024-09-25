using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DryCleaningApp
{
    public partial class RegistrationForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-DLQ4A54\\SQLEXPRESS02;Initial Catalog=CLEAN;Integrated Security=True;Encrypt=False;";

        public RegistrationForm()
        {
            InitializeComponent();
            CustomizeForm();
        }

        private void CustomizeForm()
        {
            this.BackColor = Color.White;
            lblTitle.Text = "Химчистка Чистюля";
            lblTitle.ForeColor = Color.Black;

            // Настройка кнопок
            btnRegister.BackColor = Color.LightBlue;
            btnBackToLogin.BackColor = Color.LightBlue;
            btnRegister.ForeColor = Color.Black;
            btnBackToLogin.ForeColor = Color.Black;

            // Настройка текстовых полей
            txtFirstName.ForeColor = Color.Black;
            txtLastName.ForeColor = Color.Black;
            txtPhone.ForeColor = Color.Black;
            txtPassword.ForeColor = Color.Black;

            // Настройка выпадающего списка
            cbRole.Items.Add("client");
            cbRole.Items.Add("employee");
            cbRole.Items.Add("admin");
            cbRole.SelectedIndex = 0; // Установка значения по умолчанию
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Пользователи (first_name, last_name, phone, password, role) VALUES (@first_name, @last_name, @phone, @password, @role)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@first_name", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@last_name", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@role", cbRole.SelectedItem.ToString());

                    cmd.ExecuteNonQuery(); // Выполняем запрос
                    MessageBox.Show("Регистрация выполнена успешно!");

                    // После успешной регистрации переходим на форму входа
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при регистрации: " + ex.Message);
                }
            }
        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        // Обработчики событий для полей ввода
        private void TxtFirstName_Enter(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "Имя") txtFirstName.Text = "";
        }

        private void TxtFirstName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text)) txtFirstName.Text = "Имя";
        }

        private void TxtLastName_Enter(object sender, EventArgs e)
        {
            if (txtLastName.Text == "Фамилия") txtLastName.Text = "";
        }

        private void TxtLastName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text)) txtLastName.Text = "Фамилия";
        }

        private void TxtPhone_Enter(object sender, EventArgs e)
        {
            if (txtPhone.Text == "Телефон") txtPhone.Text = "";
        }

        private void TxtPhone_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhone.Text)) txtPhone.Text = "Телефон";
        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Пароль") txtPassword.Text = "";
            txtPassword.PasswordChar = '*';
        }

        private void TxtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text)) txtPassword.Text = "Пароль";
        }
    }
}
