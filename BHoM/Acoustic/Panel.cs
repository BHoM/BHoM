using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BHoM.Geometry;
using BHoM.Base;

namespace BHoM.Acoustic
{
    /// <summary>
    /// BHoM Acoustic Panel as Mesh. Please make sure you mesh is exploded into quadrangular or triangular mesh faces.
    /// </summary>
    public class Panel
    {
        #region Private Fields

        /// <summary>
        /// Geometry as quadrilateral or triangular Mesh
        /// </summary>
        private Mesh _Mesh;
        /// <summary>
        /// Absorbtion factor at each Octave
        /// </summary>
        private List<double> _R;
        /// <summary>
        /// Mesh Plane used for image mirroring
        /// </summary>
        private Plane _Plane;

        #endregion

        #region Public Properties

        public Mesh Mesh
        {
            get { return _Mesh; }
            set { _Mesh = Mesh; }
        }

        public List<double> R
        {
            get { return _R; }
            set { R = _R; }
        }

        /// <summary>
        /// Returns the plane panel for sources mirroring
        /// </summary>
        /// <returns></returns>
        public Plane Plane
        {
            get { return _Plane; }
            set
            {
                List<Point> Ver = Mesh.Vertices.ToList();
                _Plane = new Plane(Ver[0], Ver[1], Ver[2]);
            }
        }

        #endregion

        #region Constructor

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


    }
}
