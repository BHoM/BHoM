//using BH.oM.Geometry;
//using BH.oM.Base;
//using BH.oM.Materials;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;

//namespace BH.oM.Structural.Properties
//{
//    /// <summary>
//    /// Section property class, the parent abstract class for all structural 
//    /// sections (RC, steel, PT beams, columns, bracing). Properties defined in this 
//    /// parent class are those that would populate a multi category section database only
//    /// </summary>

//    public abstract partial class SectionProperty : BHoMObject  
//    {
//        /***************************************************/
//        /**** Properties                                ****/
//        /***************************************************/

//        //public List<ICurve> Edges { get; set; } = new List<ICurve>();

//        //public virtual double Orientation { get; set; } // TODO: Defien all the default values;

//        /***************************************************/
//        /**** Constructors                              ****/
//        /***************************************************/

//        public SectionProperty() { }
        
//    }
//}


///***************************************************/



////public override string ToString()     // That needs to be json
////{
////    string name = !string.IsNullOrWhiteSpace(Name) ? Name + " " : "";
////    string mat = (this.Material != null && !string.IsNullOrWhiteSpace(this.Material.Name)) ? "-" + this.Material.Name : "";
////    return name + "-" + mat;

////}


/////***************************************************/
/////**** Override BHoMObject                       ****/
/////***************************************************/

////public override IBHoMGeometry GetGeometry()
////{
////    return new GeometryGroup<ICurve> (Edges);
////}

