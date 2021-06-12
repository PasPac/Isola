using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace isoma
{
    public class Calculate
    {
        static int counter;
        static List<Button> VMlist;

        public static void CalculateVM(Player player, List<Button> buttonList, Player oppPlayer, List<Button> frozenCells)
        {
            
            VMlist = new List<Button> { };
            counter = 0;
            
            foreach (var cell in buttonList)
            {
                if (cell.Tag.ToString() == $"{player.X - 1},{player.Y + 1}")
                {
                    VMlist.Add(cell);
                    if (frozenCells.Contains(cell) == false && oppPlayer.currPos != cell.Tag.ToString())
                    {
                        counter++;
                    }
                }
                if (cell.Tag.ToString() == $"{player.X},{player.Y + 1}") 
                {
                    VMlist.Add(cell);
                    if (frozenCells.Contains(cell) == false && oppPlayer.currPos != cell.Tag.ToString())
                    {
                        counter++;
                    }
                }
                if (cell.Tag.ToString() == $"{player.X + 1},{player.Y + 1}")
                {
                    VMlist.Add(cell);
                    if (frozenCells.Contains(cell) == false && oppPlayer.currPos != cell.Tag.ToString())
                    {
                        counter++;
                    }
                }
                if (cell.Tag.ToString() == $"{player.X - 1},{player.Y}")
                {
                    VMlist.Add(cell);
                    if (frozenCells.Contains(cell) == false && oppPlayer.currPos != cell.Tag.ToString())
                    {
                        counter++;
                    }
                }
                if (cell.Tag.ToString() == $"{player.X + 1},{player.Y}")
                {
                    VMlist.Add(cell);
                    if (frozenCells.Contains(cell) == false && oppPlayer.currPos != cell.Tag.ToString())
                    {
                        counter++;
                    }
                }
                if (cell.Tag.ToString() == $"{player.X - 1},{player.Y - 1}")
                {
                    VMlist.Add(cell);
                    if (frozenCells.Contains(cell) == false && oppPlayer.currPos != cell.Tag.ToString())
                    {
                        counter++;
                    }
                }
                if (cell.Tag.ToString() == $"{player.X},{player.Y - 1}")
                {
                    VMlist.Add(cell);
                    if (frozenCells.Contains(cell) == false && oppPlayer.currPos != cell.Tag.ToString())
                    {
                        counter++;
                    }
                }
                if (cell.Tag.ToString() == $"{player.X + 1},{player.Y - 1}" )
                {
                    VMlist.Add(cell);
                    if (frozenCells.Contains(cell) == false && oppPlayer.currPos != cell.Tag.ToString())
                    {
                        counter++;
                    }
                }
            }
            if (counter == 0)
            {
                Win(player);
            }


            foreach (var c in VMlist)
            {

                if (c.Tag.ToString() != oppPlayer.currPos)
                {
                    if (frozenCells.Contains(c) == false)
                    {
                        c.Enabled = true;
                    }
                }
            }
        }

        public static void FreezeCell(Button cell, List<Button> frozenCells)
        {

            frozenCells.Add(cell);
            cell.Enabled = false;
            cell.BackColor = Color.Black;



        }

        public static void Move(Player player, Button cell, List<Button> buttonList, Player oppPlayer, List<Button> frozenCells)
        {

            foreach (var celll in buttonList)
            {
                if (celll.Tag.ToString() == $"{player.X},{player.Y}")
                {
                    celll.Enabled = true;
                    celll.UseVisualStyleBackColor = true;
                    celll.BackColor = default(Color);
                }
            }

            cell.BackColor = player.C;
            cell.Enabled = false;
            string[] coord = cell.Tag.ToString().Split(',');
            player.X = int.Parse(coord[0]);
            player.Y = int.Parse(coord[1]);
            player.currPos = $"{coord[0]},{coord[1]}";


            foreach (var b in buttonList)
            {
                if (b.Tag.ToString() != player.currPos && b.Tag.ToString() != oppPlayer.currPos && frozenCells.Contains(b) == false)
                {
                    b.Enabled = true;
                }
            }


        }

        public static void DisableAll()
        {
            foreach (var b in Form1.buttonList)
            {
                b.Enabled = false;
            }
        }

        public static void Win(Player player)
        {
            DialogResult res = MessageBox.Show($"{player.Name} wins! Would you like to play again?", "WINNER!", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                DisableAll();
                Form1.Reset(true);
            }
            else
            {
                Application.Exit();
            }


        }
    }
}
