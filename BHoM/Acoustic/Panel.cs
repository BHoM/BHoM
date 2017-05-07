using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Geometry;
using BHoM.Base;

namespace BHoM.Acoustic
{
    class Panel
    {
        #region Constructor

        /// <summary>
        /// Geometry as quadrilateral or triangular MeshFace
        /// </summary>
        public Mesh Mesh { get; set; }
        /// <summary>
        /// Absorbtion factor at each Octave
        /// </summary>
        public List<double> R { get; set; }

        /// <summary>
        /// Defines an acoustic panel and an absorbtion factor
        /// </summary>
        /// <param name="mesh"></param>
        /// <param name="r"></param>
        public Panel(Mesh mesh, List<double> r)          // Add check for planarity of panel
        {
            Mesh = mesh;
            R = r;
        }
        /// <summary>
        /// Defines an acoustic panel. Default absorbtion index is 0.
        /// </summary>
        /// <param name="mesh"></param>
        public Panel(Mesh mesh) : this(mesh, new List<double> { 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0 }) 
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the plane panel for sources mirroring
        /// </summary>
        /// <returns></returns>
        public Plane mPlane()
        {
            List<Point> Ver = Mesh.Vertices.ToList();
            return new Plane(Ver[0], Ver[1], Ver[2]);
        }

        #endregion
    }
}
