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
    public class Player
    {

        string _startPos;

        public Player(int x, int y, Color c, string name)
        {
            X = x;
            Y = y;
            _startPos = $"{x},{y}";
            startPos = _startPos;
            currPos = _startPos;
            C = c;
            Name = name;
            Wins = 0;
        }

        public string currPos { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string startPos { get; set; }
        public Color C { get; set; }
        public string Name { get; set; }

        public int Wins {get; set;}
        
    }
}
