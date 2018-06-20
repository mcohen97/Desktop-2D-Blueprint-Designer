using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;
using Logic.Domain;


namespace UserInterface
{
    public partial class NewEditBlueprintView : UserControl, IUserFeatureControl
    {
        private Session CurrentSession { get; set; }
        private LoggedInView parent;
        private BlueprintController permissionController;

        public NewEditBlueprintView(Session aSession, LoggedInView aControl)
        {
            InitializeComponent();
            parent = aControl;
            CurrentSession = aSession;
            permissionController = new BlueprintController(CurrentSession);
        }

        public void SetUp()
        {
            FillLists();
        }

        private void FillLists()
        {
            UserAdministrator administrator = new UserAdministrator(CurrentSession);
            userList.DataSource=administrator.GetUsersByPermission(Permission.HAVE_BLUEPRINT);
            signatureLists.Hide();
            if (userList.SelectedIndex != -1) {
                User selected = (User)userList.SelectedItem;
                FillBlueprintsLists(selected);
            }
        }

        private void FillBlueprintsLists(User selected)
        {
            ICollection<IBlueprint> usersBlueprints = permissionController.GetBlueprints().Where(bp => bp.Owner.Equals(selected)).ToList();
            ICollection<IBlueprint> signed = usersBlueprints.Where(bp => bp.IsSigned()).ToList();
            ICollection<IBlueprint> unSigned = usersBlueprints.Where(bp => !bp.IsSigned()).ToList();
            signedList.DataSource = signed;
            unSignedList.DataSource = unSigned;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }

        public Permission GetRequiredPermission()
        {
            return Permission.EDIT_BLUEPRINT;
        }

        public Button OptionMenuButton()
        {
            return ButtonCreator.GenerateButton("New Blueprint Edition ");
        }

       
    }
}
