using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationWars.Components
{
    public class Government
    {
        public int MyProperty { get; set; }
        public int MyProperty2 { get; set; }
        public int MyProperty3 { get; set; }
        // .
        // .
        // .

        public Government()
        {

        }

        public void Train()
        {
            // TODO: implement
        }

        public Desicion MakeDesicion(Situation situation)
        {
            // TODO: implement

            Random random = new Random(DateTime.Now.Millisecond);
            return new Desicion(random.NextDouble() > 0.5 ? true : false,
                (Direction)((((int)(random.NextDouble() * 100) % 9)) + 1), random.NextDouble());
        }
    }
}