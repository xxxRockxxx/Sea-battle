using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_battle
{
    class Input_Info
    {
        public string InputConosle()
        {
            string choose=Console.ReadLine();
            string Choose = choose.ToUpper();
            return Choose;
        }

        public string InputCoordinates()
        {
            string Cooordinate = Console.ReadLine().ToUpper();
            return Cooordinate;
        }
    }
}
