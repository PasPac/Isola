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
        static bool HasMoves = false;
        static List<Button> VMlist;

        public static void CalculateVM(Player player, List<Button> buttonList, Player oppPlayer, List<Button> frozenCells)
        {
            HasMoves = false;
            VMlist = new List<Button> { };
            counter = 0;
            foreach (var button in buttonList)
            {
                if (button.Tag.ToString() == $"{player.X -1},{player.Y + 1}")
                {
                    VMlist.Add(button);
                    if (frozenCells.Contains(button) == false)
                    {
                    counter++;
                    }
                }
                if (button.Tag.ToString() == $"{player.X},{player.Y + 1}")
                {
                    VMlist.Add(button);
                    if (frozenCells.Contains(button) == false)
                    {
                        counter++;
                    }
                }
                if (button.Tag.ToString() == $"{player.X+1},{player.Y + 1}")
                {
                    VMlist.Add(button);
                    if (frozenCells.Contains(button) == false)
                    {
                        counter++;
                    }
                }
                if (button.Tag.ToString() == $"{player.X-1},{player.Y}")
                {
                    VMlist.Add(button);
                    if (frozenCells.Contains(button) == false)
                    {
                        counter++;
                    }
                }
                if (button.Tag.ToString() == $"{player.X+1},{player.Y}")
                {
                    VMlist.Add(button);
                    if (frozenCells.Contains(button) == false)
                    {
                        counter++;
                    }
                }
                if (button.Tag.ToString() == $"{player.X+1},{player.Y}")
                {
                    VMlist.Add(button);
                    HasMoves = true;
                    if (frozenCells.Contains(button) == false)
                    {
                        counter++;
                    }
                }
                if (button.Tag.ToString() == $"{player.X-1},{player.Y -1}")
                {
                    VMlist.Add(button);
                    HasMoves = true;
                    if (frozenCells.Contains(button) == false)
                    {
                        counter++;
                    }
                }
                if (button.Tag.ToString() == $"{player.X},{player.Y - 1}")
                {
                    VMlist.Add(button);
                    HasMoves = true;
                    if (frozenCells.Contains(button) == false)
                    {
                        counter++;
                    }
                }
                if (button.Tag.ToString() == $"{player.X+1},{player.Y - 1}")
                {
                    VMlist.Add(button);
                    HasMoves = true;
                    if (frozenCells.Contains(button) == false)
                    {
                        counter++;
                    }
                }                              
            }
            if(counter == 0)
            {                
                 Win(player);
            }
            

            foreach (var c in VMlist)
            {
                //TODO Freeze check * 

                if (c.Tag.ToString() != $"{oppPlayer.X},{oppPlayer.Y}")
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


            foreach (var b in buttonList)
            {
                if (b.Tag.ToString() != $"{player.X},{player.Y}" && b.Tag.ToString() != $"{oppPlayer.X},{oppPlayer.Y}" && frozenCells.Contains(b) == false)
                {
                    b.Enabled = true;
                }
            }
            

        }

        public static void DisableAll(List<Button> buttonList)
        {
            foreach(var b in buttonList)
            {
                b.Enabled = false;
            }
        }

        public static void Win(Player player)
        {
            MessageBox.Show($"{player.Name} wins!");

        }


    }
}
