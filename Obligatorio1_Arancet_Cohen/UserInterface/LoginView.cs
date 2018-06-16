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
using DataAccessExceptions;
using ServicesExceptions;
using Services;

namespace UserInterface
{
    public partial class LoginView : UserControl
    {

        SessionConnector connector;
        MainWindow mother;
        bool dataGenerated;

        public LoginView(MainWindow aWindow, bool dataAlreadyGenerated)
        {

            InitializeComponent();
            mother = aWindow;
            connector = new SessionConnector();
            dataGenerated = dataAlreadyGenerated;
            PasswordText.PasswordChar = '*';
            if (dataGenerated)
            {
                testDataButton.Hide();
            }

        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            bool usernameNotEmpty = InputValidations.ValidateIfEmpty(UsernameText, UserNameMsg);
            bool passwordNotEmpty = InputValidations.ValidateIfEmpty(PasswordText, PasswordMsg);
            if (usernameNotEmpty && passwordNotEmpty)
            {
                TryToLogIn();
            }
        }

        private void TryToLogIn()
        {
            try
            {
                mother.CurrentSession = connector.LogIn(UsernameText.Text, PasswordText.Text);
                mother.GoToMenu();
            }
            catch (WrongPasswordException)
            {
                InputValidations.ErrorMessage(PasswordMsg, "Wrong Password!");
            }
            catch (UserNotFoundException)
            {
                InputValidations.ErrorMessage(UserNameMsg, "User doesn't exist!");
            }
        }

        private void UsernameText_TextChanged(object sender, EventArgs e)
        {
            InputValidations.ClearField(UserNameMsg);
        }

        private void PasswordText_TextChanged(object sender, EventArgs e)
        {
            InputValidations.ClearField(PasswordMsg);
        }


        private void UsernameText_Leave(object sender, EventArgs e)
        {
            InputValidations.ValidateIfEmpty(UsernameText, UserNameMsg);
        }

        private void PasswordText_Leave(object sender, EventArgs e)
        {
            InputValidations.ValidateIfEmpty(PasswordText, PasswordMsg);
        }

        private void testDataButton_Click(object sender, EventArgs e)
        {
            if (!dataGenerated)
            {
                GenerateTestData();
            }
            dataGenerated = true;
            mother.testDataAlreadyGenerated = true;
        }

        private void GenerateTestData()
        {
            SessionConnector connector = new SessionConnector();
            Session fakeSession = connector.LogIn("admin", "admin");
            UserAdministrator uAdministrator = new UserAdministrator(fakeSession);
            Client c1 = new Client("Enzo", "Ferreira", "testClient1", "password", "9595-01-73", "Colonia Ofir 7763", "4.435.511-2", DateTime.Now);
            Client c2 = new Client("Camila", "Pinto", "testClient2", "password", "9780-93-03", "Florianapolis 7256", "2.817.601-3", DateTime.Now);
            Client c3 = new Client("Isabelle", "Gomes", "testClient3", "password", "9610-94-47", "Colombes 1092", "1.429.972-1", DateTime.Now);
            Designer d1 = new Designer("Fabrizio ", "Ferrari", "testDesigner1", "password", DateTime.Now);
            Designer d2 = new Designer("Nazzareno ", "Iadanza", "testDesigner2", "password", DateTime.Now);
            uAdministrator.Add(c1);
            uAdministrator.Add(c2);
            uAdministrator.Add(c3);
            uAdministrator.Add(d1);
            uAdministrator.Add(d2);
            fakeSession = connector.LogIn("testDesigner1", "password");
            BlueprintController bpController = new BlueprintController(fakeSession);
            Blueprint bp1 = new Blueprint(8, 8, "Mi tablero de ajedrez gigante");
            bp1.Owner = c1;
            Blueprint bp2 = new Blueprint(10, 10, "oficina nueva");
            bp2.Owner = c2;
            Blueprint bp3 = new Blueprint(6, 5, "Barbacoa en el fondo");
            bp3.Owner = c2;
            bpController.Add(bp1);
            bpController.Add(bp2);
            bpController.Add(bp3);

            testDataButton.Hide();
        }
    }
}
