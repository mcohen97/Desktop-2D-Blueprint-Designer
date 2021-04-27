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
using RepositoryInterface;
using DataAccess;

namespace UserInterface
{
    public partial class UserDataVerificationView : UserControl, IUserFeatureControl
    {

        private User edited;
        public MainWindow parent;
        public UserDataVerificationView(User aUser, MainWindow aWindow)
        {
            InitializeComponent();
            parent = aWindow;
            edited = aUser;
            ShowData();
        }

        private void ShowData()
        {
            SetCommonData();
            if (edited.HasPermission(Permission.HOLD_EXTRA_DATA))
            {
                onlyClientFields.Show();//this would be Client case
                userInfo.Show();
                SetUserData();
            }
            else
            {
                onlyClientFields.Hide();
                ShowOrHideUserData();
            }

        }

        private void ShowOrHideUserData()
        {
       
            if (!AdminEditsItself() && !AdminEditsOtherUser())
            {
                //in this case it is a designer
                nameTxt.ReadOnly = true;
                surnameText.ReadOnly = true;
            }
            else
            {
                nameTxt.ReadOnly = false;
                surnameText.ReadOnly = false;
            }

        }
        private bool AdminEditsItself()
        {
            return edited.HasPermission(Permission.CREATE_USER);
        }
        private bool AdminEditsOtherUser()
        {
            return parent.CurrentSession.UserLogged.HasPermission(Permission.CREATE_USER);
        }

        private void SetCommonData()
        {
            SetControlTitle();
            nameTxt.Text = edited.Name;
            surnameText.Text = edited.Surname;
            passwordText.Text = edited.Password;
            UsernameLabel.Text = edited.UserName;
            if (IsBeingEdited())
            {
                passwordText.PasswordChar = '*';
            }
            else
            {
                passwordText.PasswordChar = '\0';
            }
        }

        private void SetControlTitle()
        {
            if (edited.HasPermission(Permission.FIRST_LOGIN))
            {
                viewTitle.Text = "Verify and edit your information";
            }
            else
            {
                viewTitle.Text = "User information ";
            }
        }

        private void SetUserData()
        {
            Client logged = (Client)edited;
            idText.Text = logged.Id;
            telNumberText.Text = logged.Phone;
            addressText.Text = logged.Address;
        }

        public Permission GetRequiredPermission()
        {
            return Permission.EDIT_OWN_DATA;
        }

        public Button OptionMenuButton()
        {
            return ButtonCreator.GenerateButton("Edit personal information");
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            if (AllFieldsOk())
            {
                UpdateInfo();
                IRepository<User> usersStorage = new UserRepository();
                usersStorage.Modify(edited);
                parent.CurrentSession.FirstLogin = false;
                parent.GoToMenu();
            }
        }

        private void UpdateInfo()
        {
            UpdateCommonInformation();
            if (edited.HasPermission(Permission.HOLD_EXTRA_DATA))
            {
                UpdateClientInformation();
            }
        }

        private bool AllFieldsOk()
        {
            bool ok = CommonDataOk();
            if (edited.HasPermission(Permission.HOLD_EXTRA_DATA))
            {
                ok &= ClientDataOk();
            }
            return ok;
        }

        private bool CommonDataOk()
        {
            bool nameOk = InputValidations.ValidateIfEmpty(nameTxt, nameMsg);
            bool surnameOk = InputValidations.ValidateIfEmpty(surnameText, surnameMsg);
            bool passwordOk = InputValidations.ValidateIfEmpty(passwordText, passwordMsg);
            return nameOk && surnameOk && passwordOk;
        }

        private bool ClientDataOk()
        {
            bool idOk = InputValidations.ValidateID(idText.Text, idMsg);
            bool phoneOk = InputValidations.ValidatePhoneNumber(telNumberText.Text, telNumberMsg);
            bool addressOk = InputValidations.ValidateIfEmpty(addressText, addressMsg);
            return idOk && phoneOk && addressOk;
        }

        private void UpdateClientInformation()
        {
            Client updated = (Client)edited;
            updated.Id = idText.Text;
            updated.Address = addressText.Text;
            updated.Phone = telNumberText.Text;
        }

        private void UpdateCommonInformation()
        {
            edited.Name = nameTxt.Text;
            edited.Surname = surnameText.Text;
            edited.Password = passwordText.Text;
        }

        public void SetUp()
        {
            ShowData();
        }

        private bool IsBeingEdited()
        {
            return parent.CurrentSession.UserLogged.HasPermission(Permission.CREATE_USER);
        }

        private void passwordText_Leave(object sender, EventArgs e)
        {
            InputValidations.ValidateIfEmpty(passwordText, passwordMsg);
        }

        private void surnameText_Leave(object sender, EventArgs e)
        {
            InputValidations.ValidateIfEmpty(surnameText, surnameMsg);
        }

        private void nameTxt_Leave(object sender, EventArgs e)
        {
            InputValidations.ValidateIfEmpty(nameTxt, nameMsg);
        }

        private void idText_Leave(object sender, EventArgs e)
        {
            InputValidations.ValidateID(idText.Text, idMsg);
        }

        private void telNumberText_Leave(object sender, EventArgs e)
        {
            InputValidations.ValidatePhoneNumber(telNumberText.Text, telNumberMsg);
        }

        private void addressText_Leave(object sender, EventArgs e)
        {
            InputValidations.ValidateIfEmpty(addressText, addressMsg);
        }

        private void passwordText_Enter(object sender, EventArgs e)
        {
            InputValidations.ClearField(passwordMsg);
        }

        private void surnameText_Enter(object sender, EventArgs e)
        {
            InputValidations.ClearField(surnameMsg);
        }

        private void idText_Enter(object sender, EventArgs e)
        {
            InputValidations.ClearField(idMsg);
        }

        private void telNumberText_Enter(object sender, EventArgs e)
        {
            InputValidations.ClearField(telNumberMsg);
        }

        private void addressText_Enter(object sender, EventArgs e)
        {
            InputValidations.ClearField(addressMsg);
        }

        private void nameTxt_Enter(object sender, EventArgs e)
        {
            InputValidations.ClearField(nameMsg);

        }
    }
}
