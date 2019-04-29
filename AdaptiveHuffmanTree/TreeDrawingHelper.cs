using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptiveHuffmanTree
{
    public static class TreeDrawingHelper
    {
        public static void DrawNode(this Graphics graphics, int posX, int posY, int diametr, string text)
        {
            SolidBrush brushCircle = new SolidBrush(Color.Black);
            SolidBrush brushText = new SolidBrush(Color.White);
            Font font = new Font("Calibri", 10, FontStyle.Bold);
            graphics.FillEllipse(brushCircle, posX, posY, diametr, diametr);
            graphics.DrawString(text, font, brushText, new Point(posX + diametr / 4, posY + diametr / 4));
        }
    }
}
