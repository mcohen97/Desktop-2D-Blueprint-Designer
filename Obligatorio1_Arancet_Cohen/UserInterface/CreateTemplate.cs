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
using DataAccessExceptions;

namespace UserInterface
{
    public partial class CreateTemplate : UserControl, IUserFeatureControl
    {

        private ComponentType typeCreated;
        private MainWindow mother;

        public CreateTemplate(MainWindow aWindow)
        {
            InitializeComponent();
            typeCreated = ComponentType.WINDOW;
            WindowOption.Checked = true;
            mother = aWindow;
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
            nameText.Text = "";
            spinnerHeight.Value = spinnerHeight.Minimum;
            spinnerLength.Value = spinnerLength.Minimum;
            spinnerHeightAboveFloor.Value = spinnerHeightAboveFloor.Minimum;
        }

        private void ClearMessages() {
            msgLabel.Text = "";
        }

        private void spinnerHeight_ValueChanged(object sender, EventArgs e)
        {
            spinnerHeightAboveFloor.Maximum = (decimal)Constants.WALL_HEIGHT - (decimal)spinnerHeight.Value;
            ClearMessages();
        }

        private void spinnerHeightAboveFloor_ValueChanged(object sender, EventArgs e)
        {
            spinnerHeight.Maximum = (decimal)Constants.WALL_HEIGHT - (decimal)spinnerHeightAboveFloor.Value;
            ClearMessages();
        }

        private void WindowOption_CheckedChanged(object sender, EventArgs e)
        {
            typeCreated = ComponentType.WINDOW;
            ClearMessages();
        }

        private void doorOption_CheckedChanged(object sender, EventArgs e)
        {
            typeCreated = ComponentType.DOOR;
            ClearMessages();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                CreateTemplateAndSave();
            }
            catch (InvalidTemplateException ex) {
                InputValidations.ErrorMessage(msgLabel, ex.ToString());
            }
            catch (TemplateAlreadyExistsException ex) {
                InputValidations.ErrorMessage(msgLabel, ex.ToString());
            }
        }

        private void CreateTemplateAndSave() {
            
            //the purpose of dataOk is the in-field message displays
            if (DataOk())
            {
                string tempName = nameText.Text;
                float length = (float)spinnerLength.Value;
                float height = (float)spinnerHeight.Value;
                float heightAboveFloor = (float)spinnerHeightAboveFloor.Value;
                Template created = new Template(tempName, length, heightAboveFloor, height, typeCreated);
                IRepository<Template> templateStorage = new OpeningTemplateRepository();
                templateStorage.Add(created);
                mother.GoToMenu();
            }
        }

        private bool DataOk()
        {
            bool nameOk = InputValidations.ValidateIfEmpty(nameText, msgName);
            float heightSums = (float)(spinnerHeightAboveFloor.Value + spinnerHeight.Value);
            bool heightSumsOk = InputValidations.ValidateStrictMinor(heightSums, Constants.WALL_HEIGHT, msgHeight,
                "height plus elevation can't be higher than wall: " + Constants.WALL_HEIGHT + " m");
            bool allOk = nameOk && heightSumsOk;
            return allOk;

        }

      

        private void nameText_Enter(object sender, EventArgs e)
        {
            ClearMessages();
            InputValidations.ClearField(msgName);
        }

        private void spinnerLength_ValueChanged(object sender, EventArgs e)
        {
            ClearMessages();
        }

        private void nameText_Leave(object sender, EventArgs e)
        {
            InputValidations.ValidateIfEmpty(nameText, msgName);
        }

        private void spinnerLength_Enter(object sender, EventArgs e)
        {
            InputValidations.ClearField(msgHeight);
        }
    }
}
