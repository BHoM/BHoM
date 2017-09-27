using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BH.oM.Geometry;
using BH.oM.Base;

namespace BH.oM.Acoustic
{
    /// <summary>
    /// BH.oM Acoustic Panel as Mesh. Please make sure you mesh is exploded into quadrangular or triangular mesh faces.
    /// </summary>
    public struct Panel
    {
        #region Fields

        private readonly Mesh _Mesh;
        private readonly List<double> _R;
        //private readonly Plane _Plane;

        #endregion

        #region Properties

        public Mesh Mesh
        {
            get { return _Mesh; }
        }

        public List<double> R
        {
            get { return _R; }
        }

        public Plane Plane
        {
            get { return Plane; }
            set
            {
                List<Point> Ver = Mesh.Vertices.ToList();
                //Plane = new Plane(Ver[0], Ver[1], Ver[2]);  // TODO Nedds to be in the Engine
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Defines an acoustic panel and an absorbtion factor
        /// </summary>
        /// <param name="mesh"></param>
        /// <param name="r"></param>
        public Panel(Mesh mesh, List<double> r) // TODO Add check for planarity of panel
        {
            _Mesh = mesh;
            _R = r;
        }
        /// <summary>
        /// Defines an acoustic panel. Default absorbtion index is 0.
        /// </summary>
        /// <param name="mesh"></param>
        public Panel(Mesh mesh) : this(mesh, new List<double> { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 }) 
        {
        }
        
        #endregion


    }
}
