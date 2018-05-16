using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain{

    interface IBuildingComponent {

        float Height();

        float Length();

        Point Beginning();

        float Price();

    }
}
