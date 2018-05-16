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
    public partial class ChooseBlueprintView : UserControl, IUserFeatureControl {

        private Session CurrentSession { get; set; }
        private LoggedInView parent;
        private BlueprintController permissionController;

        public ChooseBlueprintView(Session aSession, LoggedInView aControl) {
            InitializeComponent();
            parent = aControl;
            CurrentSession = aSession;
            permissionController = new BlueprintController(CurrentSession);
        }

        public void SetUp() {
            FillList();
            SetButons();

        }

        private void FillList() {
            ICollection<IBlueprint> selectedBlueprints;
            if (IsDesigner()) {
                selectedBlueprints = permissionController.GetBlueprints();
            } else {
                selectedBlueprints = permissionController.GetBlueprints(CurrentSession.UserLogged);
            }
            blueprintList.DataSource = selectedBlueprints;
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

        public void SetSession(Session aSession) {
            CurrentSession = aSession;
        }

        

        private void SetButons() {
            if (IsDesigner()) {
                selectButton.Text = "Edit Blueprint";
                deleteButton.Show();
                selectButton.Click += new System.EventHandler(this.selectButton_ClickEdit);
                selectButton.Click -= new System.EventHandler(this.selectButton_ClickView);
            } else {
                selectButton.Text = "View Blueprint";
                deleteButton.Hide();
                selectButton.Click -= new System.EventHandler(this.selectButton_ClickEdit);
                selectButton.Click += new System.EventHandler(this.selectButton_ClickView);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e) {
            IBlueprint selected = (IBlueprint)blueprintList.SelectedItem;
            permissionController.Remove(selected);
        }

        private void selectButton_ClickEdit(object sender, EventArgs e) {
            Blueprint selectedCopy = (Blueprint)blueprintList.SelectedItem;
            //permissionController.
            parent.OpenBlueprintEditor(selectedCopy.Owner,selectedCopy);
        }

        private void selectButton_ClickView(object sender, EventArgs e) {
            //CANTU, HACE TU MAGIA
        }
    }
}
