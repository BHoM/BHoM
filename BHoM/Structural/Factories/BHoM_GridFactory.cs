using BHoM.Global;
using System.Collections.Generic;

namespace BHoM.Structural
{
    /// <summary>
    /// 
    /// </summary>
    public class GridFactory : ObjectFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        public GridFactory(Project p) : base(p) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="Grids"></param>
        public GridFactory(Project p, List<BHoM.Global.BHoMObject> Grids) : base(p, Grids) { }  

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public Grid Create(Geometry.ILine curve, string name = "")
        {
            Grid Grid = new Grid(curve, name);
            this.Add(Grid);
            return Grid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public Grid Create(string json = "")
        {
            Grid Grid = new Grid(json);
            this.Add(Grid);
            return Grid;
        }
    }
}