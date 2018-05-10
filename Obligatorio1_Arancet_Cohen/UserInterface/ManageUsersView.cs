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
    public partial class ManageUsersView : UserControl, IUserFeatureControl {

        public ManageUsersView() {
            InitializeComponent();
        }

        public Permission GetRequiredPermission() {
            return Permission.ALL_PERMISSIONS;
        }

        public Button OptionMenuButton() {
            Button option = new Button();
            option.Width = 100;
            option.Height = 50;
            option.Text = "Manage users";
            return option;
        }

        public void SetSession(Session aSession) {
            throw new NotImplementedException();
        }
    }
}
