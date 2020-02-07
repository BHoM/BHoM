using BH.oM.Base;
using BH.oM.Data.Library;
using System;
using System.Collections.Generic;

namespace BH.oM.Data.Library
{
    public class DataPoint : BHoMObject, IComparable<DataPoint>
    {
        /***************************************************/
        /**** Properties                                ****/
        /**************************************************/
        public Source SourceInformation { get; set; }
        public System.DateTime TimeOfCreation { get; set; }
        public object Value { get; set; }

        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/
        public int CompareTo(DataPoint other)
        {
            if (other == null) return 1;
            string otherstring = other.Value.ToString();
            string thisstring = this.Value.ToString();
            if (other.Value.GetType() == typeof(double) && this.Value.GetType() == typeof(double))
            {
                double otherdouble = 0;
                double thisdouble = 0;
                if(double.TryParse(otherstring,out otherdouble)&& double.TryParse(thisstring, out thisdouble))
                {
                    return thisdouble.CompareTo(otherdouble);
                }
            }
            else if (other.Value.GetType() == typeof(int) && this.Value.GetType() == typeof(int))
            {
                int otherint = 0;
                int thisint = 0;
                if (int.TryParse(otherstring, out otherint) && int.TryParse(thisstring, out thisint))
                {
                    return thisint.CompareTo(otherint);
                }
            }
            else if(other.Value.GetType() == typeof(string) && this.Value.GetType() == typeof(string))
            {
                return thisstring.CompareTo(otherstring);
            }
            throw new ArgumentException("DataPoint value is not a comparable");
        }

    }
}
