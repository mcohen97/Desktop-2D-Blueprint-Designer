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

        public Session CurrentSession { set; get; }
        public UserControl currentPanel;

        public MainWindow() {
            InitializeComponent();
            Authenticate();
            
        }

        public void Authenticate() {
            mainPanel.Controls.Clear();
            currentPanel = new LoginView(this);
            mainPanel.Controls.Add(currentPanel);
        }

        internal void ProceedToMenu() {
            mainPanel.Controls.Remove(currentPanel);
            currentPanel = new LoggedInView(this,CurrentSession);
            //currentPanel,
            mainPanel.Controls.Add(currentPanel);
        }
    }
}
