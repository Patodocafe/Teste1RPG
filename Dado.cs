using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1_Rpg
{
    public class Dado
    {
        private static Random random = new Random();

        public static int RoollD20()
        {
            return random.Next(1, 21);
        }


        public static int RoollD6()
        {
            return random.Next(1, 7);
        }

        public static int RoollD12()
        {
            return random.Next(1, 13);
        }

        public static int RoollD8()
        {
            return random.Next(1, 9);
        }
    }
}