using System;
using System.Collections.Generic;
using System.Text;

namespace blackjack
{
    class feltoltes
    {
        public int[,] lapok()
        {
            int kartyaertek;
            int[,] osztottkartyak = new int[104, 2];

            for (int i = 0; i < 104; i++)
            {
                for (int j = 2; j < 15; j++)
                {
                    if (j >= 10)
                    {
                        kartyaertek = 10;
                    }
                    else
                    {
                        kartyaertek = j;
                    }
                    if (j == 14)
                    {
                        kartyaertek = 11;
                    }
                    osztottkartyak[i,0] = kartyaertek;
                    if (i < 104)
                    {
                        i++;

                    }
                }
                i--;

            }
            return (osztottkartyak);
        }
    }
}
