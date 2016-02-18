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
    public class DOF : BHoM.Global.BHoMObject, IStructuralObject 
    {
        /////////////////
        ////Properties///
        /////////////////

        /// <summary>DOF number</summary>
        public int Number { get; private set; }

        /// <summary>DOF name</summary>
        public string Name { get; private set; }

        /// <summary>Direction</summary>
        public AxisDirection Direction { get; set; }

        /// <summary>Type of DOF (linear/non-linear etc)</summary>
        public DOFType Type { get; set; }

        /// <summary>DOF value</summary>
        public double Value { get; set; }

        /// <summary>DOF non-linear model</summary>
        public object NonLinearModel { get; set; }

        ///////////////////
        ////Constructors///
        ///////////////////

        /// <summary>Construct an empty DOF object</summary>
        public DOF()
        {
            this.Name = "";
            this.Number = -1;
        }

        /// <summary>Constructs a DOF using direction and type</summary>
        public DOF(AxisDirection direction, DOFType type)
            :this()
        {
            this.Direction = direction;
            this.Type = type;
        }

        /// <summary>Constructs a DOF using direciton, type and value</summary>
        public DOF(AxisDirection direction, DOFType type, double Value)
            :this()
        {
            this.Direction = direction;
            this.Type = type;
            this.Value = Value;
        }

        /// <summary>Constructs a DOF using direction, type and values as objects for non-linear model</summary>
        public DOF(AxisDirection direction, DOFType type, object Value)
            :this()
        {
            this.Direction = direction;
            this.Type = type;
            this.NonLinearModel = Value;
        }

        //////////////
        ////Methods///
        //////////////

        /// <summary>Sets the DOF name</summary>
        public void SetName(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Set the DOF number
        /// </summary>
        /// <param name="number"></param>
        public void SetNumber(int number)
        {
            this.Number = number;
        }

        /// <summary>Method which gets a properties dictionary for simple downstream deconstruct</summary>
        public BHoM.Collections.Dictionary<string, object> GetProperties()
        {
            BHoM.Collections.Dictionary<string, object> PropertiesDictionary = new BHoM.Collections.Dictionary<string, object>();
            PropertiesDictionary.Add("Number", this.Number);
            PropertiesDictionary.Add("Name", this.Name);
            PropertiesDictionary.Add("DOFType", this.Type);
            PropertiesDictionary.Add("Value", this.Value);
            PropertiesDictionary.Add("NonlinearModel", this.NonLinearModel);
            PropertiesDictionary.Add("UserData", this.UserData);

            PropertiesDictionary.Add("BHoM_Guid", this.BHoM_Guid);

            return PropertiesDictionary;
        }
    }




}
