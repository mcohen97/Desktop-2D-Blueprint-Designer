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
using DataAccess;
using DomainRepositoryInterface;
using RepositoryInterface;

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
                IUserRepository users = new UserRepository();
                mother.CurrentSession = connector.LogIn(UsernameText.Text, PasswordText.Text,users);
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
                try
                {
                    GenerateTestData();
                }catch (Exception)
                {

                }
            }
            dataGenerated = true;
            mother.testDataAlreadyGenerated = true;
        }

        private void GenerateTestData()
        {
            IUserRepository users = new UserRepository();   
            SessionConnector connector = new SessionConnector();
            Session fakeSession = connector.LogIn("admin", "admin",users);
            UserAdministrator uAdministrator = new UserAdministrator(fakeSession, (IRepository<User>)users);
            Client c1 = new Client("Enzo", "Ferreira", "testClient1", "password", "9595-01-73", "Colonia Ofir 7763", "4.435.511-2", DateTime.Now);
            Client c2 = new Client("Camila", "Pinto", "testClient2", "password", "9780-93-03", "Florianapolis 7256", "2.817.601-3", DateTime.Now);
            Client c3 = new Client("Isabelle", "Gomes", "testClient3", "password", "9610-94-47", "Colombes 1092", "1.429.972-1", DateTime.Now);
            Designer d1 = new Designer("Fabrizio ", "Ferrari", "testDesigner1", "password", DateTime.Now);
            Designer d2 = new Designer("Nazzareno ", "Iadanza", "testDesigner2", "password", DateTime.Now);
            Architect archy = new Architect("Gustave", "Eiffel", "testArchitect1", "password", DateTime.Now);
            uAdministrator.Add(archy);
            uAdministrator.Add(c1);
            uAdministrator.Add(c2);
            uAdministrator.Add(c3);
            uAdministrator.Add(d1);
            uAdministrator.Add(d2);
            fakeSession = connector.LogIn("testDesigner1", "password",users);
            IRepository<IBlueprint> bpStorage = new BlueprintRepository();
            BlueprintController bpController = new BlueprintController(fakeSession,bpStorage);
            Blueprint bp1 = new Blueprint(8, 8, "Mi tablero de ajedrez gigante");
            bp1.InsertWall(new Logic.Domain.Point(1, 1), new Logic.Domain.Point(1, 5));
            bp1.InsertWall(new Logic.Domain.Point(2, 2), new Logic.Domain.Point(5, 2));
            bp1.Sign(archy);
            bp1.Owner = c1;
            Blueprint bp2 = new Blueprint(10, 10, "oficina nueva");
            bp2.InsertWall(new Logic.Domain.Point(3, 3), new Logic.Domain.Point(3, 1));
            bp2.InsertWall(new Logic.Domain.Point(1, 1), new Logic.Domain.Point(1, 5));
            bp2.Owner = c2;
            Blueprint bp3 = new Blueprint(6, 5, "Barbacoa en el fondo");
            bp3.InsertWall(new Logic.Domain.Point(2, 2), new Logic.Domain.Point(5, 2));
            bp3.InsertWall(new Logic.Domain.Point(3, 3), new Logic.Domain.Point(3, 1));
            bp3.Owner = c2;
            bpController.Add(bp1);
            bpController.Add(bp2);
            bpController.Add(bp3);
            IPriceCostRepository prices = new PriceCostRepository();
            prices.AddCostPrice((int)ComponentType.WALL, 50, 100);
            prices.AddCostPrice((int)ComponentType.BEAM, 50, 100);
            prices.AddCostPrice((int)ComponentType.DOOR, 50, 100);
            prices.AddCostPrice((int)ComponentType.WINDOW, 50, 75);
            prices.AddCostPrice((int)ComponentType.COLUMN, 25, 50);
            testDataButton.Hide();
        }
    }
}
