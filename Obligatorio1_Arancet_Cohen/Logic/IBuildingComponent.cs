using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic{
    interface IBuildingComponent {
        int Height();

        int Width();

        int Length();

        Point Beginning();

        Point End();

        int UnitPrice();

    }
}
