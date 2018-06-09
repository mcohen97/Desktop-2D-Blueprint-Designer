using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CostPriceEntity
    {
        public Guid Id { get; set; }
        public float Price { get; set; }

        public float Cost { get; set; }

        public int ComponentType { get; set; }
    }
}
