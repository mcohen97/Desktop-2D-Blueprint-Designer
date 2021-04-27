using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    public class Pencilcase
    {
        private Pen wallPen;
        private Pen beamPen;
        private Pen doorPen;
        private Pen windowPen;
        private Pen columnPen;

        public Pencilcase(Pen wallPen, Pen beamPen, Pen doorPen, Pen windowPen, Pen columnPen)
        {
            this.wallPen = wallPen;
            this.beamPen = beamPen;
            this.doorPen = doorPen;
            this.windowPen = windowPen;
            this.columnPen = columnPen;
        }

        public Pen WallPen {
            get {
                return wallPen;
            }

            set {
                wallPen = value;
            }
        }

        public Pen BeamPen {
            get {
                return beamPen;
            }

            set {
                beamPen = value;
            }
        }

        public Pen DoorPen {
            get {
                return doorPen;
            }

            set {
                doorPen = value;
            }
        }

        public Pen WindowPen {
            get {
                return windowPen;
            }

            set {
                windowPen = value;
            }
        }

        public Pen ColumnPen {
            get {
                return columnPen;
            }

            set {
                columnPen = value;
            }
        }
    }
}
