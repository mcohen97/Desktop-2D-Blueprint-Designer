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
using Services;
using DomainRepositoryInterface;
using DataAccess;

namespace UserInterface
{
    public partial class ManageCostsView : UserControl, IUserFeatureControl
    {

        private LoggedInView parent;
        private CostsAndPricesManager costsNprices;
        private Session current;

        public ManageCostsView(LoggedInView aControl,Session aSession)
        {
            InitializeComponent();
            parent = aControl;
            current = aSession;
            IPriceCostRepository catalog = new PriceCostRepository();
            costsNprices = new CostsAndPricesManager(current,catalog);
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
           ComponentType selectedMaterial = (ComponentType)materialsList.SelectedItem;
            costSpinner.Value = (decimal)costsNprices.GetCost((int)selectedMaterial);
            priceSpinner.Value = (decimal)costsNprices.GetPrice((int)selectedMaterial);
            costPriceInfo.Show();
        }

        private void changePriceButton_Click(object sender, EventArgs e)
        {
           ComponentType selectedMaterial = (ComponentType)materialsList.SelectedItem;
            float newCost = (float)costSpinner.Value;
            float newPrice= (float)priceSpinner.Value;
            costsNprices.SetCost((int)selectedMaterial, newCost);
            costsNprices.SetPrice((int)selectedMaterial, newPrice);
            costPriceInfo.Hide();
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
