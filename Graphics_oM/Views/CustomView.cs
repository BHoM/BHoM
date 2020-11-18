using BH.oM.Base;
using BH.oM.Graphics.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics.Views
{
    public class CustomView : BHoMObject, IView
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual ViewConfig ViewConfig { get; set; }  = new ViewConfig();

        public virtual List<IComponent> Children { get; set; } = new List<IComponent>();

        /***************************************************/
    }
}
