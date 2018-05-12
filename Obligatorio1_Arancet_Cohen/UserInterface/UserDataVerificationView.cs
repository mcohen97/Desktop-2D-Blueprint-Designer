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
    public partial class UserDataVerificationView : UserControl, IUserFeatureControl {

        private User edited;
        public MainWindow parent;
        public UserDataVerificationView(User aUser, MainWindow aWindow) {
            InitializeComponent();
            parent = aWindow;
            edited = aUser;
            ShowData();
        }

        private void ShowData() {
            SetCommonData();
            if (edited.HasPermission(Permission.HOLD_EXTRA_DATA)) {
                onlyClientFields.Show();//this would be Client case
                userInfo.Show();
                SetUserData();
            } else {
                onlyClientFields.Hide();
                ShowOrHideUserData();
            }

        }

        private void ShowOrHideUserData() {
            if (AdminEditsItself() || AdminEditsOtherUser()) {
                userInfo.Show();//this would be the Admin case
            } else {
                userInfo.Hide(); //this would be the Designer case
            }
        }
        private bool AdminEditsItself() {
            return edited.HasPermission(Permission.CREATE_USER);
        }
        private bool AdminEditsOtherUser() {
            return parent.CurrentSession.UserLogged.HasPermission(Permission.CREATE_USER);
        }

        private void SetCommonData() {
            SetControlTitle();
            nameTxt.Text = edited.Name;
            surnameText.Text = edited.Surname;
            passwordText.Text = edited.Password;
            UsernameLabel.Text = edited.UserName;
        }

        private void SetControlTitle() {
            if (edited.HasPermission(Permission.FIRST_LOGIN)) {
                viewTitle.Text = "Verify and edit your information";
            } else {
                viewTitle.Text = "User information ";
            }
        }

        private void SetUserData() {
            Client logged = (Client)edited;
            idText.Text = logged.Id;
            telNumberText.Text = logged.Phone;
            addressText.Text = logged.Address;
        }

        public Permission GetRequiredPermission() {
            return Permission.EDIT_OWN_DATA;
        }

        public Button OptionMenuButton() {
            return ButtonCreator.GenerateButton("Edit personal information");
        }

        private void finishButton_Click(object sender, EventArgs e) {
            RemoveFirstLoginFeature();
            UpdateCommonInformation();
            if (edited.HasPermission(Permission.HOLD_EXTRA_DATA)) {
                UpdateClientInformation();
            }
            parent.GoToMenu();
        }

        private void RemoveFirstLoginFeature() {
            if (edited.HasPermission(Permission.FIRST_LOGIN)) {
                edited.RemovePermission(Permission.FIRST_LOGIN);
            }
        }

        private void UpdateClientInformation() {
            Client updated = (Client)edited;
            updated.Id = idText.Text;
            updated.Address = addressText.Text;
            updated.Phone = telNumberText.Text;
        }

        private void UpdateCommonInformation() {
            edited.Name = nameTxt.Text;
            edited.Surname = surnameText.Text;
            edited.Password = passwordText.Text;
        }
    }
}
