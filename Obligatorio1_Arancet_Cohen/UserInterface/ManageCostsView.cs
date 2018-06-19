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

namespace UserInterface
{
    public partial class ManageCostsView : UserControl, IUserFeatureControl
    {

        private LoggedInView parent;

        public ManageCostsView(LoggedInView aControl)
        {
            InitializeComponent();
            parent = aControl;
            costPriceInfo.Hide();
        }

        private void FillList()
        {
            materialsList.DataSource = Enum.GetValues(typeof(ComponentType));
        }

        public Permission GetRequiredPermission()
        {
            return Permission.MANAGE_COSTS;
        }

        public Button OptionMenuButton()
        {
            return ButtonCreator.GenerateButton("Manage material prices and costs");
        }

        public void SetSession(Session aSession)
        {
            throw new NotImplementedException();
        }

        private void materialsList_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* ComponentType selectedMaterial = (ComponentType)materialsList.SelectedItem;
            costSpinner.Value = (decimal)Constants.COST_CATALOGUE[selectedMaterial];
            priceSpinner.Value = (decimal)Constants.PRICE_CATALOGUE[selectedMaterial];
            costPriceInfo.Show();*/
        }

        private void changePriceButton_Click(object sender, EventArgs e)
        {
           /* ComponentType selectedMaterial = (ComponentType)materialsList.SelectedItem;
            Constants.COST_CATALOGUE[selectedMaterial] = (float)costSpinner.Value;
            Constants.PRICE_CATALOGUE[selectedMaterial] = (float)priceSpinner.Value;
            costPriceInfo.Hide();*/
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            parent.RestartMenu();
        }

        public void SetUp()
        {
            FillList();
        }
    }
}
