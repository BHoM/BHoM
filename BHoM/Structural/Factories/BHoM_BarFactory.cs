using BHoM.Global;
using System.Collections.Generic;

namespace BHoM.Structural
{
    /// <summary>
    /// 
    /// </summary>
    public class BarFactory : ObjectCollection
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        public BarFactory(Project p) : base(p) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="bars"></param>
        public BarFactory(Project p, List<BHoM.Global.BHoMObject> bars) : base(p, bars) { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Bar Create()
        {
            return new Bar();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public Bar Create(int number, Node n1, Node n2)
        {
            if (this.Contains(number.ToString()))
            {
                return this[number] as Bar;
            }
            else
            {
                Bar bar = new Bar(n1, n2, number);
                this.Add(bar);
                return bar;
            }
        }
    }
}