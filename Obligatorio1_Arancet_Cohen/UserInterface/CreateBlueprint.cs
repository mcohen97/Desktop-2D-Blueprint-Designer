using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace UserInterface {
    public partial class CreateBlueprint : UserControl, IUserFeatureControl {

        LoggedInView parent;
        Session CurrentSession { get; set; }
        UserAdministrator permissionController;

        public CreateBlueprint(Session aSession, LoggedInView aControl) {
            InitializeComponent();
            parent = aControl;
            CurrentSession = aSession;
            permissionController = new UserAdministrator(CurrentSession);
        }


        public void FillList() {
            ICollection<User> clients = permissionController.GetAllClients();
            usersList.DataSource = clients;
        }

        private void createButton_Click(object sender, EventArgs e) {
            if (InputValidations.IsListItemSelected(usersList,listMsg,"You must choose a user first")) {

                bool validWidth = InputValidations.ValidateGreaterThanZero(widthField.Text, widthMsg,
                    "width must be greater than zero");
                bool validLength= InputValidations.ValidateGreaterThanZero(widthField.Text, lengthMsg,
                    "length must be greater than zero");
                bool validName = InputValidations.ValidateIfEmpty(nameText, nameMsg);

                if (validName && validWidth && validLength) {
                    CreateAndEditBlueprint();
                }
                
            }
        }

        private void CreateAndEditBlueprint() {
            int width = Int32.Parse(widthField.Text);
            int length = Int32.Parse(lengthField.Text);
            string name = nameText.Text;
            Blueprint created = new Blueprint(length, width, name);
            created.Owner = (Client)usersList.SelectedItem;

            BlueprintController bpAdmin = new BlueprintController(CurrentSession);
            bpAdmin.Add(created);

            parent.OpenBlueprintEditor(usersList.SelectedItem,created );
        }

        public Permission GetRequiredPermission() {
            return Permission.CREATE_BLUEPRINT;
        }

        public Button OptionMenuButton() {
            Button optionButton = new Button();
            optionButton.Width = 100;
            optionButton.Height = 50;
            optionButton.Text = "Create blueprint";
            return optionButton;
        }

        public void SetUp() {
            FillList();
            nameText.Text = "";
            widthField.Text = "";
            lengthField.Text = "";
        }

        private void nameText_Enter(object sender, EventArgs e) {
            InputValidations.ClearField(nameMsg);
        }

        private void nameText_Leave(object sender, EventArgs e) {
            InputValidations.ValidateIfEmpty(nameText, nameMsg);
        }

        private void widthField_Enter(object sender, EventArgs e) {
            InputValidations.ClearField(widthMsg);
        }

        private void widthField_Leave(object sender, EventArgs e) {
            InputValidations.ValidateGreaterThanZero(widthField.Text, widthMsg, "width must be greater than zero");
        }

        private void lengthField_Enter(object sender, EventArgs e) {
            InputValidations.ClearField(lengthMsg);
        }

        private void lengthField_Leave(object sender, EventArgs e) {
            InputValidations.ValidateGreaterThanZero(lengthField.Text, lengthMsg, "length must be greater than zero");
        }
    }
}
