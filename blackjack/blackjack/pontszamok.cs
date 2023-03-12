using System;
using System.Collections.Generic;
using System.Text;

namespace blackjack
{
    class pontszamok
    {

        //besokkolt-e a játékos
        public bool ellenor(int jatekospont)
        {
            bool tovabbMehet= true;

            if (jatekospont>21)
            {
                tovabbMehet = false;
            }
            return (tovabbMehet);
        }
    }
}
