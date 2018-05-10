using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace UserInterface {
    interface IUserFeatureControl {

        Permission GetRequiredPermission();

    }
}
