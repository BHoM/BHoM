using BH.oM.Base;
using BH.oM.Graphics.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics.Views
{
    public class DependencyChart : BHoMObject, IView
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public virtual Boxes Boxes { get; set; } = null;

        public virtual Links Links { get; set; } = null;

        public virtual ViewConfig ViewConfig { get; set; } = new ViewConfig();

        public virtual Title Title { get; set; } = new Title();

        /***************************************************/
    }
}
