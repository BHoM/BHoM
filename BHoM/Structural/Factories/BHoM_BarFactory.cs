using BHoM.Global;
using System.Collections.Generic;

namespace BHoM.Structural
{
    /// <summary>
    /// 
    /// </summary>
    public class BarFactory : ObjectFactory
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
            Bar bar = new Bar(this.FreeNumber());
            this.Add(bar);
            return new Bar();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public Bar Create(int number)
        {
            if (this.ContainsNumber(number))
            {
                return this[number] as Bar;
            }
            else
            {
                Bar bar = new Bar(number);
                this.Add(bar);
                return bar;
            }
        }
    }
}