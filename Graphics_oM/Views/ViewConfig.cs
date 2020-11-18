using BH.oM.Base;
using BH.oM.Graphics.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics.Views
{
    public class ViewConfig : BHoMObject, IView
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual double Width { get; set; } = 800;

        public virtual double Height { get; set; } = 600;

        public virtual Padding Padding { get; set; } = new Padding();

        /***************************************************/
    }
}
