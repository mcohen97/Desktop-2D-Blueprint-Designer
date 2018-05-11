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

        private Session CurrentSession { get; set; }
        public MainWindow parent;
        public UserDataVerificationView(Session aSession, MainWindow aWindow) {
            InitializeComponent();
            parent = aWindow;
            CurrentSession = aSession;
            ShowData();
        }

        private void ShowData() {
            SetCommonData();
            if (CurrentSession.UserLogged.HasPermission(Permission.HOLD_EXTRA_DATA)) {
                onlyUserFields.Show();
                SetUserData();
            } else {
                onlyUserFields.Hide();
            }

        }

        private void SetCommonData() {
            if (CurrentSession.UserLogged.HasPermission(Permission.FIRST_LOGIN)) {
                viewTitle.Text = "Verify and edit your information";
            } else {
                viewTitle.Text = "Edit your information";
            }
            nameTxt.Text = CurrentSession.UserLogged.Name;
            surnameText.Text = CurrentSession.UserLogged.Surname;
            passwordText.Text = CurrentSession.UserLogged.Password;
        }

        private void SetUserData() {
            Client logged = (Client)CurrentSession.UserLogged;
            idText.Text = logged.Id;
            telNumberText.Text = logged.Phone;
            addressText.Text = logged.Address;
        }

        public Permission GetRequiredPermission() {
            return Permission.EDIT_USER;
        }

        public Button OptionMenuButton() {
            Button optionButton = new Button();
            optionButton.Width = 100;
            optionButton.Height = 50;
            optionButton.Text = "Edit Personal Info";
            return optionButton;
        }

        public void SetSession(Session aSession) {
            CurrentSession = aSession;
        }

        private void finishButton_Click(object sender, EventArgs e) {
            User logged = CurrentSession.UserLogged;
            if (logged.HasPermission(Permission.FIRST_LOGIN)) {
                logged.RemovePermission(Permission.FIRST_LOGIN);
            }
            UpdateCommonInformation();
            if (logged.HasPermission(Permission.HOLD_EXTRA_DATA)) {
                UpdateClientInformation();
            }
            parent.GoToMenu();
        }

        private void UpdateClientInformation() {
            Client edited = (Client)CurrentSession.UserLogged;
            edited.Id = idText.Text;
            edited.Address = addressText.Text;
            edited.Phone = telNumberText.Text;
        }

        private void UpdateCommonInformation() {
            User edited = CurrentSession.UserLogged;
            edited.Name = nameTxt.Text;
            edited.Surname = surnameText.Text;
            edited.Password = passwordText.Text;
        }
    }
}
