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
using Services;
using RepositoryInterface;
using DataAccess;

namespace UserInterface {
    public partial class CreateUser : UserControl {

        private LoggedInView parent;
        private Permission particularFeature;
        private Session CurrentSession { get; set; }
        private UserAdministrator permissionController;

        public CreateUser(LoggedInView aControl, Permission aFeature, Session aSession) {
            InitializeComponent();
            parent = aControl;
            CurrentSession = aSession;
            IRepository<User> userStorage = new UserRepository();
            permissionController = new UserAdministrator(CurrentSession,userStorage);
            particularFeature = aFeature;
            ShowExtraFields();
        }

        private void ShowExtraFields() {
            if (particularFeature.Equals(Permission.HOLD_EXTRA_DATA)) {
                onlyClientFields.Show();
            } else {
                onlyClientFields.Hide();
            }
        }

        private void createButton_Click(object sender, EventArgs e) {
            if (AllFieldsOk()) {
                SetUserData();
            }
        }

        private bool AllFieldsOk() {
            bool ok = CommonUserFieldsOK();
            if (particularFeature.Equals(Permission.HOLD_EXTRA_DATA)) {
                ok &= ClientFieldsOk();
            }
            return ok;
        }

        private bool ClientFieldsOk() {
            bool idOk = InputValidations.ValidateID(idText.Text, idMsg);
            bool telOk = InputValidations.ValidatePhoneNumber(telNumberText.Text, telNumberMsg);
            bool addressOk = InputValidations.ValidateIfEmpty(addressText, addressMsg);
            return idOk && telOk && addressOk;
        }

        private bool CommonUserFieldsOK() {
            bool userNameOk = IsUserNameValid();
            bool nameOk = InputValidations.ValidateIfEmpty(nameTxt, nameMsg);
            bool surnameOk = InputValidations.ValidateIfEmpty(surnameText, surnameMsg);
            bool passwordOk = InputValidations.ValidateIfEmpty(passwordText, passwordMsg);
            return userNameOk && nameOk && surnameOk && passwordOk;
        }

        private bool IsUserNameValid() {
            bool isValid = InputValidations.ValidateIfEmpty(userNameText,userNameMsg) && !RepeatedUser();
            return isValid;
        }

        private bool RepeatedUser() {
            bool repeated = false;
            if (permissionController.ExistsUserName(userNameText.Text)) {
                InputValidations.ErrorMessage(userNameMsg,"This name has been taken");
                repeated = true;
            }
            return repeated;
        }

        private void SetUserData() {
            if (particularFeature.Equals(Permission.HOLD_EXTRA_DATA))
            {
                CreateClient();
            }
            else if (particularFeature.Equals(Permission.CAN_SIGN_BLUEPRINT))
            {
                CreateArchitect();
            }
            else {
                CreateDesigner();
            }

        }

        private void CreateDesigner() {
            string userName = userNameText.Text;
            string name = nameTxt.Text;
            string surname = surnameText.Text;
            string pass = passwordText.Text;
            User created = new Designer(name, surname, userName, pass, DateTime.Now);
            Register(created);
        }

        private void CreateClient() {
            string userName = userNameText.Text;
            string name = nameTxt.Text;
            string surname = surnameText.Text;
            string pass = passwordText.Text;
            string id = idText.Text;
            string tel = telNumberText.Text;
            string address = addressText.Text;
            User created = new Client(name, surname, userName, pass, tel, address, id, DateTime.Now);
            Register(created);
        }

        private void CreateArchitect() {
            string userName = userNameText.Text;
            string name = nameTxt.Text;
            string surname = surnameText.Text;
            string pass = passwordText.Text;
            User created= new Architect(name, surname, userName, pass, DateTime.Now);
            Register(created);
        }

        private void Register(User created) {
            permissionController.Add(created);
            parent.RestartMenu();
        }

        

        private void idText_Enter(object sender, EventArgs e) {
            InputValidations.ClearField(idMsg);
        }

        private void telNumberText_Enter(object sender, EventArgs e) {
            InputValidations.ClearField(telNumberMsg);
        }

        private void addressText_Enter(object sender, EventArgs e) {
            InputValidations.ClearField(addressMsg);
        }

        private void nameTxt_Enter(object sender, EventArgs e) {
            InputValidations.ClearField(nameMsg);
        }

        private void surnameText_Enter(object sender, EventArgs e) {
            InputValidations.ClearField(surnameMsg);
        }

        private void passwordText_Enter(object sender, EventArgs e) {
            InputValidations.ClearField(passwordMsg);
        }

        private void userNameText_Enter(object sender, EventArgs e) {
            InputValidations.ClearField(userNameMsg);
        }

        private void telNumberText_Leave(object sender, EventArgs e) {
            InputValidations.ValidatePhoneNumber(telNumberText.Text, telNumberMsg);
        }
        private void idText_Leave(object sender, EventArgs e) {
            InputValidations.ValidateID(idText.Text, idMsg);
        }
        
        private void addressText_Leave(object sender, EventArgs e) {
            InputValidations.ValidateIfEmpty(addressText, addressMsg);
        }

        private void nameTxt_Leave(object sender, EventArgs e) {
            InputValidations.ValidateIfEmpty(nameTxt, nameMsg);
        }

        private void surnameText_Leave(object sender, EventArgs e) {
            InputValidations.ValidateIfEmpty(surnameText, surnameMsg);
        }
       
        private void passwordText_Leave(object sender, EventArgs e) {
            InputValidations.ValidateIfEmpty(passwordText, passwordMsg);
        }

        private void userNameText_Leave(object sender, EventArgs e) {
            IsUserNameValid();
        }

    }
}
