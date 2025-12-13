using System;
using System.Windows.Forms;

namespace MyProject.WinForms
{
    public class MainForm : Form
    {
        public MainForm()
        {
            this.Text = "Staff Main Screen";
            this.Width = 600;
            this.Height = 400;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lbl = new Label()
            {
                Text = "Welcome to Staff System",
                AutoSize = true,
                Left = 20,
                Top = 20
            };

            this.Controls.Add(lbl);
        }
    }
}