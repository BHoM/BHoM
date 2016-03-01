using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Collections;

namespace BHoM.Structural
{

    /// <summary>
    /// Degrees of freedom class for use in constraint objects
    /// </summary>
    public class DOF : BHoM.Global.BHoMObject
    {
        /////////////////
        ////Properties///
        /////////////////

        //public AxisDirection Direction { get; set; }

        /// <summary>Type of DOF (linear/non-linear etc)</summary>
        public DOFType Type { get; set; }

        /// <summary>DOF value</summary>
        public double Value { get; set; }

        /// <summary>DOF non-linear model</summary>
        public object NonLinearModel { get; set; }

        ///////////////////
        ////Constructors///
        ///////////////////

        /// <summary>Constructs an empty DOF object</summary>
        public DOF() { }

        /// <summary>Constructs a DOF using direciton, type and value</summary>
        public DOF(DOFType type, double Value)
        {
            //this.Direction = direction;
            this.Type = type;
            this.Value = Value;
        }

        /// <summary>Constructs a DOF using direction, type and values as objects for non-linear model</summary>
        public DOF(DOFType type, object Value)
        {
            //this.Direction = direction;
            this.Type = type;
            this.NonLinearModel = Value;
        }

        //////////////
        ////Methods///
        //////////////
    }
}
