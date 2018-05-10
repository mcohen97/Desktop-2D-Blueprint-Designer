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
    public partial class LoggedInView : UserControl {

        Session CurrentSession { get; set; }
        MainWindow mother;
        List<IUserFeatureControl> availableViews;

        public LoggedInView(MainWindow aWindow, Session aSession) {
            InitializeComponent();
            CurrentSession = aSession;
            mother = aWindow;
            availableViews = new List<IUserFeatureControl>() {
           new UserDataVerificationView(CurrentSession),
           new ChooseBlueprintView(CurrentSession, this),
           new ManageCostsView(),
           new ManageUsersView()

        };
            SetMenu();
        }

         

        private void SetMenu() {
            AddLogOutButton();
            int buttonX = 170;
            int buttonY = 50;
            Button currentButton;
            foreach (IUserFeatureControl control in availableViews) {
                if (CurrentSession.UserLogged.HasPermission(control.GetRequiredPermission())) {
                    currentButton = control.OptionMenuButton();
                    currentButton.Left = buttonX;
                    currentButton.Top = buttonY;
                    AddDelegate(currentButton, (UserControl)control);
                    menuPanel.Controls.Add(currentButton);
                    buttonX += 120;

                }
            }
            
        }

        private void AddLogOutButton() {
            Button logOut = new Button();
            logOut.Top = 50;
            logOut.Left = 50;
            logOut.Width = 100;
            logOut.Height = 50;
            logOut.Text = "Log Out";
            menuPanel.Controls.Add(logOut);
            logOut.Click += delegate (object sender, EventArgs e) {
                LogOut();
            };
        }

        private void LogOut() {
            mother.Authenticate();
        }

        private void AddDelegate(Button currentButton, UserControl control) {
            currentButton.Click += delegate (object sender, EventArgs e) {
                dynamicPanel.Controls.Clear();
                dynamicPanel.Controls.Add(control);

            };
        }
    }
}
