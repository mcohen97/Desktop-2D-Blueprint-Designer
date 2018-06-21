using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    public interface IGridPaintStrategy
    {
        void PaintGrid();
        void SetCountX(int xLines);
        void SetCountY(int yLines);
        void SetMargin(int marginLines);
        void SetLayer(Bitmap layerToDraw);
    }
}
