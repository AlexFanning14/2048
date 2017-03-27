using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {
        static Board board = new Board();
        static Random r = new Random();
        public Form1()
        {
            InitializeComponent();
            PopulateTiles();
            PopulateRandomNumsStart();

        }

        private void PopulateRandomNumsStart()
        {
            
            int x = r.Next(3);
            int y = r.Next(3);

            board.ts[x, y].SetLblNum(TileNumbers.n2);
            board.ts[x, y].SetCoOr(x, y);


            int x1 = r.Next(3);
            int y1 = r.Next(3);

            if (x1 != x || y1 != y)
            {
                board.ts[x1, y1].SetLblNum(TileNumbers.n2);
                board.ts[x1, y1].SetCoOr(x1, y1);
            }
                
        }

        private void PopulateTiles()
        {
            board.ts[0, 0] = p00;
            board.ts[0, 1] = p01;
            board.ts[0, 2] = p02;
            board.ts[0, 3] = p03;
            board.ts[1, 0] = p10;
            board.ts[1, 1] = p11;
            board.ts[1, 2] = p12;
            board.ts[1, 3] = p13;
            board.ts[2, 0] = p20;
            board.ts[2, 1] = p21;
            board.ts[2, 2] = p22;
            board.ts[2, 3] = p23;
            board.ts[3, 0] = p30;
            board.ts[3, 1] = p31;
            board.ts[3, 2] = p32;
            board.ts[3, 3] = p33;


        }



        private void MoveIt(object sender, KeyEventArgs e)
        {
            Task.Factory.StartNew(() =>
           {
               MoveTile(e);
           });
            

        }

        private void MoveTile(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                MoveLeft();
            }
            else if (e.KeyCode == Keys.Right)
            {
                MoveRight();
            }
            else if (e.KeyCode == Keys.Up)
            {
                MoveUp();
            }
            else if (e.KeyCode == Keys.Down)
            {
                MoveDown();
            }

            AddNewTile();
        }


        private void AddNewTile()
        {
            Thread.Sleep(1);
            int x = r.Next(3);
            int y = r.Next(3);



            if(board.ts[x,y].num == TileNumbers.empty)
            {
                int z = r.Next(2);
                if(z == 0)
                {
                    board.ts[x, y].SetLblNum(TileNumbers.n4);
                    board.ts[x, y].SetCoOr(x,y);
                }
                else
                {
                    board.ts[x, y].SetLblNum(TileNumbers.n2);
                    board.ts[x, y].SetCoOr(x, y);
                }
                    
            }
            else
            {
                AddNewTile();
            }
            
            
        }

        public void MoveLeft()
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 3; x > 0; x--)
                {
                    Tile left = board.ts[x - 1, y];
                    Tile right = board.ts[x, y];
                    if ((left.num == TileNumbers.empty) && (right.num != TileNumbers.empty))
                    {
                        
                        left.SetLblNum(right.num);
                        left.SetCoOr(x - 1, y);
                        right.SetLblNum(TileNumbers.empty);
                        MoveLeft();
                    }
                    else if((left.num != TileNumbers.empty) && left.num == right.num)
                    {
                        int numToSet = ((int)left.num) * 2;
                        left.SetLblNum((TileNumbers)numToSet);
                        right.SetLblNum(TileNumbers.empty);
                        MoveLeft();
                    }
                }
            }
        }
        public void MoveRight()
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Tile right = board.ts[x + 1, y];
                    Tile left  = board.ts[x, y];
                    if ((right.num == TileNumbers.empty) && (left.num != TileNumbers.empty))
                    {
                        right.SetLblNum(left.num);
                        left.SetLblNum(TileNumbers.empty);
                        MoveRight();
                    }
                    else if ((right.num != TileNumbers.empty) && right.num == left.num)
                    {
                        int numToSet = ((int)right.num) * 2;
                        right.SetLblNum((TileNumbers)numToSet);
                        left.SetLblNum(TileNumbers.empty);
                        MoveRight();
                    }
                }
            }
        }

        public void MoveUp()
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Tile top = board.ts[x, y + 1];
                    Tile bottom = board.ts[x, y];
                    if ((top.num == TileNumbers.empty) && (bottom.num != TileNumbers.empty))
                    {
                        top.SetLblNum(bottom.num);
                        bottom.SetLblNum(TileNumbers.empty);
                        MoveUp();
                    }
                    else if ((top.num != TileNumbers.empty) && top.num == bottom.num)
                    {
                        int numToSet = ((int)top.num) * 2;
                        top.SetLblNum((TileNumbers)numToSet);
                        bottom.SetLblNum(TileNumbers.empty);
                        MoveUp();
                    }
                }
            }
        }

        public void MoveDown()
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 3; y > 0; y--)
                {
                    Tile bottom = board.ts[x, y - 1];
                    Tile top = board.ts[x, y];
                    if ((bottom.num == TileNumbers.empty) && (top.num != TileNumbers.empty))
                    {
                        bottom.SetLblNum(top.num);
                        top.SetLblNum(TileNumbers.empty);
                        MoveDown();
                    }
                    else if ((bottom.num != TileNumbers.empty) && top.num == bottom.num)
                    {
                        int numToSet = ((int)bottom.num) * 2;
                        bottom.SetLblNum((TileNumbers)numToSet);
                        top.SetLblNum(TileNumbers.empty);
                        MoveDown();
                    }
                }
            }
        }

        

    }



}
