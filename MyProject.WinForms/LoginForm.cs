using System;
using System.Windows.Forms;
using MyProject.BLL;
using MyProject.WinForms;

namespace MyProject.WinForms
{
    public class LoginForm : Form
    {
        TextBox txtUsername = null!;
        TextBox txtPassword = null!;
        Button btnLogin = null!;
        Label lblMessage;

        public LoginForm()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Text = "Staff Login";
            this.Width = 300;
            this.Height = 220;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblUser = new Label()
            {
                Text = "Username",
                Left = 20,
                Top = 20,
                Width = 80
            };

            txtUsername = new TextBox()
            {
                Left = 110,
                Top = 20,
                Width = 140
            };

            Label lblPass = new Label()
            {
                Text = "Password",
                Left = 20,
                Top = 60,
                Width = 80
            };

            txtPassword = new TextBox()
            {
                Left = 110,
                Top = 60,
                Width = 140,
                PasswordChar = '*'
            };

            btnLogin = new Button()
            {
                Text = "Login",
                Left = 110,
                Top = 100,
                Width = 80
            };
            btnLogin.Click += BtnLogin_Click;

            lblMessage = new Label()
            {
                Left = 20,
                Top = 140,
                Width = 230,
                ForeColor = System.Drawing.Color.Red
            };

            this.Controls.Add(lblUser);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPass);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(lblMessage);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var service = new UserService();
            bool success = service.Login(
                txtUsername.Text.Trim(),
                txtPassword.Text.Trim()
            );

            if (success)
            {
                // Set DialogResult so the caller knows login succeeded and close the form
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblMessage.Text = "Invalid username or password";
            }
        }
    }
}