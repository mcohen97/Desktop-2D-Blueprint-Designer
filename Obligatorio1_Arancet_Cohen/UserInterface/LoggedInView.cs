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

        public LoggedInView(MainWindow aWindow, Session aSession) {
            InitializeComponent();
            CurrentSession = aSession;
            mother = aWindow;
            SetMenu();
        }

        List<IUserFeatureControl> availableViews = new List<IUserFeatureControl>() {
           new UserDataVerificationView()

        };

        private void SetMenu() {
            Button currentButton;
            foreach (IUserFeatureControl control in availableViews) {
                //if (CurrentSession.UserLogged.HasPermission(control.GetRequiredPermission())) {
                currentButton = control.OptionMenuButton();
                AddDelegate(currentButton, (UserControl)control);
                menuPanel.Controls.Add(currentButton);

                //}
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
