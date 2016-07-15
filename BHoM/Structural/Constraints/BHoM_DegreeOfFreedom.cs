using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Global;

namespace BHoM.Structural
{

    /// <summary>
    /// Degrees of freedom class for use in constraint objects
    /// </summary>
    public class DOF : BHoMObject
    {
        /////////////////
        ////Properties///
        /////////////////

        /// <summary>Type of DOF (linear/non-linear etc)</summary>
        public DOFType Type { get; set; }

        /// <summary>DOF value, -1 for fixed, 0 for free</summary>
        public double Value { get; set; }

        /// <summary>DOF non-linear model</summary>
        //public object NonLinearModel { get; set; }

        ///////////////////
        ////Constructors///
        ///////////////////

        /// <summary>Constructs an empty DOF object</summary>
        internal DOF() { }

        /// <summary>Constructs a DOF using direciton, type and value</summary>
        public DOF(DOFType type, double Value)
        {
            this.Type = type;
            this.Value = Value;
        }

        /// <summary>Constructs a DOF using direction, type and values as objects for non-linear model</summary>
        public DOF(DOFType type, object Value)
        {
            this.Type = type;
            //this.NonLinearModel = Value;
        }

        public string ToJSON()
        {
            return "{\"Type\": " + Type.ToString() + ", \"Value\": " + Value + "}"; 
        }

        public static DOF FromJSON(string json)
        {
            Dictionary<string, string> data = BHoMJSON.GetDefinitionFromJSON(json);
            DOF dof = new DOF();
            dof.Type = (DOFType)Enum.Parse(typeof(DOFType), data["Type"].Trim());
            dof.Value = double.Parse(data["Value"].Trim());
            return dof;
        }
    }
}
