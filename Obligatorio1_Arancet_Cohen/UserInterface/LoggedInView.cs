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
            int buttonX = 50;
            int buttonY = 50;
            Button currentButton;
            foreach (IUserFeatureControl control in availableViews) {
                if (CurrentSession.UserLogged.HasPermission(control.GetRequiredPermission())) {
                    currentButton = control.OptionMenuButton();
                    currentButton.Left = buttonX;
                    currentButton.Top = buttonY;
                    AddDelegate(currentButton, (UserControl)control);
                    menuPanel.Controls.Add(currentButton);
                    Console.Write("add button");
                    buttonX += 150;

                }
            }
            
        }

        private void AddDelegate(Button currentButton, UserControl control) {
            currentButton.Click += delegate (object sender, EventArgs e) {
                dynamicPanel.Controls.Clear();
                dynamicPanel.Controls.Add(control);

            };
            //dynamicPanel.Controls.Add(control);
        }
    }
}
