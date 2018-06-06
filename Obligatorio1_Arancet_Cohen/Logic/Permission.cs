using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain
{
    public enum Permission
    {
        ALL_PERMISSIONS,
        READ_BLUEPRINT,
        EDIT_BLUEPRINT,
        DELETE_BLUEPRINT,
        CREATE_BLUEPRINT,
        EDIT_USER,
        REMOVE_USER,
        CREATE_USER,
        READ_USER,
        READ_OWNEDBLUEPRINT,
        HOLD_EXTRA_DATA,
        FIRST_LOGIN,
        MANAGE_COSTS,
        HAVE_BLUEPRINT,
        EDIT_OWN_DATA,
        CAN_SIGN_BLUEPRINT
    }
}
