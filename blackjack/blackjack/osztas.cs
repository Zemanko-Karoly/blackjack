using System;
using System.Collections.Generic;
using System.Text;



namespace blackjack
{
    class osztas
    {
        //2D array a lapoknak
        int[,] mentettkartya = new int[104, 2];

        //kezdo kartyak sorsolasa (jatekos)
        public int[] elsolapok(int[,] osztottkartyak)
        {
            Random rnd = new Random();
            int elsolap, masodiklap, sorsoltlap;
            int[] vissza = new int[8];
            do
            {
                sorsoltlap = rnd.Next(0, 104);
                elsolap = osztottkartyak[sorsoltlap, 0];
            } while (osztottkartyak[sorsoltlap,1]==1);
            osztottkartyak[sorsoltlap, 1] = 1;

            vissza[0] = elsolap;
            if (sorsoltlap > 51)
            {
                sorsoltlap = sorsoltlap - 52;
            }
            vissza[1] = sorsoltlap;


            do
            {
                sorsoltlap = rnd.Next(0, 104);
                masodiklap = osztottkartyak[sorsoltlap, 0];
            } while (osztottkartyak[sorsoltlap, 1] == 1);
            osztottkartyak[sorsoltlap, 1] = 1;


            vissza[2] = masodiklap;
            if (sorsoltlap > 51)
            {
                sorsoltlap = sorsoltlap - 52;
            }
            vissza[3] = sorsoltlap;

            int[] visszaoszto = osztoelsolapok(osztottkartyak);
            vissza[4] = visszaoszto[0];
            vissza[5] = visszaoszto[1];
            vissza[6] = visszaoszto[2];
            vissza[7] = visszaoszto[3];

            return (vissza);
        }

        //kezdo kartyak sorsolasa (oszto)
        public int[] osztoelsolapok(int[,]osztottkartyak)
        {
            int[] visszaoszto = new int[4];
            Random rnd = new Random();
            int elsolap, masodiklap, sorsoltlap;

            do
            {
                sorsoltlap = rnd.Next(0, 104);
                elsolap = osztottkartyak[sorsoltlap, 0];
            } while (osztottkartyak[sorsoltlap, 1] == 1);
            osztottkartyak[sorsoltlap, 1] = 1;

            visszaoszto[0] = elsolap;
            if (sorsoltlap > 51)
            {
                sorsoltlap = sorsoltlap - 52;
            }
            visszaoszto[1] = sorsoltlap;


            do
            {
                sorsoltlap = rnd.Next(0, 104);
                masodiklap = osztottkartyak[sorsoltlap, 0];
            } while (osztottkartyak[sorsoltlap, 1] == 1);
            osztottkartyak[sorsoltlap, 1] = 1;


            visszaoszto[2] = masodiklap;
            if (sorsoltlap > 51)
            {
                sorsoltlap = sorsoltlap - 52;
            }
            visszaoszto[3] = sorsoltlap;

            mentettkartya = osztottkartyak;
            return (visszaoszto);
        }


        //uj lap kerese
        public int[] lapkeres()
        {
            int elsolap, masodiklap, sorsoltlap;
            Random rnd = new Random();
            int[] pluszlap = new int[2];
            do
            {
                sorsoltlap = rnd.Next(0, 104);
                masodiklap = mentettkartya[sorsoltlap, 0];
            } while (mentettkartya[sorsoltlap, 1] == 1);
            mentettkartya[sorsoltlap, 1] = 1;

            if (sorsoltlap > 51)
            {
                sorsoltlap = sorsoltlap - 52;
            }
            pluszlap[0] = masodiklap;
            pluszlap[1] = sorsoltlap;

            return (pluszlap);
        } 

    }
}
