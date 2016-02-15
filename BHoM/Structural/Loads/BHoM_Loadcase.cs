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

        /// <summary>
        /// Constructs an empty loadcase
        /// </summary>
        public Loadcase()
        {
        }

        /// <summary>
        /// Constructs a loadcase by name
        /// </summary>
        /// <param name="name"></param>
        public Loadcase(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Constructs a loadcase by number
        /// </summary>
        /// <param name="number"></param>
        public Loadcase(int number)
        {
            this.Number = number;
        }

        /// <summary>
        /// Constructrs a loadcase by name and number
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        public Loadcase(int number, string name)
        {
            this.Number = number;
            this.Name = name;
        }

        /// <summary>
        /// Set the loadcase name
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Set the loadcase number
        /// </summary>
        /// <param name="number"></param>
        public void SetNumber(int number)
        {
            this.Number = number;
        }
    }
}
