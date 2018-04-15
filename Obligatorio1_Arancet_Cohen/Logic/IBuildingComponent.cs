using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic{
    interface IBuildingComponent {
        float Height();

        float Width();

        float Length();

        Point Beginning();

        float Price();

    }
}
