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
    public partial class ManageCostsView : UserControl, IUserFeatureControl {

        private LoggedInView parent;

        public ManageCostsView(LoggedInView aControl) {
            InitializeComponent();
            parent = aControl;
            FillList();
            costPriceInfo.Hide();
        }

        private void FillList() {
            materialsList.DataSource= Enum.GetValues(typeof(ComponentType));
        }

        public Permission GetRequiredPermission() {
            return Permission.MANAGE_COSTS;
        }

        public Button OptionMenuButton() {
            Button option = new Button();
            option.Width = 100;
            option.Height = 50;
            option.Text = "Manage material prices and costs";
            return option;
        }

        public void SetSession(Session aSession) {
            throw new NotImplementedException();
        }

        private void materialsList_SelectedIndexChanged(object sender, EventArgs e) {
            ComponentType selectedMaterial = (ComponentType)materialsList.SelectedItem;
            costSpinner.Value = (decimal)Constants.costCatalogue[selectedMaterial];
            priceSpinner.Value = (decimal)Constants.priceCatalogue[selectedMaterial];
            costPriceInfo.Show();
        }

        private void changePriceButton_Click(object sender, EventArgs e) {
            ComponentType selectedMaterial = (ComponentType)materialsList.SelectedItem;
            Constants.costCatalogue[selectedMaterial] = (float)costSpinner.Value;
            Constants.priceCatalogue[selectedMaterial] = (float)priceSpinner.Value;
            costPriceInfo.Hide();
        }

        private void doneButton_Click(object sender, EventArgs e) {
            parent.RestartMenu();
        }
    }
}
