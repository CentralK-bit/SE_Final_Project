namespace MyProject.WinForms;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        using (var login = new LoginForm())
        {
            var result = login.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Application.Run(new MainForm());
            }
            else
            {
                // Exit the application if login was cancelled or failed
                return;
            }
        }
    }    
}