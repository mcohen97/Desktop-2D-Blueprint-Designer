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
            if (usersList.SelectedIndex != -1) {
                string width = widthText.Text;
                int _width = 0;
                Int32.TryParse(width, out _width);
                string height = heightText.Text;
                int _height = 0;
                Int32.TryParse(height, out _height);
                string name = nameText.Text;
                parent.OpenBlueprintEditor(usersList.SelectedItem, new Blueprint(_width,_height,name));
            }
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
        }
    }
}
