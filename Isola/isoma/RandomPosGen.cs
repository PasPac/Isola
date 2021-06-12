using System;
using System.Collections.Generic;
using System.Text;

namespace isoma
{
    public static class RandomPosGen
    {
        public static int PosGenerate(Random rng, int max, int occupied = 0)
        {
            
          while (true)
          { 
            int n = rng.Next(1, max);
            
            if (n != occupied)
            {
                    return n;
            }
          }
        }

    }
}
