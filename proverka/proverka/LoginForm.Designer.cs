using System;
using System.Drawing;
using System.Windows.Forms;
namespace DryCleaningApp
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private TextBox txtPhone;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnCreateAccount;
        private Button btnClear;
        private Button btnChangeTheme;

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
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnChangeTheme = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTitle.Location = new System.Drawing.Point(60, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(330, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Химчистка Чистюля";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            // txtPhone
            this.txtPhone.Location = new System.Drawing.Point(90, 80);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(250, 20);
            this.txtPhone.TabIndex = 1;
            this.txtPhone.Text = "Телефон";  // Устанавливаем текст вручную
            this.txtPhone.ForeColor = Color.Gray;
            this.txtPhone.Enter += new System.EventHandler(this.txtPhone_Enter);
            this.txtPhone.Leave += new System.EventHandler(this.txtPhone_Leave);

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(90, 120);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(250, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Text = "Пароль";  // Устанавливаем текст вручную
            this.txtPassword.ForeColor = Color.Gray;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(90, 160);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 30);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Войти";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnCreateAccount
            this.btnCreateAccount.Location = new System.Drawing.Point(240, 160);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(100, 30);
            this.btnCreateAccount.TabIndex = 4;
            this.btnCreateAccount.Text = "Нет аккаунта? Создай!";
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);

            // btnClear
            this.btnClear.Location = new System.Drawing.Point(90, 200);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // btnChangeTheme
            this.btnChangeTheme.Location = new System.Drawing.Point(240, 200);
            this.btnChangeTheme.Name = "btnChangeTheme";
            this.btnChangeTheme.Size = new System.Drawing.Size(100, 30);
            this.btnChangeTheme.TabIndex = 6;
            this.btnChangeTheme.Text = "Сменить тему";
            this.btnChangeTheme.UseVisualStyleBackColor = true;
            this.btnChangeTheme.Click += new System.EventHandler(this.btnChangeTheme_Click);

            // LoginForm
            this.ClientSize = new System.Drawing.Size(450, 280);
            this.Controls.Add(this.btnChangeTheme);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblTitle);
            this.Name = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}
