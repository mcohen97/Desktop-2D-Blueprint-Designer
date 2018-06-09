using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PointEntity
    {
        public Guid Id { get; set; }
        public float CoordX { get; set; }

        public float CoordY { get; set; }
    }
}
