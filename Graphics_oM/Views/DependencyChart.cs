using BH.oM.Base;
using BH.oM.Graphics.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics.Views
{
    [Description("Scale for mapping from a discrete domain and range.")]
    public class DependencyChart : BHoMObject, IView
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/
        public virtual Boxes Boxes { get; set; } = null;

        public virtual Links Links { get; set; } = null;

        public virtual ViewConfig ViewConfig { get; set; } = new ViewConfig();

        /***************************************************/
    }
}
