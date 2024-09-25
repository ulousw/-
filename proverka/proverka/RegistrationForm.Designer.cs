using System.Windows.Forms;

namespace DryCleaningApp
{
    partial class RegistrationForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtPhone;
        private TextBox txtPassword;
        private Button btnRegister;
        private Button btnBackToLogin;
        private ComboBox cbRole; // Добавляем ComboBox

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnBackToLogin = new System.Windows.Forms.Button();
            this.cbRole = new System.Windows.Forms.ComboBox(); // Инициализация ComboBox
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(60, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(330, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Химчистка Чистюля";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(90, 80);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(250, 20);
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.Text = "Имя";
            this.txtFirstName.Leave += new System.EventHandler(this.TxtFirstName_Leave);
            this.txtFirstName.Enter += new System.EventHandler(this.TxtFirstName_Enter);

            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(90, 120);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(250, 20);
            this.txtLastName.TabIndex = 2;
            this.txtLastName.Text = "Фамилия";
            this.txtLastName.Leave += new System.EventHandler(this.TxtLastName_Leave);
            this.txtLastName.Enter += new System.EventHandler(this.TxtLastName_Enter);

            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(90, 160);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(250, 20);
            this.txtPhone.TabIndex = 3;
            this.txtPhone.Text = "Телефон";
            this.txtPhone.Leave += new System.EventHandler(this.TxtPhone_Leave);
            this.txtPhone.Enter += new System.EventHandler(this.TxtPhone_Enter);

            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(90, 200);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(250, 20);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Text = "Пароль";
            this.txtPassword.Leave += new System.EventHandler(this.TxtPassword_Leave);
            this.txtPassword.Enter += new System.EventHandler(this.TxtPassword_Enter);

            // 
            // cbRole
            // 
            this.cbRole.Location = new System.Drawing.Point(90, 240);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(250, 21);
            this.cbRole.TabIndex = 5;

            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(90, 280);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(100, 30);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Регистрация";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // 
            // btnBackToLogin
            // 
            this.btnBackToLogin.Location = new System.Drawing.Point(240, 280);
            this.btnBackToLogin.Name = "btnBackToLogin";
            this.btnBackToLogin.Size = new System.Drawing.Size(100, 30);
            this.btnBackToLogin.TabIndex = 7;
            this.btnBackToLogin.Text = "Назад";
            this.btnBackToLogin.UseVisualStyleBackColor = true;
            this.btnBackToLogin.Click += new System.EventHandler(this.btnBackToLogin_Click);

            // 
            // RegistrationForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.btnBackToLogin);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblTitle);
            this.Name = "RegistrationForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
