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
using DataAccess;
using RepositoryInterface;

namespace UserInterface {
    public partial class ChooseBlueprintView : UserControl, IUserFeatureControl {

        private Session CurrentSession { get; set; }
        private LoggedInView parent;
        private BlueprintController permissionController;

        public ChooseBlueprintView(Session aSession, LoggedInView aControl) {
            InitializeComponent();
            parent = aControl;
            CurrentSession = aSession;
            IRepository<IBlueprint> bpStorage = new BlueprintRepository();
            permissionController = new BlueprintController(CurrentSession, bpStorage);
        }

        public void SetUp() {
            FillList();
            SetButons();

        }

        private void FillList() {
            ShowBlueprints();
            EnableSignaturesIfApply();

        }


        private void ShowBlueprints() {
            ICollection<IBlueprint> selectedBlueprints;
            if (IsArchitect())
            {
                selectedBlueprints = permissionController.GetBlueprints();
            }
            else if (IsDesigner()) {
                selectedBlueprints = permissionController.GetBlueprints().Where(bp => !bp.IsSigned()).ToList();

            }
            else
            {
                selectedBlueprints = permissionController.GetBlueprints(CurrentSession.UserLogged);
            }
            blueprintList.DataSource = selectedBlueprints;

        }


        private void EnableSignaturesIfApply()
        {
            if (IsArchitect() || IsClient())
            {
                signaturesList.Show();
                stateLabel.Show();
                ShowSignatures();
            }
            else {
                signaturesList.Hide();
                stateLabel.Hide();
            }
        }

        public Permission GetRequiredPermission() {
            return Permission.READ_BLUEPRINT;
        }

        public Button OptionMenuButton() {
            Button option;
            string optionTitle;
            if (IsDesigner()) {
                optionTitle = "Edit Blueprint";
            } else {
                optionTitle = "View Blueprint";
            }
            option = ButtonCreator.GenerateButton(optionTitle);
            return option;
        }

        private bool IsDesigner() {
            return CurrentSession.UserLogged.HasPermission(Permission.CREATE_BLUEPRINT);
        }

        private bool IsArchitect() {
            return CurrentSession.UserLogged.HasPermission(Permission.CAN_SIGN_BLUEPRINT);
        }

        private bool IsClient() {
            return CurrentSession.UserLogged.HasPermission(Permission.HAVE_BLUEPRINT);
        }

        public void SetSession(Session aSession) {
            CurrentSession = aSession;
        }

        

        private void SetButons() {
            if (IsDesigner() || IsArchitect()) {
                selectButton.Text = "Edit Blueprint";
                deleteButton.Show();
            } else {
                selectButton.Text = "View Blueprint";
                deleteButton.Hide();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e) {
            IBlueprint selected = (IBlueprint)blueprintList.SelectedItem;
            if (selected != null)
            {
                permissionController.Remove(selected);
                FillList();
            }
        }

        private void selectButton_Click(object sender, EventArgs e) {
            Blueprint selectedCopy = (Blueprint)blueprintList.SelectedItem;
            //permissionController.
            if (selectedCopy != null)
            {
                parent.OpenBlueprintViewer(selectedCopy);
            }
        }

        private void blueprintList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (blueprintList.SelectedIndex != -1)
            {
                ShowSignatures();
            }
        }

        private void ShowSignatures()
        {
            IBlueprint selected = (Blueprint)blueprintList.SelectedItem;
            if (selected != null)
            {
                if (selected.IsSigned())
                {
                    signaturesList.Show();
                    stateLabel.Text = "State: SIGNED";
                    signaturesList.DataSource = selected.GetSignatures();
                }
                else
                {
                    signaturesList.Hide();
                    stateLabel.Text = "State: NO SIGNED";
                }
            }
        }
    }
}
