using BH.oM.Base;
using BH.oM.Graphics.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Graphics.Layouts
{
    public class GridItem : BHoMObject, IView
    {
        public virtual IView InnerView { get; set; } = null;

        public virtual int StartColumn { get; set; } = 0;

        public virtual int StartRow { get; set; } = 0;

        public virtual int ColumnSpan { get; set; } = 0;

        public virtual int RowSpan { get; set; } = 0;
    }
}
