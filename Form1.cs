using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test53
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graphics g;
        static bool type;
        static bool start;
        int[,] ChessBack = new int[MathSize.MaxNum, MathSize.MaxNum];

        private void Init()
        {
            for(int i=0;i< MathSize.MaxNum; i++)
            {
                for (int j = 0; j < MathSize.MaxNum; j++)
                    ChessBack[i, j] = 0;
            }
            start = false;
            label1.Text = "游戏未开始";
            label2.Text = "黑色";
            ChessBoard.DrawCB(g, pictureBox1);
            type = true;
            btnStart.Enabled = true;
            btnReset.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
        }



        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(start)
            {
                int boardX = e.X / MathSize.CBGap;
                int boardY = e.Y / MathSize.CBGap;
                //防止在同一位置落子
                if (ChessBack[boardX, boardY] !=0)
                    return;
                
                if(type)
                {
                    this.label2.Text = "白方";
                    ChessBack[boardX, boardY] = 1;
                }
                else
                {
                    this.label2.Text = "黑方";
                    ChessBack[boardX, boardY] = 2;
                }
                Chess.DrawChess(type,pictureBox1,g,e);

                if(IsFull())
                {
                    if(MessageBox.Show("游戏结束，平局")==DialogResult.OK)
                    {
                        Init();
                    }
                    return;
                }

                if(VerVic(boardX,boardY) || OblVic(boardX, boardY) || HorVic(boardX,boardY))
                {
                    string Vic;
                    if(type)
                    {
                        Vic = "黑";
                    }
                    else
                    {
                        Vic = "白";
                    }
                    if (MessageBox.Show(Vic+"方胜利！")==DialogResult.OK)
                    {
                        Init();
                    }
                    return;
                }

                type = !type;

            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            start = true;
            this.label1.Text = "游戏进行中";
            this.btnStart.Enabled = false;
            this.btnReset.Enabled = true;
            this.timer1.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("是否要重新开始？","提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                Init();
                times = 0;
                minute = 0;
                second = 0;
                timer1.Enabled = false;
                label3.Text = string.Format("{0:00}:{1:00}", minute, second);
            }

        }

        private int times = 0;
        long minute = 0;
        long second = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            times++;
            minute = times / 60;
            second = times - minute * 60;
            label3.Text = string.Format("{0:00}:{1:00}", minute, second);
        }

        private bool IsFull()
        {
            bool full = true;
            for(int i=0;i< MathSize.MaxNum; i++)
            {
                for(int j=0;j< MathSize.MaxNum; j++)
                {
                    if (ChessBack[i, j] == 0)
                        full = false;
                }
            }
            return full;
        }

        //竖
        private bool VerVic(int x,int y)
        {
            int var;
            if((y-4)>0)
            {
                var = y - 4; 
            }
            else
            {
                var = 0;
            }

            int cb = ChessBack[x, y];
            for(int i=var;i< MathSize.MaxNum-4; i++)
            {
                if (ChessBack[x, i] == cb && ChessBack[x, i + 1] == cb &&
                    ChessBack[x, i + 2] == cb && ChessBack[x, i + 2] == cb &&
                    ChessBack[x, i + 4] == cb)
                    return true;
            }
            return false;
        }

        //横
        private bool HorVic(int x,int y)
        {
            int var;
            if((x-4)>0)
            {
                var = x - 4;
            }
            else
            {
                var = 0;
            }

            int cb = ChessBack[x, y];
            for (int i = var; i < MathSize.MaxNum-4; i++)
            {
                if (ChessBack[i, y] == cb && ChessBack[i + 1, y] == cb &&
                ChessBack[i+2, y] == cb && ChessBack[i+3, y] == cb &&
                ChessBack[i+4, y] == cb)
                    return true;

            }
            return false;
        }

        //斜
        private bool OblVic(int x, int y)
        {
            //int Var1, Var2;
            //if ((x - 3) > 0)
            //{
            //    Var1 = x - 4;
            //}
            //else
            //{
            //    Var1 = 0;
            //}
            //if ((y - 3) > 0)
            //{
            //    Var2 = y - 4;
            //}
            //else
            //{
            //    Var2 = 0;
            //}
            //int cb = ChessBack[x, y];
            //for (int i = Var1, j = Var2; i < 17 && j < 17; i++, j++)
            //{
            //    if (ChessBack[i, j] == cb && ChessBack[i + 1, j + 1] == cb &&
            //        ChessBack[i + 2, j + 2] == cb && ChessBack[i + 3, j + 3] == cb &&
            //        ChessBack[i + 4, j + 4] == cb)
            //        return true;
            //}

            //for (int i = Var1, j = Var2; i < 17 && j < 17; i++, j++)
            //{
            //    if (ChessBack[i, j] == cb && ChessBack[i + 1, j - 1] == cb &&
            //        ChessBack[i + 2, j - 2] == cb && ChessBack[i + 3, j - 3] == cb &&
            //        ChessBack[i + 4, j - 4] == cb)
            //        return true;
            //}
            //return false;
            int cb = ChessBack[x, y];
            int sum1 = 1;
            int sum2 = 1;
            for (int i = x - 1, j = y - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (ChessBack[i, j] == cb)
                {
                    sum1++;
                }
                else
                {
                    break;
                }
            }
            for (int i = x + 1, j = y + 1; i < MathSize.MaxNum && j < MathSize.MaxNum; i++, j++)
            {
                if (ChessBack[i, j] == cb)
                {
                    sum1++;
                }
                else
                {
                    break;
                }
            }

            for (int i = x - 1, j = y + 1; i >= 0 && j < MathSize.MaxNum; i--, j++)
            {
                if (ChessBack[i, j] == cb)
                {
                    sum2++;
                }
                else
                {
                    break;
                }
            }
            for (int i = x + 1, j = y - 1; i < MathSize.MaxNum && j >= 0; i++, j--)
            {
                if (ChessBack[i, j] == cb)
                {
                    sum2++;
                }
                else
                {
                    break;
                }
            }

            if (sum1 > 4 || sum2 > 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    

    }

    
}
