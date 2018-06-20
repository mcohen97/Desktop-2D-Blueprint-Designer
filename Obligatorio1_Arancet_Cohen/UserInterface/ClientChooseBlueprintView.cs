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

namespace UserInterface {
    public partial class ClientChooseBlueprintView : UserControl, IUserFeatureControl {

        private Session CurrentSession { get; set; }
        private LoggedInView parent;
        private BlueprintController permissionController;

        public ClientChooseBlueprintView(Session aSession, LoggedInView aControl) {
            InitializeComponent();
            parent = aControl;
            CurrentSession = aSession;
            permissionController = new BlueprintController(CurrentSession);
        }

        public void SetUp() {
            FillList();
        }

        private void FillList() {
            ICollection<IBlueprint> selectedBlueprints;
            selectedBlueprints = permissionController.GetBlueprints(CurrentSession.UserLogged);
            blueprintList.DataSource = selectedBlueprints;
        }

        public Permission GetRequiredPermission() {
            return Permission.HAVE_BLUEPRINT;
        }

        public Button OptionMenuButton() {   
            return  ButtonCreator.GenerateButton("My Blueprints");
        }

        private void selectButton_ClickView(object sender, EventArgs e) {
            Blueprint selectedCopy = (Blueprint)blueprintList.SelectedItem;
            //permissionController.
            parent.OpenBlueprintViewer(selectedCopy);
        }
    }
}
