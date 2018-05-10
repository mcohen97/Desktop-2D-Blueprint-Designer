using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace UserInterface {
    public partial class LoginView : UserControl {

        SessionConnector connector;
        MainWindow mother;

        public LoginView(MainWindow aWindow) {

            InitializeComponent();
            mother = aWindow;
            connector = new SessionConnector();
            PasswordText.PasswordChar = '*';

        }

        private void LogInButton_Click(object sender, EventArgs e) {
            //mother.CurrentSession=connector.LogIn(UsernameText.Text, PasswordText.Text);
            mother.ProceedToMenu();
        }
    }
}
