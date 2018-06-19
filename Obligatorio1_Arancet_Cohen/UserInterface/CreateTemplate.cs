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
using DataAccess;
using DomainRepositoryInterface;
using RepositoryInterface;
using LogicExceptions;

namespace UserInterface
{
    public partial class CreateTemplate : UserControl, IUserFeatureControl
    {

        private ComponentType typeCreated;
        public CreateTemplate()
        {
            InitializeComponent();
            typeCreated = ComponentType.WINDOW;
            WindowOption.Checked = true;
        }

        public Permission GetRequiredPermission()
        {
            return Permission.EDIT_BLUEPRINT;
        }

        public Button OptionMenuButton()
        {
           return ButtonCreator.GenerateButton("Create new opening model");
        }

        public void SetUp()
        {
           //later
        }

        private void spinnerHeight_ValueChanged(object sender, EventArgs e)
        {
            spinnerHeightAboveFloor.Maximum = (decimal)2.9 - (decimal)spinnerHeight.Value;
        }

        private void spinnerHeightAboveFloor_ValueChanged(object sender, EventArgs e)
        {
            spinnerHeight.Maximum = (decimal)2.9 - (decimal)spinnerHeightAboveFloor.Value;

        }

        private void WindowOption_CheckedChanged(object sender, EventArgs e)
        {
            typeCreated = ComponentType.WINDOW;
        }

        private void doorOption_CheckedChanged(object sender, EventArgs e)
        {
            typeCreated = ComponentType.DOOR;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            string tempName = nameText.Text;
            float length = (float)spinnerLength.Value;
            float height = (float)spinnerHeight.Value;
            float heightAboveFloor = (float)spinnerHeightAboveFloor.Value;
            try
            {
                Template created = new Template(tempName, length, height, heightAboveFloor, typeCreated);
                IRepository<Template> templateStorage = new OpeningTemplateRepository();
                templateStorage.Add(created);
            }
            catch (InvalidDoorTemplateException ) {

            }
        }
    }
}
