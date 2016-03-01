using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural
{
    /// <summary>
    /// Storey class to store information about building storeys for post processing of results
    /// </summary>
    public class Storey : IStructuralObject
    {
        /////////////////
        ////Properties///
        /////////////////
        
        /// <summary>Storey number</summary>
        public int Number { get; private set; }

        /// <summary>Storey level (in metres)</summary>
        public double Level { get; private set; }

        /// <summary>Storey name</summary>
        public string Name { get; private set; }

        /// <summary>Storey height</summary>
        public double Height { get; private set; }

        ///////////////////
        ////Constructors///
        ///////////////////

        /// <summary>
        /// Constructs and empty storey object
        /// </summary>
        public Storey()
        {
        }
       
        /// <summary>
        /// Constructs a storey object using number and name. If number and/or name are not known, use 0 and "" respectively.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        public Storey(int number, string name)
            :this()
        {
            this.Number = number;
            this.Name = name;
        }

        //////////////
        ////Methods///
        //////////////

        /// <summary>
        /// Sets the storey number
        /// </summary>
        /// <param name="number"></param>
        public void SetNumber(int number)
        {
            this.Number = number;
        }

        /// <summary>
        /// Sets the storey name
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Sets the storey level
        /// </summary>
        /// <param name="level"></param>
        public void SetLevel(double level)
        {
            this.Level = level;
        }

        /// <summary>
        /// Sets the storey height
        /// </summary>
        /// <param name="height"></param>
        public void SetHeight(double height)
        {
            this.Height = height;
        }
         }
}
