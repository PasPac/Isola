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
    public partial class Form1 : Form
    {
        int input;
        Player player1;
        Player player2;
        Random rng;
        List<Button> _buttonList;
        List<Button> frozenCells;
        int turnCount;
        bool IsFirstMove;
        bool IsPlayer1;

        public Form1()
        {
            InitializeComponent();
            rng = new Random();
            _buttonList = new List<Button> { };
            frozenCells = new List<Button> { };
            IsFirstMove = true;
            IsPlayer1 = true;
        }

        private void Genbutton_Click(object sender, EventArgs e)
        {
           
            input = int.Parse(textBox1.Text);

            

            if (input % 2 != 0 && input < 20)
            {
                for (int i = 1; i <= input; i++)
                {
                    for (int j = 1; j <= input; j++)
                    {
                        Button b = new Button();
                        b.Name = input.ToString() + "_cell";
                        b.Size = new Size(60, 60);
                        b.Location = new Point(60 * j, 60 * (i + 1));
                        Controls.Add(b);
                        b.Click += new EventHandler(Button_Click);
                        b.Tag = $"{j},{i}";
                        
                        _buttonList.Add(b);                     
                    }
                }               
                Genbutton.Visible = false;
                textBox1.Visible = false;

                player1 = new Player(RandomPosGen.PosGenerate(rng, input), RandomPosGen.PosGenerate(rng, input), Color.DarkBlue,textBox3.Text.ToString());
                player2 = new Player(RandomPosGen.PosGenerate(rng, input, player1.X), RandomPosGen.PosGenerate(rng, input, player1.Y), Color.Red, textBox4.Text.ToString());

              



                foreach (var button in _buttonList)
                {
                    if (button.Tag.ToString() == player1.startPos)
                    {
                        button.BackColor = Color.DarkBlue;
                    }                  
                }

                foreach (var button in _buttonList)
                {
                    if (button.Tag.ToString() == player2.startPos)
                    {
                        button.BackColor = Color.Red;
                    }
                }

                Calculate.DisableAll(_buttonList);
                Calculate.CalculateVM(player1, _buttonList,player2,frozenCells);

            }
            else
            {
                MessageBox.Show("Number must be odd and less than 20");
            }

        }


        private void Button_Click(object sender, EventArgs e)
        {
            Button cell = (Button)sender;

           


            if (IsPlayer1)
            {
                if (IsFirstMove == true)
                {
                    Calculate.Move(player1, cell, _buttonList, player2, frozenCells);
                    IsFirstMove = false;
                }
                else
                {
                    Calculate.FreezeCell(cell, frozenCells);
                    IsFirstMove = true;
                    IsPlayer1 = false;
                    Calculate.DisableAll(_buttonList);
                    Calculate.CalculateVM(player2, _buttonList, player1, frozenCells);
                }
            }
            else
            {
                if (IsFirstMove == true)
                {
                    Calculate.Move(player2, cell, _buttonList, player1, frozenCells);
                    IsFirstMove = false;
                }
                else
                {
                    Calculate.FreezeCell(cell, frozenCells);
                    IsFirstMove = true;
                    IsPlayer1 = true;
                    Calculate.DisableAll(_buttonList);
                    Calculate.CalculateVM(player1, _buttonList, player2, frozenCells);
                }
            }



           
           // Calculate.Move(player1, cell, _buttonList, player2, frozenCells, IsFirstMove);
           
            
            // Calculate.FreezeCell(cell, frozenCells);

            //END Calculate.CalculateVM(player2, _buttonList,player1);
           

        }


        


    }

}
