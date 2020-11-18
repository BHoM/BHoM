using BH.oM.Base;
using BH.oM.Graphics.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics.Layouts
{
    public class MultiColumnsLayout : BHoMObject, IView
    {
        public virtual List<IView> Children { get; set; } = new List<IView>();

        public virtual int NbColumns { get; set; } = 2;
    }
}
