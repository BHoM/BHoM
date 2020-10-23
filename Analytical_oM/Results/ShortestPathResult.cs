using BH.oM.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BH.oM.Analytical.Results;
using BH.oM.Geometry;

namespace BH.oM.Analytical.Elements
{
    //Result per analytic
    public class ShortestPathResult : IResult, IImmutable
    {
        [Description("ID of the object that this result belongs to.")]
        public virtual IComparable ObjectId { get; }

        [Description("Identifier for the search that the result belongs to.")]
        public virtual IComparable ResultCase { get; }

        [Description("Time step for time history results.")]
        public virtual double TimeStep { get; }

        [Description("Shortest path as an ordered collection of entities.")]
        public virtual List<IBHoMObject> Path { get; set; } = new List<IBHoMObject>();

        [Description("Shortest path as an ordered collection of ICurves.")]
        public virtual List<ICurve> Curves { get; set; } = new List<ICurve>();

        [Description("Total length of the shortest path. If the graph contained spatial entities and relations the distance traversed. If the graph is non spatial a count of traversed relations.")]
        public virtual double Length { get; set; } = 0.0;

        [Description("Total cost of the shortest path. Sum of each relation weight multiplied by its the length.")]
        public virtual double Cost { get; set; } = 0.0;

        [Description("All entities visited in searching for the path")]
        public virtual List<IBHoMObject> EntitiesVisited { get; set; } = new List<IBHoMObject>();

        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/
        public ShortestPathResult(IComparable objectId, IComparable resultCase, double timeStep, List<IBHoMObject> path, double length, double cost, List<IBHoMObject> entitiesVisited, List<ICurve> curves = null) 
        {
            ObjectId = objectId;
            ResultCase = resultCase;
            TimeStep = timeStep;
            Path = path;
            Length = length;
            Cost = cost;
            EntitiesVisited = entitiesVisited;
            Curves = curves;
        }
        /***************************************************/
        /**** IComparable Interface                     ****/
        /***************************************************/

        public int CompareTo(IResult other)
        {
            ShortestPathResult otherRes = other as ShortestPathResult;

            if (otherRes == null)
                return this.GetType().Name.CompareTo(other.GetType().Name);

            int n = this.ObjectId.CompareTo(otherRes.ObjectId);
            if (n == 0)
            {
                int l = this.ResultCase.CompareTo(otherRes.ResultCase);
                return l == 0 ? this.TimeStep.CompareTo(otherRes.TimeStep) : l;
            }
            else
            {
                return n;
            }
        }
    }
}