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
    public partial class AdminUserManagement : UserControl, IUserFeatureControl {

        private Session CurrentSession { get; set; }
        private LoggedInView parent;
        private UserAdministrator controller;

        public AdminUserManagement(Session aSession, LoggedInView aControl) {
            InitializeComponent();
            parent = aControl;
            CurrentSession = aSession;
            controller = new UserAdministrator(CurrentSession);
        }

        private void FillList() {
            userList.DataSource = null;
            /* List<User> elegibleUsers = UsersPortfolio.Instance.GetUsers().ToList();
             elegibleUsers.Remove(CurrentSession.UserLogged);*/
            List<User> elegibleUsers = controller.GetAllUsersExceptMe().ToList();
            userList.DataSource = elegibleUsers;
        }

        private void editButton_Click(object sender, EventArgs e) {
            bool selectedItem = InputValidations.IsListItemSelected(userList, errorLabel,
               "Debe seleccionar un usuario primero");
            if (selectedItem) {
                parent.OpenUserEditor((User)userList.SelectedItem);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e) {
            bool selectedItem=InputValidations.IsListItemSelected(userList, errorLabel,
                "Debe seleccionar un usuario primero");
            if (selectedItem) {
                // UsersPortfolio.Instance.Remove((User)userList.SelectedItem);
                controller.Remove((User)userList.SelectedItem);
                FillList();
            }
        }

        public Permission GetRequiredPermission() {
            return Permission.EDIT_USER;
        }

        public Button OptionMenuButton() {
            return ButtonCreator.GenerateButton("Manage Users");
        }

        private void doneButton_Click(object sender, EventArgs e) {
            parent.RestartMenu();
        }

        private void createDesigner_Click(object sender, EventArgs e) { 
            parent.SetView(new CreateUser(parent,Permission.CREATE_BLUEPRINT,CurrentSession));
        }

        private void createClient_Click(object sender, EventArgs e) {
            parent.SetView(new CreateUser(parent, Permission.HOLD_EXTRA_DATA,CurrentSession));
        }

        public void SetUp() {
            FillList();
        }
    }
}
