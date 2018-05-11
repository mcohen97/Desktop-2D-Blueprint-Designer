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
    public partial class ManageUsers : ChooseUserView {
        public ManageUsers() {
            InitializeComponent();
            optionName = "Manage Users";
        }

        public override Permission GetRequiredPermission() {
            return Permission.CREATE_USER;
        }

        public override void FillList() {
            usersList.DataSource = UsersPortfolio.Instance.GetUsers();
        }
    }
}
