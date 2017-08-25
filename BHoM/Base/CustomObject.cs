using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BH.oM.Base
{
    public class CustomObject : BHoMObject
    {
        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public CustomObject() { }

        /***************************************************/

        public CustomObject(Dictionary<string, object> data, string name = "")
        {
            CustomData = new Dictionary<string, object>(data);
            Name = name;
        }

        /***************************************************/

        public CustomObject(List<string> propertyNames, List<object> propertyValues, string name = "")
        {
            if (propertyNames.Count == propertyValues.Count)
            {
                for (int i = 0; i < propertyValues.Count; i++)
                {
                    CustomData.Add(propertyNames[i], propertyValues[i]);
                }
            }
            Name = name;
        }
    }
}
