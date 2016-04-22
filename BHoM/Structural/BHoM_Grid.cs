using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BHoM.Structural
{
    /// <summary>
    /// Grid object
    /// </summary>
    public class Grid : Global.BHoMObject
    {
        public Geometry.ILine Curve { get; private set; }

        /// <summary>
        /// Construct a grid from a list of curves
        /// </summary>
        /// <param name="curves"></param>
        /// <param name="name"></param>
        internal Grid(Geometry.ILine curve, string name = "")    
        {
            this.Curve = curve;
            this.Name = name;
        }

        /// <summary>
        /// Construct a grid from a json string
        /// </summary>
        /// <param name="json"></param>
        internal Grid(string json = "")
        {
            int index = json.IndexOf(",\"curve\": ");
            string curveJson = json.Substring(index + 10);
            this.Curve = new Geometry.Line(curveJson);

            /*index = json.IndexOf(",\"Name\": ");
            this.Name = json.Substring(index + 9).Split(',')[0]; */
        }

        public override string JSON()
        {
            string json = ",\"curve\": ";

            Geometry.ILine curve = this.Curve;

            json += "{\"primitive\": \"line\"";
            json += ",\"start\": [" + curve.StartPoint.X + "," + curve.StartPoint.Y + "," + curve.StartPoint.Z + "]";
            json += ",\"end\": [" + curve.EndPoint.X + "," + curve.EndPoint.Y + "," + curve.EndPoint.Z + "]";
            json += "}";
 
            return base.JSON(json);
        }
    }
}
