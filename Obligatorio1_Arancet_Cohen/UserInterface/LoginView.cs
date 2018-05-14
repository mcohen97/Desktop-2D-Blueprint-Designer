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
    public partial class LoginView : UserControl {

        SessionConnector connector;
        MainWindow mother;

        public LoginView(MainWindow aWindow) {

            InitializeComponent();
            mother = aWindow;
            connector = new SessionConnector();
            PasswordText.PasswordChar = '*';

        }

        private void LogInButton_Click(object sender, EventArgs e) {
            bool usernameNotEmpty = InputValidations.ValidateIfEmpty(UsernameText, UserNameMsg);
            bool passwordNotEmpty= InputValidations.ValidateIfEmpty(PasswordText, PasswordMsg);
            if (usernameNotEmpty && passwordNotEmpty) {
                TryToLogIn();
            }  
        }

        private void TryToLogIn() {
            try {
                mother.CurrentSession = connector.LogIn(UsernameText.Text, PasswordText.Text);
                mother.GoToMenu();
            } catch (WrongPasswordException) {
                InputValidations.ErrorMessage(PasswordMsg, "Wrong Password!");
            } catch (UserNotFoundException) {
                InputValidations.ErrorMessage(UserNameMsg, "User doesn't exist!");
            }
        }

        private void UsernameText_TextChanged(object sender, EventArgs e) {
            InputValidations.ClearField(UserNameMsg);
        }

        private void PasswordText_TextChanged(object sender, EventArgs e) {
            InputValidations.ClearField(PasswordMsg);
        }


        private void UsernameText_Leave(object sender, EventArgs e) {
            InputValidations.ValidateIfEmpty(UsernameText, UserNameMsg);
        }

        private void PasswordText_Leave(object sender, EventArgs e) {
            InputValidations.ValidateIfEmpty(PasswordText, PasswordMsg);
        }

        private void testDataButton_Click(object sender, EventArgs e) {
            SessionConnector connector = new SessionConnector();
            Session fakeSession= connector.LogIn("admin","admin");
            UserAdministrator administrator = new UserAdministrator(fakeSession);
            administrator.Add(new Client("user1", "user1", "user1", "user1", "1111-11-11", "user1", "1.111.111-1", DateTime.Now));
            administrator.Add(new Client("user2", "user2", "user2", "user2", "1111-11-11", "user2", "1.111.111-1", DateTime.Now));
            administrator.Add(new Designer("designer1","designer1","designer1","designer1",DateTime.Now));
            testDataButton.Hide();
       }


    }
}
