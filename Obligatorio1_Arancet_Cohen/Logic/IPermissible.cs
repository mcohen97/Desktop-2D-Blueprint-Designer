using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio1_Arancet_Cohen
{
    interface IPermissible
    {
        bool HasPermission(Permission permissionAsked);
    }
}
