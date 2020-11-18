using BH.oM.Base;
using BH.oM.Graphics.Enums;
using BH.oM.Graphics.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics.Views
{
    public class TextView: BHoMObject, IView
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual string Content { get; set; } = "";

        public virtual double Width { get; set; } = 1.0;

        public virtual double FontSize { get; set; } = 0;

        public virtual TextAnchor TextAlign { get; set; } = TextAnchor.start;

        public virtual Padding Padding { get; set; } = new Padding { Top = 5, Bottom = 5, Left = 5, Right = 5 };

        /***************************************************/
    }
}
