using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessDataExceptions;

namespace UserInterface
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new MainWindow());
            }
            catch (InaccessibleDataException) {
                CloseWithMessage("Connection to database failed");
            }
            catch (InconsistentDataException) {
                CloseWithMessage("Database data is inconsistent");
            }
        }

        private static void CloseWithMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
