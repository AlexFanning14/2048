using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Board
    {
        const int totalPans = 16;
        public Point[,] ps = new Point[4, 4];
        public Tile[,] ts = new Tile[4, 4];
        public Board()
        {
            AssignLocations();

        }

        

        private void AssignLocations()
        {
            ps[0, 0] = new Point(3, 291);
            ps[1, 0] = new Point(99, 291);
            ps[2, 0] = new Point(195, 291);
            ps[3, 0] = new Point(291, 291);

            ps[0, 1] = new Point(3, 195);
            ps[1, 1] = new Point(99, 195);
            ps[2, 1] = new Point(195, 195);
            ps[3, 1] = new Point(291, 195);

            ps[0, 2] = new Point(3, 99);
            ps[1, 2] = new Point(99, 99);
            ps[2, 2] = new Point(195, 99);
            ps[3, 2] = new Point(291, 99);

            ps[0, 0] = new Point(3, 3);
            ps[1, 0] = new Point(99, 3);
            ps[2, 0] = new Point(195, 3);
            ps[3, 0] = new Point(291, 3);
        }

        public Tile[,] MoveLeft(Tile[,] tsNew)
        {
            for (int k = 0; k < 4; k++)
            {
                for (int i = 3; i > 0; i--)
                {
                    Tile left = ts[i - 1, k];
                    Tile right = ts[i, k];
                    if ((left.num == TileNumbers.empty) && (right.num != TileNumbers.empty))
                    {
                        left.SetLblNum(right.num);
                    }
                }
            }
            return tsNew;
            
            
        }



    }
}
