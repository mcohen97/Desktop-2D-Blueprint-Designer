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
    public partial class CreateBlueprint : ChooseUserView {

        public CreateBlueprint() {
            InitializeComponent();
            optionName = "Create Blueprint";
        }

        public override Permission GetRequiredPermission() {
            return Permission.CREATE_BLUEPRINT;
        }

        public override void FillList() {
            foreach (User u in UsersPortfolio.Instance.GetUsers()) {
                Console.Write(u);
            }
            usersList.DataSource = UsersPortfolio.Instance.GetUsers();

        }
    }
}
