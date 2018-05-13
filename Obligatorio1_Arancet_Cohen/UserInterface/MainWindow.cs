using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace UserInterface {
    public partial class MainWindow : Form {

        internal Session CurrentSession { set; get; }
        internal UserControl currentPanel;

        public MainWindow() {
            InitializeComponent();
            Authenticate();
        }


        internal void Authenticate() {
            mainPanel.Controls.Clear();
            currentPanel = new LoginView(this);
            mainPanel.Controls.Add(currentPanel);
        }

        internal void GoToMenu() {
            mainPanel.Controls.Remove(currentPanel);
            if (CurrentSession.UserLogged.HasPermission(Permission.FIRST_LOGIN)) {
                currentPanel = new UserDataVerificationView(CurrentSession.UserLogged, this);
            } else {
                currentPanel = new LoggedInView(this, CurrentSession);
            }

            mainPanel.Controls.Add(currentPanel);
        }


    }
}
