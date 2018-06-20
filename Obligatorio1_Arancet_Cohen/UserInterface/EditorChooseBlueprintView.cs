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
    public partial class EditorChooseBlueprintView : UserControl, IUserFeatureControl
    {
        private Session CurrentSession { get; set; }
        private LoggedInView parent;
        private BlueprintController permissionController;

        public EditorChooseBlueprintView(Session aSession, LoggedInView aControl)
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
            ShowUserBlueprints();
        }
        private void ShowUserBlueprints() {
            if (userList.SelectedIndex != -1)
            {
                User selected = (User)userList.SelectedItem;
                FillBlueprintsLists(selected);
            }
        }

        private void FillBlueprintsLists(User selected)
        {
            ICollection<IBlueprint> usersBlueprints = permissionController.GetBlueprints(selected);
            SetCommonLists(usersBlueprints);
            SetArchitectLists(usersBlueprints);


        }

        private void SetCommonLists(ICollection<IBlueprint> usersBlueprints) {
            ICollection<IBlueprint> unSigned = usersBlueprints.Where(bp => !bp.IsSigned()).ToList();
            unSignedList.DataSource = unSigned;
            unSignedList.ClearSelected();
        }

        private void SetArchitectLists(ICollection<IBlueprint> usersBlueprints) {
            if (CurrentSession.UserLogged.HasPermission(Permission.CAN_SIGN_BLUEPRINT))
            {
                ICollection<IBlueprint> signed = usersBlueprints.Where(bp => bp.IsSigned()).ToList();
                signedList.DataSource = signed;
                signedList.ClearSelected();
            }
            else {
                signedList.Hide();
                signatureLists.Hide();
            }

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (!(signedList.SelectedIndex == -1 && unSignedList.SelectedIndex == -1))
            {
                IBlueprint selected = GetSelectedBlueprint();
                parent.OpenBlueprintEditor((Blueprint)selected);
                
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (!(signedList.SelectedIndex == -1 && unSignedList.SelectedIndex == -1))
            {
                IBlueprint selected = GetSelectedBlueprint();
                permissionController.Remove(selected);
                ShowUserBlueprints();
            }
        }

        private IBlueprint GetSelectedBlueprint() {
            IBlueprint selected;
            if (signedList.SelectedIndex == -1 && unSignedList.SelectedIndex != -1) {
                selected = (IBlueprint)unSignedList.SelectedItem;
            } else  {
                selected = (IBlueprint)signedList.SelectedItem;
            }
            return selected;
        }

        public Permission GetRequiredPermission()
        {
            return Permission.EDIT_BLUEPRINT;
        }

        public Button OptionMenuButton()
        {
            return ButtonCreator.GenerateButton("New Blueprint Edition ");
        }

        private void userList_SelectedIndexChanged(object sender, EventArgs e)
        {
            signatureLists.Hide();
            if (userList.SelectedIndex != -1)
            {
                User selected = (User)userList.SelectedItem;
                FillBlueprintsLists(selected);
           }
        }

        private void signedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            unSignedList.ClearSelected();
            if (signedList.SelectedIndex != -1)
            {
                signatureLists.Show();
                IBlueprint selected = (IBlueprint)signedList.SelectedItem;
                signatureLists.DataSource = selected.GetSignatures();
            }
        }

        private void unSignedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            signedList.ClearSelected();
        }

        
    }
}
