﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class WallEntity
    {
        public WallEntity() {
        }
        public float Height { get; set; }

        public float Width { get; set; }

        public PointEntity From { get; set; }

        public PointEntity To { get; set; }
        
    }
}
