using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Loads
{
    /// <summary>
    /// Loadcase class 
    /// </summary>
    public class Loadcase
    {
        /// <summary>Loadcase name</summary>
        public string Name { get; private set; }

        /// <summary>Loadcase number</summary>
        public int Number { get; private set; }

        public Loadcase()
        {
        }

        public Loadcase(string name)
        {
            this.Name = name;
        }

        public Loadcase(int number)
        {
            this.Number = number;
        }

        public Loadcase(int number, string name)
        {
            this.Number = number;
            this.Name = name;
        }

        public void SetName(string name)
        {
            this.Name = name;
        }

        public void SetNumber(int number)
        {
            this.Number = number;
        }
    }
}
