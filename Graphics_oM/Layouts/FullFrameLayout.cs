using BH.oM.Base;
using BH.oM.Graphics.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics.Layouts
{
    public class FullFrameLayout : BHoMObject, IView
    {
        public virtual IView InnerView { get; set; } = null;

        public virtual int Margin { get; set; } = 0;

        public virtual bool WidthOnly { get; set; } = false;
    }
}
