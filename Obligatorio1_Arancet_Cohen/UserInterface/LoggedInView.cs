using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic.Domain;

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
           new UserDataVerificationView(CurrentSession.UserLogged,mother),
           new ChooseBlueprintView(CurrentSession, this),
           new NewEditBlueprintView(CurrentSession, this),
           new ManageCostsView(this),
           new CreateBlueprint(CurrentSession,this),
           new CreateTemplate(mother),
           new AdminUserManagement(CurrentSession,this)
        };
            SetMenu();
        }



        private void SetMenu() {
            int buttonX = 170;
            int buttonY = 20;
            Button currentButton;
            foreach (IUserFeatureControl control in availableViews) {
                if (CurrentSession.UserLogged.HasPermission(control.GetRequiredPermission())) {
                    control.SetUp();

                    currentButton = control.OptionMenuButton();
                    currentButton.Left = buttonX;
                    currentButton.Top = buttonY;
                    AddDelegate(currentButton, (UserControl)control);
                    menuPanel.Controls.Add(currentButton);
                    buttonX += 170;

                }
            }
            dynamicPanel.Controls.Add(new GenericHome());
            AddLogOutButton(buttonX, buttonY);

        }

        internal void OpenUserEditor(User selectedUser) {
            dynamicPanel.Controls.Clear();
            dynamicPanel.Controls.Add(new UserDataVerificationView(selectedUser, mother));

        }

        internal void OpenBlueprintEditor(Blueprint blueprint) {
            dynamicPanel.Controls.Clear();
            dynamicPanel.Controls.Add(new EditBlueprintView(CurrentSession, this, blueprint));
        }

        internal void OpenBlueprintViewer(Blueprint blueprint) {
            dynamicPanel.Controls.Clear();
            dynamicPanel.Controls.Add(new BlueprintViewer(CurrentSession, this, blueprint));
        }

        internal void SetView(UserControl aControl) {
            dynamicPanel.Controls.Clear();
            dynamicPanel.Controls.Add(aControl);
        }

        private void AddLogOutButton(int positionX, int positionY) {
            Button logOut = ButtonCreator.GenerateButton("Log Out");
            logOut.Name = "LogOutButton";
            logOut.Location = new System.Drawing.Point(positionX, positionY);
            menuPanel.Controls.Add(logOut);
            logOut.Click += delegate (object sender, EventArgs e) {
                LogOut();
            };
        }

        private void LogOut() {
            mother.Authenticate();
        }

        public void RestartMenu() {
            mother.GoToMenu();//should be changed for a home screen if we have time
        }

        private void AddDelegate(Button currentButton, UserControl control) {
            currentButton.Click += delegate (object sender, EventArgs e) {
                dynamicPanel.Controls.Clear();
                dynamicPanel.Controls.Add(control);
                RestartPanel(control);
            };
        }

        private void RestartPanel(UserControl aControl) {
            ((IUserFeatureControl)aControl).SetUp();
        }
    }
}
