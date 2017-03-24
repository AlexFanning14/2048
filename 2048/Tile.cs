using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public enum TileNumbers
    {
        empty = 0, //Moscasin
        n2 = 2, //Khaki
        n4 = 4, // Beige
        n8 = 8, // Wheat
        n16 = 16, // Tan
        n32 = 32, // PeachPuff
        n64 = 64, // Linen
        n128 = 128, // Cornsilk
        n256 = 256, // Lightyellow
        n512 = 512, //PaleGoldenrod
        n1024 = 1024, //Salmon
        n2048 = 2048 // Coral
    }

    public class Tile : Panel
    {
        public TileNumbers num;
        public Label lbl;

        public Tile()
        {
            num = TileNumbers.empty;
            lbl = new Label();
            if (num != TileNumbers.empty)
                lbl.Text = ((int)num).ToString();
            int posx = Location.X + 35;
            int posy = Location.Y + 35;
            lbl.Location = new System.Drawing.Point(posx, posy);
            lbl.Font = new System.Drawing.Font("Stencil", 16);

            Controls.Add(lbl);
        }

        public void SetLblNum(TileNumbers num)
        {
            if (num == TileNumbers.empty)
                lbl.Text = "";
            else
                lbl.Text = ((int)num).ToString();
            
            this.num = num;
            ChangeColor(num);
        }

        private void ChangeColor(TileNumbers num)
        {
            switch (num)
            {
                case TileNumbers.empty:
                        BackColor = Color.Moccasin;
                        break;
                case TileNumbers.n2:
                    BackColor = Color.Khaki;
                    break;
                case TileNumbers.n4:
                    BackColor = Color.Beige;
                    break;
                case TileNumbers.n8:
                    BackColor = Color.Wheat;
                    break;
                case TileNumbers.n16:
                    BackColor = Color.Tan;
                    break;
                case TileNumbers.n32:
                    BackColor = Color.PeachPuff;
                    break;
                case TileNumbers.n64:
                    BackColor = Color.Linen;
                    break;
                case TileNumbers.n128:
                    BackColor = Color.Cornsilk;
                    break;
                case TileNumbers.n256:
                    BackColor = Color.LightYellow;
                    break;
                case TileNumbers.n512:
                    BackColor = Color.PaleGoldenrod;
                    break;
                case TileNumbers.n1024:
                    BackColor = Color.Salmon;
                    break;
                case TileNumbers.n2048:
                    BackColor = Color.Coral;
                    break;
                default:
                    BackColor = Color.Moccasin;
                    break;

            }
        }







    }


}
