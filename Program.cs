using System;
using System.Windows.Forms;
using MyWinFormsApp.Data;

namespace MyWinFormsApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
