using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test53
{
    class ChessBoard
    {
        static Pen p = new Pen(Color.Black, 1.0f);

        public static void DrawCB(Graphics gra, PictureBox pic)
        {
            int row = MathSize.CBWid/MathSize.CBGap;
            int gap = MathSize.CBGap;
            Image img = new Bitmap(MathSize.PBWid,MathSize.PBHei);
            gra = Graphics.FromImage(img);
            gra.Clear(Color.DarkGoldenrod);
            gra.DrawRectangle(p, MathSize.CBGap / 2, MathSize.CBGap / 2, MathSize.CBWid, MathSize.CBHei);
            for (int i = 1; i < row; i++)
            {
                gra.DrawLine(p, MathSize.CBGap/2, i * gap+ MathSize.CBGap / 2, MathSize.CBWid+ MathSize.CBGap / 2, i * gap+ MathSize.CBGap / 2);
                gra.DrawLine(p, i * gap+ MathSize.CBGap / 2, MathSize.CBGap / 2, i * gap + MathSize.CBGap / 2, MathSize.CBHei + MathSize.CBGap / 2);
            }
           
            pic.Image = img;
        }
    }
}
