using BHoM.Global;
using System.Collections.Generic;
using BHoM.Structural.Loads;

namespace BHoM.Structural
{
    /// <summary>
    /// 
    /// </summary>
    public class LoadcaseFactory : ObjectFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        public LoadcaseFactory(Project p) : base(p) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="loadcases"></param>
        public LoadcaseFactory(Project p, List<BHoM.Global.BHoMObject> loadcases) : base(p, loadcases) { }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Loadcase Create(int number, string name)
        {
            if (this.ContainsNumber(number))
            {
                return this[number] as Loadcase;
            }
            else
            {
                Loadcase loadcase = new Loadcase(number, name);
                this.Add(loadcase);
                return loadcase;
            }
        }
    }
}