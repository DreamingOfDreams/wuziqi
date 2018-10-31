using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test53
{
    class Chess
    {
        public static void DrawChess(bool type,PictureBox pic,Graphics gra,MouseEventArgs e)
        {
            gra = pic.CreateGraphics();
            Pen p1 = new Pen(Color.Black,1);
            Brush b1 = new SolidBrush(Color.Black);
            Pen p2 = new Pen(Color.White);
            Brush b2 = new SolidBrush(Color.White);
            int newX = ((e.X ) / MathSize.CBGap)*MathSize.CBGap + MathSize.CBGap / 2 - MathSize.ChessRadious / 2 ;
            int newY = ((e.Y ) / MathSize.CBGap)*MathSize.CBGap + MathSize.CBGap / 2 - MathSize.ChessRadious / 2 ;
            if(type)
            {
                gra.DrawEllipse(p1, newX, newY, MathSize.ChessRadious, MathSize.ChessRadious);
                gra.FillEllipse(b1, newX, newY, MathSize.ChessRadious, MathSize.ChessRadious);
            }
            if(!type)
            {
                gra.DrawEllipse(p2, newX, newY, MathSize.ChessRadious, MathSize.ChessRadious);
                gra.FillEllipse(b2, newX, newY, MathSize.ChessRadious, MathSize.ChessRadious);
            }
            // 释放Graphics的资源
            gra.Dispose();
        }
    }
}
