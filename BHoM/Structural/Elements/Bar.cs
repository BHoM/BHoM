using BH.oM.Geometry;
using BH.oM.Base;
using System;
using System.Reflection;
using BH.oM.Structural.Loads;
using System.Collections.Generic;
using System.ComponentModel;
using BH.oM.Geometry.Curve;

namespace BH.oM.Structural.Elements
{
    /// <summary>
    /// Bar objects for 1D finite element bars. Note, cable elements separate.
    /// </summary>
    public class Bar : BHoMObject
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public Properties.SectionProperty SectionProperty { get; set; } = null;

        public BH.oM.Structural.Properties.BarRelease Release { get; set; } = null;

        public BH.oM.Structural.Properties.BarConstraint Spring { get; set; } = null;

        public BH.oM.Structural.Properties.Offset Offset { get; set; } = null;

        public BarStructuralUsage StructuralUsage { get; set; }

        /// <summary>
        /// Sets the type of elements that should be used in analysis software
        /// </summary>
        public BarFEAType FEAType { get; set; }

        public Node StartNode { get; set; }

        public Node EndNode { get; set; }

        /// <summary>
        /// Bar orientation angle in radians. For non-vertical bars, angle is measured in the bar YZ plane
        /// betwen the Y axis and the Y vector projected one a vertical plane defined by the start and end
        /// nodes. For vertical bars, angle is measured between the bar Y axis and global Y axis. A bar is 
        /// vertical if the distance between end points projected to a horizontal plane is less than 0.0001
        /// </summary>
        public double OrientationAngle { get; set; } = 0;


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public Bar() { }

        /***************************************************/

        public Bar(Node startNode, Node endNode, string barName = "")
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            Name = barName;
        }


        /***************************************************/
        /**** Local Methods                             ****/
        /***************************************************/

        public Materials.Material GetMaterial()
        {
            return SectionProperty != null ? SectionProperty.Material : null;
        }

        /***************************************************/

        public Point GetStartPoint()
        {
            return (StartNode == null) ? null : StartNode.Point;
        }

        /***************************************************/

        public Point GetEndPoint()
        {
            return (EndNode == null) ? null : EndNode.Point;
        }

        /***************************************************/

        public Line GetLine()
        {
            return new Line(GetStartPoint(), GetEndPoint());
        }

        /***************************************************/

        public double GetLength()
        {
            return (GetStartPoint() - GetEndPoint()).GetLength();
        }

        /***************************************************/

        public void SetStartPoint(Point point)
        {
            if (point == null) return;

            if (StartNode == null)
                StartNode = new Node(point);
            else
                StartNode.Point = point;
        }

        /***************************************************/

        public void SetEndPoint(Point point)
        {
            if (point == null) return;

            if (EndNode == null)
                EndNode = new Node(point);
            else
                EndNode.Point = point;
        }


        /***************************************************/
        /**** Override BHoMObject                       ****/
        /***************************************************/

        public override IBHoMGeometry GetGeometry()
        {
            return GetLine();
        }

        /***************************************************/

        public override void SetGeometry(IBHoMGeometry geometry)
        {
            if (geometry is ICurve)
            {
                ICurve curve = geometry as ICurve;
                SetStartPoint(curve.GetStart());
                SetEndPoint(curve.GetEnd());
            }
        }






        //#region Public Methods

        ///// <summary>
        ///// Get the node at the opposite end to the known (input) node
        ///// </summary>
        ///// <param name="node"></param>
        ///// <returns></returns>
        //public Node GetOppositeNode(Node node)
        //{
        //    if (EndNode.BHoM_Guid == node.BHoM_Guid)
        //        return StartNode;
        //    else
        //        return EndNode;
        //}

        ///// <summary></summary>
        //public Point GetOppositeEnd(Point point)
        //{
        //    if (StartPoint.DistanceTo(point) < EndPoint.DistanceTo(point))
        //        return EndPoint;
        //    else
        //        return StartPoint;
        //}



        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public override string ToString()
        //{
        //    return "Bar: " + StartPoint + " -> " + EndPoint;
        //}

        ///// <summary>
        ///// Switches start and end node
        ///// </summary>
        //public void FlipNodes()
        //{
        //    Node temp = StartNode;
        //    StartNode = EndNode;
        //    EndNode = temp;
        //}

        //#endregion


    }
}
