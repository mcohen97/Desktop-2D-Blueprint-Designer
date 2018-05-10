using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using System.Windows.Forms;

namespace UserInterface {
    interface IUserFeatureControl {

        Permission GetRequiredPermission();

        void SetSession(Session aSession);

        Button OptionMenuButton();
    }
}
