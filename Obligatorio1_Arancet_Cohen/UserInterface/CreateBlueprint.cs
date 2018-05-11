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

        public CreateBlueprint(Session aSession, LoggedInView aControl) {
            InitializeComponent();
            parent = aControl;
            CurrentSession = aSession;
            FillList();
        }


        public void FillList() {
            ICollection<User> allUsers = UsersPortfolio.Instance.GetUsers();
            ICollection<User> elegibleUsers = allUsers.Where(u => u.HasPermission(Permission.HAVE_BLUEPRINT)).ToList();
            usersList.DataSource = elegibleUsers;
        }

        private void createButton_Click(object sender, EventArgs e) {
            if (usersList.SelectedIndex != -1) {
                string width = widthText.Text;
                int _width = 0;
                Int32.TryParse(width, out _width);
                string height = heightText.Text;
                int _height = 0;
                Int32.TryParse(width, out _height);
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

    }
}
