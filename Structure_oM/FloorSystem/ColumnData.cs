using BH.oM.Base;
using BH.oM.Structure.SectionProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Structure.FloorSystem
{
    public class ColumnData : BHoMObject
    {
        /***************************************************/
        /****            Public Properties              ****/
        /***************************************************/

        public virtual List<IColumnConfiguration<IGeometricalSection>> ColumnConfiguration { get; set; }

        /***************************************************/
    }
}
